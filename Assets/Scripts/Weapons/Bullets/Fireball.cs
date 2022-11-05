using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Entities;
using UnityEngine;
using Zenject;

namespace Weapons.Bullets
{
    public class Fireball: MonoBehaviour
    {
        public class Pool : MonoMemoryPool<FireballReinitializingData, Fireball>
        {
            protected override void Reinitialize(FireballReinitializingData reinitializingData, Fireball item)
            {
                item.ReInitialize(reinitializingData);
            }
        }
        public struct FireballReinitializingData
        {
            public Vector2 velocity;
            public Vector2 startPosition;
            
            public float damage;
            public float liveTime;
            public TargetType targetType;
            public RuntimeAnimatorController animatorController;
            public float spriteScale;
            public float colliderScale;
            
            public Pool poolSelf;
        }

        private Rigidbody2D _rb;
        private Animator _animator;
        private CircleCollider2D _collider;

        private FireballReinitializingData _data;
        private CancellationTokenSource _liveTimeCancellationToken;

        [Inject]
        public void Construct(Rigidbody2D rb, Animator animator, CircleCollider2D circleCollider)
        {
            _rb = rb;
            _animator = animator;
            _collider = circleCollider;

            _collider.isTrigger = true;
        }

        private void ReInitialize(FireballReinitializingData data)
        {
            _data = data;
            
            _animator.runtimeAnimatorController = _data.animatorController;
            _animator.transform.localScale = _data.spriteScale * Vector3.one;

            _collider.radius = _data.colliderScale;
            
            transform.position = data.startPosition;
            transform.rotation = Quaternion.Euler(0, 0, Vector3.SignedAngle(Vector3.up, data.velocity, Vector3.forward));
            _rb.velocity = _data.velocity;

            _liveTimeCancellationToken = new();
            DestroyAfterSeconds(_data.liveTime, _liveTimeCancellationToken.Token);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            IDamageAble damageAble = col.GetComponent<IDamageAble>();
            if(damageAble is null || (damageAble.targetType & _data.targetType) == 0)
                return;
            
            damageAble.Damage(_data.damage);
            _liveTimeCancellationToken.Cancel();
            _data.poolSelf.Despawn(this);
        }

        private async void DestroyAfterSeconds(float time, CancellationToken token)
        {
            try
            {
                await UniTask.Delay((int)(time * 1000), cancellationToken: token);
                _data.poolSelf.Despawn(this);
            }
            catch (OperationCanceledException) { }
        }
    }
}
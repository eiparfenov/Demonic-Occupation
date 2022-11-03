using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Entities;
using UnityEngine;
using Zenject;

namespace Weapons.Bullets
{
    public class Bullet: MonoBehaviour
    {
        public class Pool : MonoMemoryPool<BulletReinitializingData, Bullet>
        {
            protected override void Reinitialize(BulletReinitializingData reinitializingData, Bullet item)
            {
                item.ReInitialize(reinitializingData);
            }
        }
        public struct BulletReinitializingData
        {
            public Vector2 velocity;
            public float damage;
            public Vector2 startPosition;
            public TargetType targetType;
            public Pool poolSelf;
            public float liveTime;
        }

        [SerializeField] private Rigidbody2D rb;
        private TargetType _targetType;
        private float _damage;
        private Pool _poolSelf;
        private CancellationTokenSource _liveTimeCancellationToken;
        
        private void ReInitialize(BulletReinitializingData data)
        {
            _targetType = data.targetType;
            _damage = data.damage;
            _poolSelf = data.poolSelf;
            
            transform.position = data.startPosition;
            rb.velocity = data.velocity;

            _liveTimeCancellationToken = new();
            DestroyAfterSeconds(data.liveTime, _liveTimeCancellationToken.Token);
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            IDamageAble damageAble = col.collider.GetComponent<IDamageAble>();
            if(damageAble is not null && damageAble.targetType == _targetType)
                damageAble.Damage(_damage);
            
            _liveTimeCancellationToken.Cancel();
            _poolSelf.Despawn(this);
        }

        private async void DestroyAfterSeconds(float time, CancellationToken token)
        {
            try
            {
                await UniTask.Delay((int)(time * 1000), cancellationToken: token);
                _poolSelf.Despawn(this);
            }
            catch (OperationCanceledException) { }
        }
    }
}
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
        }

        [SerializeField] private Rigidbody2D rb;
        private TargetType _targetType;
        //private Vector2 _velocity;
        private float _damage;
        private Pool _poolSelf;
        
        private void ReInitialize(BulletReinitializingData data)
        {
            _targetType = data.targetType;
            //_velocity = data.velocity;
            _damage = data.damage;
            _poolSelf = data.poolSelf;
            
            transform.position = data.startPosition;
            rb.velocity = data.velocity;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            IDamageAble damageAble = col.collider.GetComponent<IDamageAble>();
            if(damageAble is not null && damageAble.targetType == _targetType)
                damageAble.Damage(_damage);
            
            _poolSelf.Despawn(this);
        }
    }
}
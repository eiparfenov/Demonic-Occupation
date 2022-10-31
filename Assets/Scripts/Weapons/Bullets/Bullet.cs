using Entities;
using UnityEngine;
using Zenject;

namespace Weapons.Bullets
{
    public class Bullet: MonoBehaviour
    {
        public class Pool : MonoMemoryPool<Vector2, float, Vector2, TargetType, Bullet>
        {
            protected override void Reinitialize(Vector2 p1, float p2, Vector2 p3, TargetType p4, Bullet item)
            {
                item.ReInitialize(p1, p2, p3, p4);
            }
        }

        [SerializeField] private Rigidbody2D rb;
        private TargetType _targetType;
        private Vector2 _velocity;
        private float _damage;
        
        public void ReInitialize(Vector2 velocity, float damage, Vector2 startPosition, TargetType targetType)
        {
            _targetType = targetType;
            _velocity = velocity;
            _damage = damage;
            
            transform.position = startPosition;
            transform.rotation = Quaternion.LookRotation(velocity);
            rb.velocity = velocity;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            IDamageAble damageAble = col.collider.GetComponent<IDamageAble>();
            if(damageAble is null)
                return;
            
            if(damageAble.targetType != _targetType)
                return;
            
            damageAble.Damage(_damage);
        }
    }
}
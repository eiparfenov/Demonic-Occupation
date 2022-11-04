namespace Entities
{
    public interface IDamageAble
    {
        TargetType targetType { get; }
        void Damage(float damage);
    }
}
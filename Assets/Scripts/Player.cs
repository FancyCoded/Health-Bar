using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Health _health;

    public void TakeDamage(float damage)
    {
        _health.Reduce(damage);
    }

    public void TakeHeal(float hitPoints)
    {
        _health.Increase(hitPoints);
    }
}


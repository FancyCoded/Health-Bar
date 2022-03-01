using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private Health _health;

    public void TakeDamage(float damage)
    {
        _healthBar.Reduce(damage);
    }

    public void TakeHeal(float hitPoints)
    {
        _healthBar.Increase(hitPoints);
    }
}


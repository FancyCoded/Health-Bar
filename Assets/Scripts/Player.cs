using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Health health;

    public void TakeDamage(float damage)
    {
        if (health.HitPoints >= damage)
        {
            health.Reduce(damage);
        }
    }

    public void TakeHeal(float hitPoints)
    {
        if(health.HitPoints + hitPoints <= health.GetMax())
        {
            health.Increase(hitPoints);
        }
    }
}


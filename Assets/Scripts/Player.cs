using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Slider _health;

    public float HitPoints { get; private set; }

    private void Awake()
    {
        HitPoints = _health.maxValue;
    }

    public void TakeDamage(float damage)
    {
        if (HitPoints >= damage)
        {
             HitPoints -= damage;
        }
    }

    public void TakeHeal(float hitPoints)
    {
        if (HitPoints + hitPoints <= _health.maxValue)
        {
            HitPoints += hitPoints;
        }
    }
}


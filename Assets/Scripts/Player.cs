using UnityEngine;

public class Player : MonoBehaviour
{
    public float HitPoints { get; private set; }

    private void Awake()
    {
        HitPoints = 100.00f;
    }

    public void TakeDamage(float damage)
    {
        if (HitPoints > 0)
        {
            HitPoints -= damage;
        }
    }

    public void TakeHeal(float hitPoints)
    {
        if (HitPoints < 100)
        {
            HitPoints += hitPoints;
        }
    }

    private void Update()
    {
        Debug.Log(HitPoints);
    }
}


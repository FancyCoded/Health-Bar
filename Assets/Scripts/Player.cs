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
        if (HitPoints >= damage)
        {
            if(gameObject.GetComponentInChildren<HealthBar>().IsCoroutineRunning == false)
            {
                HitPoints -= damage;
            }
        }
    }

    public void TakeHeal(float hitPoints)
    {
        if (HitPoints < 100)
        {
            if (gameObject.GetComponentInChildren<HealthBar>().IsCoroutineRunning == false)
            {
                HitPoints += hitPoints;
            }
        }
    }
}


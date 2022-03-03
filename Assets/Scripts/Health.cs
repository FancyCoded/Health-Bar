using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;
    public event UnityAction<float> Changed;
     
    public float HitPoints { get; private set; }
    public float Max { get; private set; }

    private void Awake()
    {
        Max = HitPoints = _healthBar.Max;
    }

    public void Reduce(float damage)
    {
        if (HitPoints >= damage)
        {
            Changed.Invoke(-damage);

            HitPoints -= damage;
        }
    }

    public void Increase(float hitPoints)
    {
        if (HitPoints + hitPoints <= Max)
        {
            Changed.Invoke(hitPoints);

            HitPoints += hitPoints;
        }
    }

    public void Update()
    {
        Debug.Log(HitPoints);
    }
}

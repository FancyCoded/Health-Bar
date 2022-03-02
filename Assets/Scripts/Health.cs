using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;

    private IEnumerator _changeHitPoints;

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
            if(_healthBar.IsCoroutineRunning == false)
            {
                _changeHitPoints = _healthBar.ChangeHitPoints(-damage);
                HitPoints -= damage;

                StartCoroutine(_changeHitPoints);
            }
        }
    }

    public void Increase(float hitPoints)
    {
        if (HitPoints + hitPoints <= Max)
        {
            if(_healthBar.IsCoroutineRunning == false)
            {
                _changeHitPoints = _healthBar.ChangeHitPoints(hitPoints);
                HitPoints += hitPoints;

                StartCoroutine(_changeHitPoints);
            }
        }
    }
}

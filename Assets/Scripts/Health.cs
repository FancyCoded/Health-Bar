using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;

    public float HitPoints { get; private set; }

    private void Awake()
    {
        HitPoints = _healthBar.maxValue;
    }

    public float GetMax()
    {
        return _healthBar.maxValue;
    }

    public void Reduce(float damage)
    {
        HitPoints -= damage;
    }

    public void Increase(float hitPoints)
    {
        HitPoints += hitPoints;
    }

    public void Update()
    {
        Debug.Log(HitPoints);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;

    public float HitPoints { get; private set; }
    public float Max { get; private set; } 

    private void Awake()
    {
        HitPoints = _healthBar.maxValue;
        Max = _healthBar.maxValue;
    }

    public void Set(float hitPoints)
    {
        HitPoints = hitPoints;
    }
}

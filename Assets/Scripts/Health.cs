using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public event UnityAction<float> Changed;
     
    public float HitPoints { get; private set; }
    public float Max { get; private set; }
    public float Min { get; private set; }

    private void Awake()
    {
        Max = HitPoints = 100;
        Min = 0;
    }

    public void Reduce(float damage)
    {
        HitPoints = Mathf.Clamp(HitPoints - damage, Min, Max);
        Changed?.Invoke(HitPoints);
    }

    public void Increase(float hitPoints)
    {
        HitPoints = Mathf.Clamp(HitPoints + hitPoints, Min, Max);
        Changed?.Invoke(HitPoints);
    }

    public void Update()
    {
        Debug.Log(HitPoints);
    }
}

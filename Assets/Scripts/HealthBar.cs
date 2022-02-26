using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _health;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Heal _heal;
    [SerializeField] private Hit _hit;

    private IEnumerator _hitOut;
    private IEnumerator _healUp;
    public bool IsCoroutineRunning { get; private set; }

    private void Awake()
    {
        _health.value = 100;
        _text.text = _health.value.ToString();
    }

    public void Hit()
    {
        if(IsCoroutineRunning == false)
        {
            _hitOut = ChangeHealthBar(-_hit.Damage);

            StartCoroutine(_hitOut);
        }
    }

    public void Heal()
    {
        if (IsCoroutineRunning == false)
        {
            _healUp = ChangeHealthBar(_heal.HealingHitPoints);

            StartCoroutine(_healUp);
        }
    }

    private IEnumerator ChangeHealthBar(float hitPoints)
    {
        IsCoroutineRunning = true;
        float targetHealth = _health.value + hitPoints;
        float deltaFactor = 10;
        float maxDelta = Time.deltaTime * deltaFactor;

        while ((_health.value < targetHealth &&  _health.value < 100) || (_health.value > targetHealth && _health.value > 0))
        {
            _health.value = Mathf.MoveTowards(_health.value, targetHealth, maxDelta);
            _text.text = _health.value.ToString("F2");

            yield return null;
        }

        IsCoroutineRunning = false;
    }
}

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

    public bool _isCoroutineRunning { get; private set; }

    private void Awake()
    {
        _health.value = 100;
        _text.text = _health.value.ToString();
    }

    public void OnHit()
    {
        if(_isCoroutineRunning == false)
        {
            _hitOut = TakeHit(_hit.Damage);

            StartCoroutine(_hitOut);
        }
    }

    public void OnHeal()
    {
        if (_isCoroutineRunning == false)
        {
            _healUp = TakeHeal(_heal.HealingHitPoints);

            StartCoroutine(_healUp);
        }
    }

    private IEnumerator TakeHit(float damage)
    {
        _isCoroutineRunning = true;
        float targetHealth = _health.value - damage;
        float deltaFactor = 10;
        float maxDelta = Time.deltaTime * deltaFactor;

        while (_health.value > targetHealth && _health.value > 0)
        {
            _health.value = Mathf.MoveTowards(_health.value, targetHealth, maxDelta);
            _text.text = _health.value.ToString("F2");

            yield return null;
        }

        _isCoroutineRunning = false;
    }

    private IEnumerator TakeHeal(float hitPoints)
    {
        _isCoroutineRunning = true;
        float targetHealth = _health.value + hitPoints;
        float deltaFactor = 10;
        float maxDelta = Time.deltaTime * deltaFactor;

        while (_health.value < targetHealth && _health.value < 100)
        {
            _health.value = Mathf.MoveTowards(_health.value, targetHealth, maxDelta);
            _text.text = _health.value.ToString("F2");

            yield return null;
        }

        _isCoroutineRunning = false;
    }
}

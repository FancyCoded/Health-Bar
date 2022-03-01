using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private TMP_Text _text;

    private IEnumerator _changeHitPoints;

    public bool IsCoroutineRunning { get; private set; }

    private void Awake()
    {
        _healthBar.value = 100.00f;
        _text.text = _healthBar.value.ToString();
    }

    public void Reduce(float damage)
    {
        if(IsCoroutineRunning == false)
        {
            _changeHitPoints = ChangeHitPoints(-damage);

            StartCoroutine(_changeHitPoints);
        }
    }

    public void Increase(float hitPoints)
    {
        if (IsCoroutineRunning == false)
        {
            _changeHitPoints = ChangeHitPoints(hitPoints);

            StartCoroutine(_changeHitPoints);
        }
    }

    private IEnumerator ChangeHitPoints(float hitPoints)
    {
        IsCoroutineRunning = true;
        float targetHealth = _healthBar.value + hitPoints;
        float deltaFactor = 10;
        float maxDelta = Time.deltaTime * deltaFactor;

        while (_healthBar.value != targetHealth && targetHealth >= 0 && targetHealth <= 100)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, targetHealth, maxDelta);
            _text.text = _healthBar.value.ToString("F2");

            yield return null;
        }

        IsCoroutineRunning = false;
    }
}

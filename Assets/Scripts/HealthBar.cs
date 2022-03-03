using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Health _health;

    private Slider _bar;
    private IEnumerator _changeHitPoints;

    private void OnEnable()
    {
        _health.Changed += OnChanged;
    }

    private void Start()
    {
        _bar = GetComponent<Slider>();
        _bar.maxValue = _bar.value = _health.Max;
        _text.text = _bar.value.ToString();
    }

    private void OnDisable()
    {
        _health.Changed -= OnChanged;
    }

    private void OnChanged(float hitPoints)
    {
        if(_changeHitPoints != null)
        {
            StopCoroutine(_changeHitPoints);
        }

        _changeHitPoints = ChangeHitPoints(hitPoints);

        StartCoroutine(_changeHitPoints);
    }

    private IEnumerator ChangeHitPoints(float targetHitPoints)
    {
        float deltaFactor = 10;
        float maxDelta = Time.deltaTime * deltaFactor;

        while(_bar.value != targetHitPoints)
        {
            _bar.value = Mathf.MoveTowards(_bar.value, targetHitPoints, maxDelta);
            _text.text = _bar.value.ToString("F2");

            yield return null;
        }
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _bar;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Health _health;

    private IEnumerator _changeHitPoints;

    public float Max { get; private set; }

    private void Awake()
    {
        Max = _bar.value = 100.00f;
        _text.text = _bar.value.ToString();
    }

    public void OnChanged(float hitPoints)
    {
        _changeHitPoints = ChangeHitPoints(hitPoints);

        StartCoroutine(_changeHitPoints);
    }

    public IEnumerator ChangeHitPoints(float hitPoints)
    {
        float step = 0.1f;
        float healthStepFactor = 0.01f;

        for (float i = 0; i < Mathf.Abs(hitPoints); i += step)
        {
            _bar.value += hitPoints * healthStepFactor;

            _text.text = _bar.value.ToString("F2");
            yield return null;
        }
    }

    private void OnEnable()
    {
        _health.Changed += OnChanged;
    }

    private void OnDisable()
    {
        _health.Changed -= OnChanged;
    }
}

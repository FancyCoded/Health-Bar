using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _bar;
    [SerializeField] private TMP_Text _text;

    public bool IsCoroutineRunning { get; private set; }
    public float Max { get; private set; }

    private void Awake()
    {
        Max = _bar.value = 100.00f;
        _text.text = _bar.value.ToString();
    }

    public IEnumerator ChangeHitPoints(float hitPoints)
    {
        IsCoroutineRunning = true;
        float targetHealth = _bar.value + hitPoints;
        float deltaFactor = 10;
        float maxDelta = Time.deltaTime * deltaFactor;

        while (_bar.value != targetHealth && targetHealth >= 0 && targetHealth <= 100)
        {
            _bar.value = Mathf.MoveTowards(_bar.value, targetHealth, maxDelta);
            _text.text = _bar.value.ToString("F2");

            yield return null;
        }

        IsCoroutineRunning = false;
    }
}

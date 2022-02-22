using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthChanger : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _text;

    private IEnumerator _hit;
    private IEnumerator _heal;

    private void Awake()
    {
        _slider.value = 100;
        _text.text = _slider.value.ToString();
    }

    public void HitOut()
    {
        _hit = Hit();

        StartCoroutine(_hit);
    }

    public void HealUp()
    {
        _heal = Heal();

        StartCoroutine(_heal);
    }

    private IEnumerator Hit()
    {
        float step = 0.1f;
        int damage = 10;

        for (float i = 0; i < damage; i += step)
        {
            _slider.value -= step;
            _text.text = _slider.value.ToString("F2");

            yield return null;
        }
    }

    private IEnumerator Heal()
    {
        float step = 0.1f;
        int heal = 10;

        for (float i = 0; i < heal; i += step)
        {
            _slider.value += step;
            _text.text = _slider.value.ToString("F2");

            yield return null;
        }

    }
}

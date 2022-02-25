using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hit : MonoBehaviour
{
    [SerializeField] private Slider _health;
    [SerializeField] private TMP_Text _text;

    private IEnumerator _hit;

    public void HitOut()
    {
        _hit = ToHit();

        StartCoroutine(_hit);
    }

    private IEnumerator ToHit()
    {
        int damage = 10;
        float targetHealth = _health.value - damage;
        float maxDelta = Time.deltaTime * 20;

        while (_health.value > targetHealth && _health.value > 0)
        {
            _health.value = Mathf.MoveTowards(_health.value, targetHealth, maxDelta);
            _text.text = _health.value.ToString("F2");

            yield return null;
        }
    }
}
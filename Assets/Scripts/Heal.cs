using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Heal : MonoBehaviour
{
    [SerializeField] private Slider _health;
    [SerializeField] private TMP_Text _text;

    private IEnumerator _heal;

    public void HealUp()
    {
        _heal = ToHeal();

        StartCoroutine(_heal);
    }

    private IEnumerator ToHeal()
    {
        int heal = 10;
        float targetHealth = _health.value + heal;
        float maxDelta = Time.deltaTime * 20;

        while (_health.value < targetHealth && _health.value < 100)
        {
            _health.value = Mathf.MoveTowards(_health.value, targetHealth, maxDelta);
            _text.text = _health.value.ToString("F2");

            yield return null;
        }
    }
}

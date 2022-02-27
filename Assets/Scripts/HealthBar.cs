using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _health;
    [SerializeField] private TMP_Text _text;

    private IEnumerator _changeHitPoints;

    public bool IsCoroutineRunning { get; private set; }

    private void Awake()
    {
        _health.value = 100.00f;
        _text.text = _health.value.ToString();
    }

    public void Hit(Player player)
    {
        if(IsCoroutineRunning == false)
        {
            float damage = -10;
            _changeHitPoints = ChangeHitPoints(damage);

            player.TakeDamage(Mathf.Abs(damage));
            StartCoroutine(_changeHitPoints);
        }
    }

    public void Heal(Player player)
    {
        if (IsCoroutineRunning == false)
        {
            float HealingHitPoints = 10;
            _changeHitPoints = ChangeHitPoints(HealingHitPoints);

            player.TakeHeal(HealingHitPoints);
            StartCoroutine(_changeHitPoints);
        }
    }

    private IEnumerator ChangeHitPoints(float hitPoints)
    {
        IsCoroutineRunning = true;
        float targetHealth = _health.value + hitPoints;
        float deltaFactor = 10;
        float maxDelta = Time.deltaTime * deltaFactor;

        while (_health.value != targetHealth && targetHealth >= 0 && targetHealth <= 100)
        {
            _health.value = Mathf.MoveTowards(_health.value, targetHealth, maxDelta);
            _text.text = _health.value.ToString("F2");

            yield return null;
        }

        IsCoroutineRunning = false;
    }
}

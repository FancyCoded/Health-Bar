using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private Slider _health;
    [SerializeField] private TMP_Text _text;

    private void Awake()
    {
        _health.value = 100;
        _text.text = _health.value.ToString();
    }
}


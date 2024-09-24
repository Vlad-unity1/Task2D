using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _healthSlider;

    private void Start()
    {
        UpdateHealthUI();
    }

    private void Update()
    {
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        if (_health != null && _healthSlider != null)
        {
            _healthSlider.value = _health.CurrentHealth;
        }
    }
}

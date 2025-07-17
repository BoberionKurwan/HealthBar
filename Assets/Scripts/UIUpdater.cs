using UnityEngine;

public class UIUpdater : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private HealthChanger _healthChanger;
    [SerializeField] private TextHandler _textHandler;
    [SerializeField] private SliderHandler _sliderHandler;
    [SerializeField] private SliderHandler _smoothSliderHandler;

    private void Start()
    {
        _health.HealthChanged += UpdateUI;
        UpdateUI();
    }

    private void UpdateUI()
    {
        _textHandler.UpdateHealthText(_health.Current, _health.MaxHealth);
        _sliderHandler.UpdateHealthSlider(_health.Current, _health.MaxHealth);
        _smoothSliderHandler.UpdateHealthSlider(_health.Current, _health.MaxHealth);
    }

    private void OnDestroy()
    {
            _health.HealthChanged -= UpdateUI;
    }
}
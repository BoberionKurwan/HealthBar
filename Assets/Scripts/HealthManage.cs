using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthManage : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private Button _damageButton;
    [SerializeField] private Button _healButton;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Slider _smoothHealthSlider;

    [SerializeField] private const float SmoothSpeed = 0.5f;
    [SerializeField] int _minHeal = 5;
    [SerializeField] int _maxHeal = 20;
    [SerializeField] int _minDamage = 5;
    [SerializeField] int _maxDamage = 20;

    private void Start()
    {
        _damageButton.onClick.AddListener(Damage);
        _healButton.onClick.AddListener(Heal);

        _healthSlider.minValue = 0f;
        _healthSlider.maxValue = 1f;
        _smoothHealthSlider.minValue = 0f;
        _smoothHealthSlider.maxValue = 1f;

        UpdateHealthUI();
    }

    private void Damage()
    {
        _health.TakeDamage(Random.Range(_minDamage, _maxDamage));
        UpdateHealthUI();
    }

    private void Heal()
    {
        _health.Restore(Random.Range(_minHeal, _maxHeal));
        UpdateHealthUI();
    }

    private void Update()
    {
        float targetValue = _health.Current / _health.MaxHealth;
        _smoothHealthSlider.value = Mathf.MoveTowards(_smoothHealthSlider.value, targetValue, Time.deltaTime * SmoothSpeed);
    }

    private void UpdateHealthUI()
    {
        float normalizedHealth = (float)_health.Current / _health.MaxHealth;
        _healthSlider.value = normalizedHealth;
        _healthText.text = $"Health: {_health.Current} / {_health.MaxHealth}";
    }
}
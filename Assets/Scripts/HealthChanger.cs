using UnityEngine;

[RequireComponent(typeof(Health))]
public class HealthChanger : MonoBehaviour
{
    [SerializeField] private ButtonHandler _healButtonHandler;
    [SerializeField] private ButtonHandler _damageButtonHandler;
    [SerializeField] private SliderHandler _slider;
    [SerializeField] private SliderHandler _smoothSlider;

    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void Start()
    {
        _healButtonHandler.ButtonClicked += Heal;
        _damageButtonHandler.ButtonClicked += Damage;
    }

    private void OnDestroy()
    {
        _healButtonHandler.ButtonClicked -= Heal;
        _damageButtonHandler.ButtonClicked -= Damage;
    }

    private void Heal(int amount)
    {
        _health.Restore(amount);
    }

    private void Damage(int amount)
    {
        _health.TakeDamage(amount);
    }
}
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderHandler : MonoBehaviour
{
    [SerializeField] private bool _useSmoothSpeed = true;
    [SerializeField] private float _smoothSpeed = 0.5f;

    private Slider _slider;
    private float _targetValue;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        _slider.minValue = 0f;
        _slider.maxValue = 1f;
    }

    private void Update()
    {
        if (_useSmoothSpeed)
        {
            _slider.value = Mathf.MoveTowards(
                _slider.value,
                _targetValue,
                Time.deltaTime * _smoothSpeed
            );
        }
        else
        {
            _slider.value = _targetValue;
        }
    }

    public void UpdateHealthSlider(float health, float maxHealth)
    {
        _targetValue = Mathf.Clamp01(health / maxHealth);
    }
}
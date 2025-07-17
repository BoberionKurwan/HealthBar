using TMPro;
using UnityEngine;

public class TextHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthText;

    public void UpdateHealthText(float health, float maxHealth)
    {
        _healthText.text = $"Health: {health} / {maxHealth}";
    }
}

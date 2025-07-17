using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonHandler : MonoBehaviour
{
    private Button _button;
    private int _healthAmount = 25;

    public event Action<int> OnButtonClicked;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        _button.onClick.AddListener(HandleClick);
    }

    private void HandleClick()
    {
        OnButtonClicked?.Invoke(_healthAmount);
    }
}
using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float _max = 100;
    private float _initial = 100;

    public float MaxHealth => _max; 
    public float Current { get; private set; }

    public event Action Died;

    private void Awake()
    {
        Current = _initial;
    }

    public void TakeDamage(float damage)
    {
        Current -= damage;

        if (Current < 0)
        {
            Current = 0;
            Died?.Invoke();
        }
    }

    public void Restore(float healthAmount)
    {
        if (healthAmount >= 0)
            Current += healthAmount;

        if (Current > _max)
            Current = _max;
    }
}
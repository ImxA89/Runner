using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;

    public int MaxHealth => _maxHealth;

    public event Action<int> HealthChanged;
    public event Action Died;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void ApllyDamage(int damage)
    {
        if (damage <= 0)
            return;

        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            Died?.Invoke();
        }

        HealthChanged?.Invoke(_currentHealth);
    }

    public void TakeHeal(int heal)
    {
        if (heal < 0)
            return;

        _currentHealth += heal;

        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;

        HealthChanged?.Invoke(_currentHealth);
    }
}

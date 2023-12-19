using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _healthTemplate;

    private Queue<GameObject> _healths = new Queue<GameObject>();

    private void Awake()
    {
        Initialize();
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int currentHealth)
    {
        if (_healths.Count > currentHealth)
            for (int i = 0; i < _healths.Count - currentHealth; i++)
                Destroy(_healths.Dequeue());

        else if (_healths.Count < currentHealth)
            for (int i = 0; i < currentHealth - _healths.Count; i++)
                AddHealth();
    }

    private void Initialize()
    {
        for (int i = 0; i < _player.MaxHealth; i++)
            AddHealth();
    }

    private void AddHealth()
    {
        _healths.Enqueue(Instantiate(_healthTemplate, transform));
    }
}

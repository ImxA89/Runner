using System;
using UnityEngine;

public class RepairKit : MonoBehaviour, ISpawnedObject
{
    [SerializeField] private int _healPower;

    public event Action<GameObject> Died;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            player.TakeHeal(_healPower);

        Died.Invoke(gameObject);
    }
}

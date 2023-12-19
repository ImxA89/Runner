using System;
using UnityEngine;

public class Enemy : MonoBehaviour, ISpawnedObject
{
    [SerializeField][Min(1)] private int _damage;

    public event Action<GameObject> Died;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            player.ApllyDamage(_damage);

        Died?.Invoke(gameObject);
    }
}

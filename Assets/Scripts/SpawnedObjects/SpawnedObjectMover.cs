using UnityEngine;

public class SpawnedObjectMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }
}

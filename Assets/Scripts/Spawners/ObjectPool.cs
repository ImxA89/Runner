using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private Factory _factory;
    private GameObject[] _prefabs;
    private Queue<GameObject> _pool = new Queue<GameObject>();
    private List<ISpawnedObject> _allObjects = new List<ISpawnedObject>();
    private int _minObjectsInPool = 2;

    public ObjectPool(Factory factory,GameObject[] prefabs)
    {
        _factory = factory;
        _prefabs = prefabs;
    }

    public void Initialize()
    {
        for (int i =0; i < _minObjectsInPool; i++)
        {
            Add(Instantiate());
        }
    }

    public void OnDisable()
    {
        foreach (ISpawnedObject objekt in _allObjects)
            objekt.Died -= OnDied;
    }

    public GameObject Give()
    {
        if (_pool.Count < _minObjectsInPool)
            Add(Instantiate());

        return _pool.Dequeue();
    }

    private GameObject Instantiate()
    {
        if (_prefabs.Length > 1)
            return _factory.Instantiat(_prefabs[Random.Range(0, _prefabs.Length)]);
        else  
            return _factory.Instantiat(_prefabs[0]);
    }

    private void Add(GameObject gameObject)
    {
        if (gameObject.TryGetComponent<ISpawnedObject>(out ISpawnedObject objekt))
        {
            gameObject.SetActive(false);
            _pool.Enqueue(gameObject);
            objekt.Died += OnDied;
            _allObjects.Add(objekt);
        }
    }

    private void OnDied(GameObject objekt)
    {
        objekt.SetActive(false);
        _pool.Enqueue(objekt);
    }
}

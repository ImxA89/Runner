using UnityEngine;

[RequireComponent(typeof(Factory))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemiesPrefabs;
    [SerializeField] private GameObject[] _kitsPreafbs;
    [SerializeField] private float _enemySpawnDelay;
    [SerializeField] private float _kitSpawnDelay;

    private Factory _factory;
    private ObjectPool _kitsPool;
    private ObjectPool _enemyPool;

    private Vector3[] _spawnPoints;
    private float _runningTime = 0f;
    private float _timeForEnemySpawn = 0f;
    private float _lineSize = 1f;
    private int _linesCount = 6;

    private void Awake()
    {
        _factory = GetComponent<Factory>();
        InitializeSpawnPoints();
        _kitsPool = new ObjectPool(_factory, _kitsPreafbs);
        _enemyPool = new ObjectPool(_factory, _enemiesPrefabs);
        _enemyPool.Initialize();
        _kitsPool.Initialize();
    }

    private void Update()
    {
        _runningTime += Time.deltaTime;

        if (_runningTime >= _timeForEnemySpawn && _runningTime < _kitSpawnDelay)
        {
            _timeForEnemySpawn += _enemySpawnDelay;
            SpawnEnemy();
        }
        else if (_runningTime >= _kitSpawnDelay)
        {
            _runningTime = 0f;
            _timeForEnemySpawn = _enemySpawnDelay;
            SpawnKit();
        }
    }

    private void OnDisable()
    {
        _enemyPool.OnDisable();
        _kitsPool.OnDisable();
    }

    private void InitializeSpawnPoints()
    {
        _spawnPoints = new Vector3[_linesCount];
        _spawnPoints[0] = transform.position;

        for (int i = 1; i < _linesCount; i++)
            _spawnPoints[i] = new Vector3(transform.position.x, transform.position.y + _lineSize * i, transform.position.z);
    }

    private void SpawnEnemy()
    {
        GameObject enemy = _enemyPool.Give();
        enemy.SetActive(true);
        enemy.transform.position = _spawnPoints[Random.Range(0, _linesCount)];
    }

    private void SpawnKit()
    {
        GameObject kit = _kitsPool.Give();
        kit.gameObject.SetActive(true);
        kit.transform.position = _spawnPoints[Random.Range(0, _linesCount)];
    }
}

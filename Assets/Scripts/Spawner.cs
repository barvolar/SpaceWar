using UnityEngine;

public class Spawner : PoolObject
{
    [SerializeField] private GameObject[] _templates;
    [SerializeField] private Player _player;
    [SerializeField] private float _timeBetweenSpawn;
    [SerializeField] private float _minSpawnPositionX;
    [SerializeField] private float _maxSpawnPositionX;
    [SerializeField] protected GameObject _spawnPosition;

    private Vector3 _spawnPoints;
    private float _elapsedTime;

    private void Awake()
    {
        _spawnPoints = _spawnPosition.transform.position;
        Initialization(_templates, _player);
        _elapsedTime = _timeBetweenSpawn;
    }

    private void Update()
    {
        _elapsedTime += Time.fixedUnscaledDeltaTime;
        if (_elapsedTime >= _timeBetweenSpawn)
        {
            if(TryGetRandomObject(out GameObject spawnedObject))
            {
                _elapsedTime = 0;

                float spawnPositionX = Random.Range(_minSpawnPositionX, _maxSpawnPositionX);
                _spawnPoints.x = spawnPositionX;
                spawnedObject.SetActive(true);
                spawnedObject.transform.rotation = _spawnPosition.transform.rotation;
                spawnedObject.transform.position = _spawnPoints;
            }
        }
    }
}

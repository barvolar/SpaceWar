using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _copacity;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialization(GameObject[] asteroids, Player player)
    {
        for (int i = 0; i < asteroids.Length; i++)
        {
            for (int j = 0; j < _copacity; j++)
            {
                GameObject spawnedAsteroid = Instantiate(asteroids[i], _container.transform);

                if (spawnedAsteroid.TryGetComponent(out Asteroid asteroid))
                    asteroid.SetPlayer(player);

                spawnedAsteroid.gameObject.transform.rotation = _container.transform.rotation;
                spawnedAsteroid.gameObject.SetActive(false);

                _pool.Add(spawnedAsteroid.gameObject);
            }
        }
    }

    protected bool TryGetRandomObject(out GameObject resul)
    {
        resul = _pool[Random.Range(0, _pool.Count)];

        if (resul.activeSelf == false)
            return resul != null;
        else
            return resul = null;
    }

    public void ResetPool()
    {
        foreach (var item in _pool)
        {
            item.SetActive(false);
        }
    }
}

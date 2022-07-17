using UnityEngine;

[RequireComponent(typeof(Player))]
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;

    private Player _player;
    private Vector3 _spawnPosition;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Asteroid asteroid))
        {
            _spawnPosition = asteroid.transform.position;
            _player.TakeDamage(asteroid.Damage);
            var particle = Instantiate(_particle, _spawnPosition, Quaternion.identity);
            asteroid.gameObject.SetActive(false);
        }
    }
}

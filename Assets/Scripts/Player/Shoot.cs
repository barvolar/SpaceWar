using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bullet;
    [SerializeField] protected float _shootSpeed;
    [SerializeField] private AudioSource _shootSound;
    [SerializeField] private AudioClip _shotAudio;
    
    private float _elapsedTime = 0;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _shootSpeed)
        {
            _elapsedTime = 0;
            SpawnBullet();
        }
    }

    private void SpawnBullet()
    {
        Instantiate(_bullet,_shootPoint.position,Quaternion.identity);
        _shootSound.PlayOneShot(_shotAudio);
    }
}

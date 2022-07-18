using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bullet;
    [SerializeField] protected float _shootSpeed;
    [SerializeField] private AudioSource _shootSound;
    [SerializeField] private AudioClip _shotAudio;

    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_shootSpeed);      
    }

    private void OnEnable()
    {
        StartCoroutine(SpawnBullet());
    }

    private void OnDisable()
    {
        StopCoroutine(SpawnBullet());
    }

    private IEnumerator SpawnBullet()
    {
        while (true)
        {
            Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
            _shootSound.PlayOneShot(_shotAudio);

            yield return _waitForSeconds;
        }
    }
   
}

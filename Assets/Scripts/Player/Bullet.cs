using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed = 200;
    private float _damage = 1;
    private float _lifeTime = 0;
    private float _maxLifeTime = 5f;
  
    private void Update()
    {
        _lifeTime += Time.deltaTime;

        transform.Translate(Vector3.forward * _speed * Time.deltaTime);

        if(_lifeTime>_maxLifeTime)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Asteroid asteroid))
        {
            asteroid.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}

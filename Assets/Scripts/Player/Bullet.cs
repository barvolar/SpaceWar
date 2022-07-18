using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed = 200;
    private float _damage = 1;
    private float _lifeTime = 2f;

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);

        Destroy(gameObject,_lifeTime);
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

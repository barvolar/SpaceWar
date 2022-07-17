using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float _speed = 10f;
    private float _lifeTime = 0f;
    private float _maxLifeTime = 4f;

    private void Update()
    {
        _lifeTime+=Time.deltaTime;

        if(_lifeTime > _maxLifeTime)
            Destroy(gameObject);

        transform.Translate(Vector3.back * _speed * Time.deltaTime);
    }
}

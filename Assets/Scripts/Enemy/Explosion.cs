using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float _speed = 10f;
    private float _lifeTime = 4f;

    private void Update()
    {
        transform.Translate(Vector3.back * _speed * Time.deltaTime);

        Destroy(gameObject,_lifeTime);
    }
}

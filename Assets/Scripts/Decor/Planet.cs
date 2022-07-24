using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Planet : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _speed = 980f;
    private float _rotationSpeed;
    private float _minRotationSpeed = -10f;
    private float _maxRotationSpeed = 10f;

    private void Awake()
    {
        _rigidbody= GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _rotationSpeed=Random.Range(_minRotationSpeed, _maxRotationSpeed);
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * _rotationSpeed *  Time.deltaTime);
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = Vector3.back * _speed * Time.fixedDeltaTime;
    }
}

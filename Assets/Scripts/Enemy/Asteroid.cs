using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Asteroid : MonoBehaviour
{
    private Player _player;
    private Rigidbody _rigidBody;
    private float _speed = 3000f;
    private float _health=2f;

    private float _xRotate;
    private float _yRotate;
    private float _zRotate;

    private float _minRotateValue = -90;
    private float _maxRotateValue = 90;

    public float Damage { get; private set; }

    private void Start()
    {
        Damage = 1f;
        _rigidBody = GetComponent<Rigidbody>();
        _xRotate = Random.Range(_minRotateValue, _maxRotateValue);
        _yRotate = Random.Range(_minRotateValue, _maxRotateValue);
        _zRotate = Random.Range(_minRotateValue, _maxRotateValue);
    }

    private void Update()
    {
        transform.Rotate(new Vector3(_xRotate, _yRotate, _zRotate)*Time.deltaTime);
        
        if(transform.position.z < -50)
            gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        _rigidBody.velocity = Vector3.back * _speed * Time.deltaTime;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            _player.AddScore();
            gameObject.SetActive(false);
        }
    }

    public void SetPlayer(Player player)
    {
        _player = player;
    }
}

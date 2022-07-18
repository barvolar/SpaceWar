using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Asteroid : MonoBehaviour
{
    private Player _player;
    private Rigidbody _rigidBody;
    private float _speed = 3000f;
    private float _health=2f;
    private Vector3 _rotate;
    private float _minRotateValue = -90;
    private float _maxRotateValue = 90;

    public float Damage { get; private set; }

    private void Start()
    {
        Damage = 1f;
        _rigidBody = GetComponent<Rigidbody>();
        _rotate=new Vector3(Random.Range(_minRotateValue,_maxRotateValue), Random.Range(_minRotateValue, _maxRotateValue), Random.Range(_minRotateValue, _maxRotateValue));
    }

    private void Update()
    {
        transform.Rotate(_rotate*Time.deltaTime);
        
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
            gameObject.SetActive(false);
            _player.AddScore();
        }
    }

    public void SetPlayer(Player player)
    {
        _player = player;
    }
}

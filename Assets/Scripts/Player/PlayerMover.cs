using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distanceFromCamera;

    private float _minPositionX = -31;
    private float _maxPositionX = 31;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = _distanceFromCamera;

        Vector3 mouseScreenToWorld = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 position = Vector3.Lerp(transform.position, mouseScreenToWorld, _speed * Time.deltaTime);
        transform.position = new Vector3(position.x, transform.position.y, transform.position.z);
        ClampPosition();
    }

    private void ClampPosition()
    {
        float xPosition = Mathf.Clamp(transform.position.x, _minPositionX, _maxPositionX);
        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
    }
}

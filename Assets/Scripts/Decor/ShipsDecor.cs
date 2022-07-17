using UnityEngine;

public class ShipsDecor : MonoBehaviour
{
    private float _speed = 770f;
    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.fixedUnscaledDeltaTime);
    }
}

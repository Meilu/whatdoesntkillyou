using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    private Vector3 _positiveXDirection;
    private Vector3 _negativeXDirection;
    public float speed = 1.0f;

    void Start()
    {
        var rigidBody = GetComponent<Rigidbody>();

        _positiveXDirection = new Vector3(3.0f, rigidBody.position.y, rigidBody.position.z);
        _negativeXDirection = new Vector3(-3.0f, rigidBody.position.y, rigidBody.position.z);
    }

    void Update()
    {
        transform.position = Vector3.Lerp(_positiveXDirection, _negativeXDirection, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    }
}

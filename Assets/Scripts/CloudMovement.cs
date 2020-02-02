using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    private Vector3 _positiveXDirection;
    private Vector3 _negativeXDirection;
    public float speed = 1.0f;

    void Start()
    {
        var currentX = transform.position.x;
        var currentY = transform.position.y;
        var currentZ = transform.position.z;

        _positiveXDirection = new Vector3(currentX + 3.0f, currentY, currentZ);
        _negativeXDirection = new Vector3(currentX - 3.0f, currentY, currentZ);
    }

    void Update()
    {
        transform.position = Vector3.Lerp(_positiveXDirection, _negativeXDirection, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    }
}

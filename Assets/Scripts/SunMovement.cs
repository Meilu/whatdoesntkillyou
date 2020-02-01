using UnityEngine;

public class SunMovement : MonoBehaviour
{
    [SerializeField] GameObject camera;
    private Rigidbody _cameraRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        _cameraRigidBody = camera.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var cameraPosition = new Vector3(_cameraRigidBody.transform.position.x + 10, transform.position.y, transform.position.z);
        transform.SetPositionAndRotation(cameraPosition, transform.rotation);
    }
}

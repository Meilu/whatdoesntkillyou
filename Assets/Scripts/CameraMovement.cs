using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject character;
    Rigidbody rigidBodyToFollow;
    Rigidbody cameraRigidBody;

    // Start is called before the first frame update
    void Awake()
    {
      SetGameobjectToFollow(character);
      cameraRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      if (rigidBodyToFollow == null)
        return;
      
      Vector3 cameraPosition = new Vector3(rigidBodyToFollow.transform.position.x, rigidBodyToFollow.transform.position.y, cameraRigidBody.position.z);
      cameraRigidBody.MovePosition(cameraPosition);
    }

    public void SetGameobjectToFollow(GameObject go)
    {
      var rb = go.GetComponent<Rigidbody>();

      if (rb == null)
        return;

      rigidBodyToFollow = rb;
    }
}

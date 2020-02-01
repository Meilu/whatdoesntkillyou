using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject character;
    Rigidbody playerRigidBody;
    Rigidbody cameraRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = character.GetComponent<Rigidbody>();
        cameraRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var cameraPosition = new Vector3(playerRigidBody.transform.position.x, playerRigidBody.transform.position.y, cameraRigidBody.position.z);
        cameraRigidBody.MovePosition(cameraPosition);
    }
}

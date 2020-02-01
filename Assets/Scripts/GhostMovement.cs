using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    [SerializeField] float speed = 0.7f;
    [SerializeField] float maxSpeed = 3.5f;

    private Rigidbody _rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //beweging naar links
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                _rigidBody.AddForce(Vector3.left * speed, ForceMode.Impulse);
            }
            //beweging naar rechts 
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                _rigidBody.AddForce(Vector3.right * speed, ForceMode.Impulse);
            }
            //beweging omhoog
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                _rigidBody.AddForce(Vector3.up * speed, ForceMode.Impulse);
            }
            //beweging omlaag
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                _rigidBody.AddForce(Vector3.down * speed, ForceMode.Impulse);
            } 

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    private Rigidbody _rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //links en rechts ophalen
        float moveInput = Input.GetAxisRaw("Horizontal");
        //jump ophalen
        if(Input.GetKey(KeyCode.Space))
        {
            _rigidBody.AddForce(Vector3.up * 2.0f, ForceMode.Impulse);
        }

        //
       Vector3 nieuwePositie = transform.position + (transform.right * moveInput) * 0.3f;

       _rigidBody.MovePosition(nieuwePositie);
    }
}

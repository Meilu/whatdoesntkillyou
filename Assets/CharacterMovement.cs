using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float speed = 0.3f;
    [SerializeField] float jumpFactor = 2.0f;

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
        
       

        //
       Vector3 nieuwePositie = transform.position + (transform.right * moveInput) * speed;

       _rigidBody.MovePosition(nieuwePositie);
    }

    private void OnCollisionStay(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Jump-OK":
                //jump ophalen
                if (Input.GetKey(KeyCode.Space))
                {
                    _rigidBody.AddForce(Vector3.up * jumpFactor, ForceMode.Impulse);
                }
                break;
            
            default:
                break;
        }
    }
}

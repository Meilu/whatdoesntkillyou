using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float speed = 0.3f;
    [SerializeField] float jumpFactor = 4.0f;
    private bool airTime;

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

        //als er niet gejumpt wordt links of rechts verwerken
        if (!airTime)
        {
            Vector3 nieuwePositie = transform.position + (transform.right * moveInput) * speed;
            _rigidBody.MovePosition(nieuwePositie);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        //er kan weer gestuurd worden
        airTime = false;

        //jump alleen mogelijk als je op een ondergrond staat
        switch (collision.gameObject.tag)
        {
            case "Jump-OK":
                //jump ophalen
                if (Input.GetKey(KeyCode.Space))
                {
                    _rigidBody.AddForce(Vector3.up * jumpFactor, ForceMode.Impulse);
                    airTime = true;
                }
                //sprong naar links verwerken
                if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                {
                    _rigidBody.AddForce(Vector3.left * jumpFactor, ForceMode.Impulse);
                }
                //sprong naar rechts verwerken
                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                {
                    _rigidBody.AddForce(Vector3.right * jumpFactor, ForceMode.Impulse);
                }
                break;
            
            default:
                break;
        }
    }
}

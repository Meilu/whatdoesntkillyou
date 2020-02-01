using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float speed = 0.3f;
    [SerializeField] float jumpFactor = 8.0f;
    [SerializeField] float jumpLeftRightFactor = 0.3f;

    private bool _airTime;
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

        //als er niet gejumpt wordt links of rechts wandelen
        if (!_airTime)
        {
            Vector3 nieuwePositie = transform.position + (transform.right * moveInput) * speed;
            _rigidBody.MovePosition(nieuwePositie);
            //if jump dan springen
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rigidBody.AddForce(Vector3.up * jumpFactor, ForceMode.Impulse);
                _airTime = true;
            }
        }
        //als er wel gejumped wordt links en rechts als impuls verwerken
        if(_airTime)
        {
            //sprong naar links verwerken
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                _rigidBody.AddForce(Vector3.left * jumpLeftRightFactor, ForceMode.Impulse);
            }
            //sprong naar rechts verwerken
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                _rigidBody.AddForce(Vector3.right * jumpLeftRightFactor, ForceMode.Impulse);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //er kan weer gestuurd worden
        _airTime = false;
    }
}

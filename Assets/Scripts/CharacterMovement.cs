using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float speed = 0.7f;
    [SerializeField] float jumpFactor = 8.0f;
    [SerializeField] float jumpLeftRightFactor = 0.3f;

    private bool _airTime;
    private Rigidbody _rigidBody;
    private Animator _animator;

    // Start is called before the first frame update
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //als er niet gejumpt wordt links of rechts wandelen
        if (!_airTime)
        {
          
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
              // transform.rotation
              _animator.Play("walk");
              _rigidBody.AddForce(Vector3.left * speed, ForceMode.Impulse);
            }
            // naar rechts verwerken
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
              _animator.Play("walk");
              _rigidBody.AddForce(Vector3.right * speed, ForceMode.Impulse);
            }

            //if jump dan springen
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _animator.Play("jump");
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
        //besturing na landing aanpassen
        _airTime = false;
    }
}

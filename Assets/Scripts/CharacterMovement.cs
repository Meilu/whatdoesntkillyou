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
        var rotationInY = transform.rotation.y;

        //als er niet gejumpt wordt links of rechts wandelen
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (rotationInY > 0)
                rotationInY *= -1;

            transform.rotation = new Quaternion(transform.rotation.x, rotationInY, transform.rotation.z, transform.rotation.w);
            // transform.rotation
            _animator.Play("walk");
            _rigidBody.AddForce(Vector3.left * speed, ForceMode.Impulse);
            return;
        }
        // naar rechts verwerken
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (rotationInY < 0)
                rotationInY *= -1;

            transform.rotation = new Quaternion(transform.rotation.x, rotationInY, transform.rotation.z, transform.rotation.w);

            _animator.Play("walk");
            _rigidBody.AddForce(Vector3.right * speed, ForceMode.Impulse);
            return;
        }

        //if jump dan springen
        if (Input.GetKeyDown(KeyCode.Space) && !_airTime)
        {
            _animator.Play("jump");
            _rigidBody.AddForce(Vector3.up * jumpFactor, ForceMode.Impulse);
            _airTime = true;
            return;
        }


        _animator.Play("Idle");
    }

    private void OnCollisionEnter(Collision collision)
    {
        //besturing na landing aanpassen
        _airTime = false;
    }
}

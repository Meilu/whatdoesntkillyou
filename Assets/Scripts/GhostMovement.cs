﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
  [SerializeField] float speed = 0.7f;

  private Rigidbody _rigidBody;
  private Rigidbody _bodyPart;
  public bool holdBodypart;
  private HingeJoint hj;

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

    if (Input.GetKeyDown(KeyCode.E))
    {
      //bodpart loslaten
      holdBodypart = false;
      Destroy(hj);
      //_bodyPart.transform.parent = null;
      //_bodyPart.isKinematic = false;
      //_bodyPart.useGravity = true;
    }
  }

  //oppakken van onderdelen
  public void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.tag == "BodyPart")
    {
      if (!holdBodypart)
      {
        holdBodypart = true;
        _bodyPart = collision.gameObject.GetComponent<Rigidbody>();
        hj = gameObject.AddComponent<HingeJoint>();

        hj.connectedBody = collision.rigidbody;
        _bodyPart.mass = 0.00001f;
        _bodyPart.freezeRotation = true;
        _bodyPart.velocity = Vector3.zero;
      }
    }
  }
}

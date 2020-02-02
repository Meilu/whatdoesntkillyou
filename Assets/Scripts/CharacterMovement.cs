﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
  [SerializeField] public float speed = 0.7f;
  [SerializeField] public float jumpLeftRightFactor = 0.3f;

  private bool _airTime;
  private Rigidbody _rigidBody;
  private Animator _animator;
  private GameStateController _gameStateController;
  private AudioSource _audioSource;
  public AudioClip DestroyedSound;
  public AudioClip WalkSound;

  // Start is called before the first frame update
  void Awake()
  {
    _gameStateController = GameObject.Find("GameStateController").GetComponent<GameStateController>();
    _rigidBody = GetComponent<Rigidbody>();
    _animator = GetComponent<Animator>();
    _audioSource = GetComponent<AudioSource>();
  }

  void Start()
  {
    _animator.Play("backflip");
  }
  

  // Update is called once per frame
  void Update()
  {
    var rotationInY = transform.rotation.y;

    //springen links tijdens het lopen verwerken
    if ((Input.GetKeyDown(KeyCode.Space) && !_airTime) &&
        ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))))
    {
      _animator.Play("jump");
      _rigidBody.AddForce(Vector3.up * _gameStateController.characterJumpFactor, ForceMode.Impulse);
      _rigidBody.AddForce(Vector3.left * speed, ForceMode.Impulse);
      _airTime = true;
      return;
    }

    //als er niet gejumpt wordt links wandelen
    if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
    {
      if (rotationInY > 0)
        rotationInY *= -1;

      transform.rotation =
        new Quaternion(transform.rotation.x, rotationInY, transform.rotation.z, transform.rotation.w);
      // transform.rotation
      _animator.Play("walk");
      PlayWalkingSound();
      _rigidBody.AddForce(Vector3.left * speed, ForceMode.Impulse);
      return;
    }

    //springen rechts tijdens het lopen verwerken
    if ((Input.GetKeyDown(KeyCode.Space) && !_airTime) &&
        ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))))
    {
      _animator.Play("jump");
      _rigidBody.AddForce(Vector3.up * _gameStateController.characterJumpFactor, ForceMode.Impulse);
      _rigidBody.AddForce(Vector3.right * speed, ForceMode.Impulse);
      _airTime = true;
      return;
    }


    // naar rechts verwerken
    if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
    {
      if (rotationInY < 0)
        rotationInY *= -1;

      transform.rotation =
        new Quaternion(transform.rotation.x, rotationInY, transform.rotation.z, transform.rotation.w);

      _animator.Play("walk");
      PlayWalkingSound();
      _rigidBody.AddForce(Vector3.right * speed, ForceMode.Impulse);
      return;
    }

    //if jump dan springen
    if (Input.GetKeyDown(KeyCode.Space) && !_airTime)
    {
      _animator.Play("jump");
      _rigidBody.AddForce(Vector3.up * _gameStateController.characterJumpFactor, ForceMode.Impulse);
      _airTime = true;
      return;
    }


    _animator.Play("bellydance");
  }

  private void PlayWalkingSound()
  {
    if (_audioSource.isPlaying)
      return;
    
    _audioSource.PlayOneShot(WalkSound, 7.0F);
  }
  
  private void OnCollisionEnter(Collision collision)
  {
    //besturing na landing aanpassen
    _airTime = false;
  }
}

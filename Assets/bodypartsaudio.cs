using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodypartsaudio : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip BodyPartsExplosion;
    
    // Start is called before the first frame update
    void Start()
    {
      _audioSource = GetComponent<AudioSource>();
      _audioSource.PlayOneShot(BodyPartsExplosion, 3.0F);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

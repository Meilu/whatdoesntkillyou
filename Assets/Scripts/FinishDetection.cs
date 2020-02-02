using System;
using UnityEngine;

public class FinishDetection : MonoBehaviour
{
    public GameObject finishMenu;
    private AudioSource _audioSource;
    public AudioClip finishSound;

    private void Start()
    {
      _audioSource = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.name == "character")
        {
            GameObject.Find("backgroundsound").GetComponent<AudioSource>().Stop();
            _audioSource.PlayOneShot(finishSound, 2.0f);
            
            other.transform.parent.GetComponent<CharacterMovement>().backFlip();
            // show menu
            finishMenu.SetActive(true);

            // activate animation
        }
    }
}

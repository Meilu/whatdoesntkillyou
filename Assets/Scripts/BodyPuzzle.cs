using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BodyPuzzle : MonoBehaviour
{
  public AudioClip BodyPlop;
  private AudioSource _audioSource;

  public GameObject characterPrefab;
    // Start is called before the first frame update
    void Start()
    {
      _audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
      if (!other.gameObject.CompareTag("BodyPart"))
        return;
      
      Debug.Log("body part fell onto puzzle. name is " + other.transform.parent.name);
      var otherName = other.transform.parent.name;

      var childrenTransforms = transform.GetComponentsInChildren<Transform>();
      var child = childrenTransforms.First(x => x.name == otherName);
      child.Find("renderer").GetComponent<Renderer>().enabled = true;

      Destroy(GameObject.Find("GhostMainChar").GetComponent<HingeJoint>());
      GameObject.Find("GhostMainChar").GetComponent<GhostMovement>().holdBodypart = false;
      Destroy(other.gameObject);
      
      _audioSource.PlayOneShot(BodyPlop, 2.0F);
      var enabledBodyparts = transform
        .GetComponentsInChildren<Renderer>()
        .Count(x => x.enabled);
      
      if (enabledBodyparts == 6)
      {
        var childRenderers = transform.GetComponentsInChildren<Renderer>();
        foreach (var childRenderer in childRenderers)
        {
          childRenderer.enabled = false;
        }
        
        Debug.Log("karakter is klaar met bouwen");
        
        GameObject.Find("GhostMainChar").SetActive(false);
        var newCharacter = Instantiate(characterPrefab);
        newCharacter.transform.position = transform.position;
        newCharacter.name = "character";
        GameObject.Find("GameStateController").GetComponent<GameStateController>().characterJumpFactor += 2.0f;
        
        GameObject.Find("Camera").GetComponent<CameraMovement>().SetGameobjectToFollow(newCharacter);
        
      }
    }
}

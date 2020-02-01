using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BodyPuzzle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
    Destroy(other.gameObject);
    }
}

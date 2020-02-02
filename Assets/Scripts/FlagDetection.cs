using UnityEngine;

public class FlagDetection : MonoBehaviour
{
    public GameObject bodyPuzzlePrefab;
    private bool created; 

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.name == "character" && created == false)
        {
            Instantiate(bodyPuzzlePrefab, transform.position, Quaternion.identity);
            created = true;
        }
    }
}

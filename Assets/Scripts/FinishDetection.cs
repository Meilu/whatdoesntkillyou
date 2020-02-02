using UnityEngine;

public class FinishDetection : MonoBehaviour
{
    public GameObject finishMenu;

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.name == "character")
        {
            // show menu
            finishMenu.SetActive(true);

            // activate animation
        }
    }
}

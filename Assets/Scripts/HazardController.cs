using UnityEngine;

public class HazardController : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "character")
        {
            var bodyPartsController = collision.gameObject.GetComponent<BodyPartsSpawnController>();
            bodyPartsController.SpawnBodyParts();
        }
    }

}

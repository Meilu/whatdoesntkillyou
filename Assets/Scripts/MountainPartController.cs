using UnityEngine;

public class MountainPartController : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Character")
        {
            Destroy(gameObject);
        }
    }
}

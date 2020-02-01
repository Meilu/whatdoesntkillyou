using System.Collections;
using System.Linq;
using UnityEngine;

public class HazardController : MonoBehaviour
{
  public void OnCollisionEnter(Collision collision)
  {
    //Check for a match with the specified name on any GameObject that collides with your GameObject
    if (collision.gameObject.name == "character")
    {
      var ghost = Resources.FindObjectsOfTypeAll<GhostMovement>().First();
      ghost.transform.position = new Vector3(collision.gameObject.transform.position.x, 
            collision.gameObject.transform.position.y + 5,
                collision.gameObject.transform.position.z);
      

      var bodyPartsController = collision.gameObject.GetComponent<BodyPartsSpawnController>();
      bodyPartsController.SpawnBodyParts();

      StartCoroutine(SpawnGhost(ghost.gameObject));
    }
  }

  private IEnumerator SpawnGhost(GameObject ghost)
  {
    yield return new WaitForSeconds(2);

    ghost.SetActive(true);
    var ghostRb = ghost.GetComponent<Rigidbody>();
    ghostRb.AddForce(ghost.transform.up * 15.0f, ForceMode.Impulse);

    var camera = GameObject.Find("Camera");
    camera.GetComponent<CameraMovement>().SetGameobjectToFollow(ghost);

    var bodyPuzzle = Resources.FindObjectsOfTypeAll<BodyPuzzle>().First();
//    bodyPuzzle.GetComponent<CameraMovement>().SetGameobjectToFollow(ghost);
    bodyPuzzle.gameObject.SetActive(true);
  }
}

using UnityEngine;

public class SpawnPointDetection : MonoBehaviour
{
    public GameObject bodyPuzzlePrefab;
    private bool created;

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent?.name == "character" && created == false)
        {
            var zcoordinate = transform.position.z - 1.0f;
            var ycoordinate = transform.position.y - 0.5f;
            var bodyPuzzlePosition = new Vector3(transform.position.x, ycoordinate, zcoordinate);

            Instantiate(bodyPuzzlePrefab, bodyPuzzlePosition, Quaternion.identity);
            created = true;
        }
    }
}

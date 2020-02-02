using UnityEngine;

public class BodyPartsSpawnController : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private bool _bodyPartsExists;

    [SerializeField] GameObject bodyPrefab;

    public void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    public void SpawnBodyParts()
    {
        if (_bodyPartsExists)
            return;

        var position = _rigidBody.position;

        Destroy(gameObject);
        var body = Instantiate(bodyPrefab, position, Quaternion.identity) as GameObject;

        var allChildren = body.GetComponentsInChildren<Rigidbody>();
        foreach (var child in allChildren)
        {
            var randomPosition = new Vector3(
                Random.Range(-25.5f, 25.5f),
                Random.Range(0, 50.0f),
                0);

            child.AddForce(randomPosition, ForceMode.Impulse);
        }

        _bodyPartsExists = true;
    }
}
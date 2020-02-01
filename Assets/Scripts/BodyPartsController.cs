using System.Threading;
using UnityEngine;

public class BodyPartsController : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private Random _random;

    [SerializeField] GameObject bodyPrefab;

    public void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _random = new Random();
    }

    public void SpawnBodyParts()
    {
        var position = _rigidBody.position;

        Destroy(gameObject);
        var body = Instantiate(bodyPrefab, position, Quaternion.identity) as GameObject;

        var allChildren = body.GetComponentsInChildren<Rigidbody>();
        foreach (var child in allChildren)
        {
            var randomPosition = new Vector3(
                Random.Range(-5.5f, 5.5f),
                Random.Range(0, 3.5f),
                0);

            child.AddForce(randomPosition, ForceMode.Impulse);
        }
    }
}
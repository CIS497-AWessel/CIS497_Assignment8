/* Anthony Wessel
 * Assignment 8 Prototype 5
 * 
 * Randomizes target's position, and movement when spawned,
 * and handles all events related to this target
 */

using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRB;

    float minSpeed = 14;
    float maxSpeed = 18;
    float maxTorque = 10;
    float xRange = 4;
    float ySpawnPos = -6;

    GameManager gameManager;

    public int pointValue;
    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        targetRB = GetComponent<Rigidbody>();

        // Add a randomized upward force
        targetRB.AddForce(RandomForce(), ForceMode.Impulse);

        // Add a randomized torque
        targetRB.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        // Set randomized start position
        transform.position =  RandomSpawnPos();
    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            gameManager.UpdateScore(pointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.CompareTag("Bad"))
            gameManager.GameOver();

        Destroy(gameObject);
    }
}

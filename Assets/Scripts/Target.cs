using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorgue = 10;
    private float xRange = 4;
    private float ySpawnPos = 6;
    
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        
        targetRb.AddForce(RandomForce(),ForceMode.Impulse);
        targetRb.AddTorque(RandomTorgue(),RandomTorgue(),RandomTorgue(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }

    Vector3 RandomForce()
    {
        return new Vector3(0, Random.Range(minSpeed, maxSpeed));
    }
    float RandomTorgue()
    {
        return Random.Range(-xRange, xRange);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-4, 4), -6);
    }
  
}

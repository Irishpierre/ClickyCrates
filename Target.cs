using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    //Get Rigidbody
    private Rigidbody targetRb;

    //Speed
    private float minSpeed = 12.0f;
    private float maxSpeed = 16.0f;

    //Torque
    private float maxTorque = 10.0f;

    //Spawn range
    private float xRange = 4.0f;
    private float ySpawnPos = -2.0f;

    //Get Game Manager
    private GameManager gameManager;

    //Individual points
    public int pointValue;

    //Particle Effect
    public ParticleSystem clickEffect;


    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        //Have the targets fly upward
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        //Targets move upward AND rotate
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        //Targets randomly spawn on the X axis
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(clickEffect, transform.position, clickEffect.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
        

    }


    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
        
    }


    //Force Method
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    //Torque Method
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    //Spawn
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Target : MonoBehaviour
{
 private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;
    private GameManager GameManager;
    public int Pointvalue;
    public ParticleSystem EDP445;
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(randomTorque(), randomTorque(), randomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
        GameManager = GameObject.Find("GameManager")
            .GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Vector3 RandomForce() 
    
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float randomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawnPos()
    {
       return  new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
    private void OnMouseDown()
    {
        if (GameManager.isGameActive)
        {
            Destroy(gameObject);
            GameManager.UpdateScore(Pointvalue);
            Instantiate(EDP445, transform.position, EDP445.transform.rotation);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad")) { GameManager.GameOver(); }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public Transform player; // Reference to the player object
    private float spawnRangeZ = 8;
    private float spawnOffsetX = 10; // Offset to ensure spawning farther right from the player
    private float spawnPosY = 0; // Assuming Z position for obstacles to be on the floor
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    private PlayerController playerControllerscript;
    private float repeatRate;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerscript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnRandomObstacle", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnRandomObstacle();
        }
    }

    void SpawnRandomObstacle()
    {
        int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);

        float spawnPosX = player.position.x + spawnOffsetX + Random.Range(-spawnRangeZ, spawnRangeZ);
        Vector3 spawnPos = new Vector3(spawnPosX, 0, spawnPosY);

        Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);
    }
}
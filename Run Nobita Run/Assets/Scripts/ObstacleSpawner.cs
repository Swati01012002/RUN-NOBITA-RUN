using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private float spawnInterval = 7.56f;
    private float lastSpawnZ = 10f;
    private int spawnAmount = 10;

    public List<GameObject> obstacles;
    // Start is called before the first frame update
    void Start()
    {
       for(int i = 0; i< spawnAmount; i++)
        {
            SpawnObstacles();
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObstacles()
    {
        GameObject obstacle = obstacles[Random.Range(0, obstacles.Count)];
        float zPos = lastSpawnZ + spawnInterval;
        Instantiate(obstacle, new Vector3(0, 0f, zPos), obstacle.transform.rotation);

        lastSpawnZ += spawnInterval;
    } 
}

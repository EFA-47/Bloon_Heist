using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnManagaer : MonoBehaviour
{
    public GameObject[] obstacles;
    private Vector3 spawnPoint;
    private Quaternion rotation;
    float time;
    float spawnTimer = 2;
    int randomObstacle;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = transform.position;
        rotation = Quaternion.Euler(new Vector3(0,0,0));
        time = -spawnTimer;
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - time > spawnTimer ){
            time = Time.time;
            if(playerControllerScript.gameOver == false){
                SpawnObstacle();
            }
            
        }
    }

    private void SpawnObstacle(){
        randomObstacle = Random.Range(0,obstacles.Length);
        Instantiate(obstacles[randomObstacle], spawnPoint, rotation);
    }
}

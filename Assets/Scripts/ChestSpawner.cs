using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawner : MonoBehaviour{
    public Transform spawnPoints;
    public GameObject chestPrefab;

    public float nextActionTime = 0.0f;
    public float period = 30f;

    private void OnEnable(){
        nextActionTime = Time.time + period;
    }

    void Update(){
        if (Time.time > nextActionTime){
                nextActionTime += period;
                Instantiate(chestPrefab, spawnPoints.GetComponent<SpawnPoints>().spawnPoints[Random.Range(0, 16)].position, Quaternion.identity);
        }
    }
}

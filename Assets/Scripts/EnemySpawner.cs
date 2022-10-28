using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour{
    public Transform spawnPoints;
    public GameObject enemiesPrefab;

    private float nextActionTime = 0.0f;
    public float period = 1f;

    private void OnEnable(){
        nextActionTime = Time.time;
    }

    void Update(){
        if (Time.time > nextActionTime){
            nextActionTime += period;
            Instantiate(enemiesPrefab, spawnPoints.GetComponent<SpawnPoints>().spawnPoints[Random.Range(0, 16)].position, Quaternion.identity);
        }
    }
}

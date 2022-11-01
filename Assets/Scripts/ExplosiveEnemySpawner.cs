using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveEnemySpawner : MonoBehaviour{
    public Transform spawnPoints;
    public GameObject enemiesPrefab;
    public int count = 0;

    public float nextActionTime = 0.0f;
    public float period = 1f;

    private void OnEnable(){
        nextActionTime = Time.time;
    }

    void Update(){
        if (Time.time > nextActionTime){
            if (count < 2){
                nextActionTime += period;
                GameObject e =Instantiate(enemiesPrefab, spawnPoints.GetComponent<SpawnPoints>().spawnPoints[Random.Range(0, 16)].position, Quaternion.identity);
                e.GetComponent<ExplosiveEnemy>().explosiveEnemySpawner = this;
                count++;
            }
        }
    }
}

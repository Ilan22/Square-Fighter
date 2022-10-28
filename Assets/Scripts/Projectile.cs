using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour{
    public int piercingShots;
    private int reShot;
    public float projectileForce = 20f;

    private void Start(){
        piercingShots = PlayerPrefs.GetInt("piercingshots", 0);
        reShot = PlayerPrefs.GetInt("reshot", 0);
    }

    private void Update(){
        if (!GetComponent<SpriteRenderer>().isVisible)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.transform.tag == "Enemy"){
            collider.GetComponent<EnemyBehaviour>().hit(5);
            if (piercingShots == 0){
                if (reShot > 0){
                    Vector3 direction = Random.insideUnitSphere;
                    direction.z = 0;
                    Debug.Log(direction);
                    GetComponent<Rigidbody2D>().velocity = direction.normalized * projectileForce;

                    reShot = 0;
                }
                else
                    Destroy(gameObject);
            }
            else
                piercingShots--;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nova : MonoBehaviour{
    private float nextActionTime = 0.0f;
    public float period = 4f;
    public float projectileForce = 20f;

    public GameObject projectilePrefab;

    private void OnEnable(){
        nextActionTime = Time.time;
    }

    void Update(){
        if (Time.time > nextActionTime){
            nextActionTime += period;
            Vector2[] points = { new Vector2(0, 1),
                new Vector2(1, 1),
                new Vector2(1, 0),
                new Vector2(1, -1),
                new Vector2(0, -1),
            new Vector2(-1, -1),
            new Vector2(-1, 0),
            new Vector2(-1, 1)
            };
            for (int i = 0; i < points.Length; i++){
                GameObject projectile = Instantiate(projectilePrefab);
                projectile.transform.position = transform.position;
                projectile.GetComponent<Rigidbody2D>().velocity = points[i] * projectileForce;
            }
        }
    }
}

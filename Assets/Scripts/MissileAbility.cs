using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileAbility : MonoBehaviour
{
    private float nextActionTime = 0.0f;
    private float period = 3f;
    public float projectileForce;

    public GameObject projectilePrefab;

    private void OnEnable(){
        nextActionTime = Time.time;
    }

    void Update(){
        if (Time.time > nextActionTime){
            nextActionTime += period;

            GameObject projectile = Instantiate(projectilePrefab);
            projectile.transform.position = transform.position;
            projectile.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Random.Range(0,361));
            projectile.GetComponent<Rigidbody2D>().velocity = projectile.transform.GetChild(0).position.normalized * projectileForce;
        }
    }
}

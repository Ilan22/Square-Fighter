using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileExplosiveEnemy : MonoBehaviour{
    public float projectileForce = 20f;

    private void Update(){
        if (!GetComponent<SpriteRenderer>().isVisible)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.transform.tag == "Player") {
            GameObject.Find("GameManager").GetComponent<PlayerLife>().hit(1);
            Destroy(gameObject);
        }
    }
}

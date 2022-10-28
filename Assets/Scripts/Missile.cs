using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour{
    public float attackRadius;

    private void Update(){
        if (!GetComponent<SpriteRenderer>().isVisible)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.transform.tag == "Enemy"){
            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, attackRadius, LayerMask.GetMask("Enemy"));

            if (enemies is not null)
                foreach (Collider2D c in enemies){
                    if (c.gameObject.scene.IsValid())
                        c.GetComponent<EnemyBehaviour>().hit(5);
                    Destroy(gameObject);
                }
        }
    }
}

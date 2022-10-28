using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroundZone : MonoBehaviour{
    public GameObject xpOrb;
    private float nextActionTime = 0.0f;
    private float period = .75f;

    public float attackRadius;

    private void OnEnable(){
        nextActionTime = Time.time;
    }

    private void Update(){
        if (Time.time >= nextActionTime){
            nextActionTime += period;

            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, attackRadius, LayerMask.GetMask("Enemy"));

            if (enemies is not null)
                foreach (Collider2D c in enemies)
                    if (c.gameObject.scene.IsValid())
                        c.GetComponent<EnemyBehaviour>().hit(2);
        }
    }
}

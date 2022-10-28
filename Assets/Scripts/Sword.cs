using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour{
    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.transform.tag == "Enemy"){
            collider.GetComponent<EnemyBehaviour>().hit(5);
        }
    }
}

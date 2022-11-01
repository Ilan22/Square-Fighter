using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour{
    public GameObject[] coinAndHeart;

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "Player"){
            bool heart = false;
            for (int i = 0; i < Random.Range(2, 6); i++){
                GameObject c;
                if (!heart && Random.Range(1, 21) == 10)
                {
                    c = Instantiate(coinAndHeart[1], transform.position, Quaternion.identity);
                    heart = true;
                }
                else
                    c = Instantiate(coinAndHeart[0], transform.position, Quaternion.identity);

                Vector2 dir = (transform.position - collision.transform.position).normalized;
                c.GetComponent<Rigidbody2D>().AddForce((dir * 3000) + new Vector2(Random.Range(-4000, 4000), Random.Range(-4000, 4000)));
                c.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-2000, 2000));
            }
            Camera.main.GetComponent<CameraFollow>().ShakeOnce(0.3f, 1f);
            Destroy(gameObject);
        }
    }
}

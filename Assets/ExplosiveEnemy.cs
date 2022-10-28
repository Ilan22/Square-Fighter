using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveEnemy : MonoBehaviour{
    private Transform player;
    public float radius = 4f;
    public GameObject projectilePrefab;
    public float projectileForce = 20f;

    private float nextActionTime = 0.0f;
    public float period = 4f;

    private bool active = true;

    public ExplosiveEnemySpawner explosiveEnemySpawner;

    private void OnDestroy(){
        explosiveEnemySpawner.count--;
        if (explosiveEnemySpawner.count == 0)
            explosiveEnemySpawner.nextActionTime = Time.time;
    }

    private void Start(){
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update(){
        if ((player.position - transform.position).magnitude <= radius && Time.time > nextActionTime && active){
            this.GetComponent<EnemyBehaviour>().speed = 0f;
            StartCoroutine(FlashSprites(GetComponent<SpriteRenderer>(), 4, 0.1f));
            StartCoroutine(shot(1));
        }
    }

    IEnumerator FlashSprites(SpriteRenderer sprites, int numTimes, float delay, bool disable = false){
        for (int loop = 0; loop < numTimes; loop++){
            if (disable)
                sprites.enabled = false;
            else
                sprites.color = new Color(sprites.color.r, sprites.color.g, sprites.color.b, 0.5f);

            yield return new WaitForSeconds(delay);

            if (disable)
                sprites.enabled = true;
            else
                sprites.color = new Color(sprites.color.r, sprites.color.g, sprites.color.b, 1);

            yield return new WaitForSeconds(delay);
        }
    }

    IEnumerator shot(float time){
        active = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(time);

        Vector2[] points = { new Vector2(0, 1), new Vector2(0, -1), new Vector2(1, 0), new Vector2(-1, 0) };
        for (int i = 0; i < 4; i++){
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.transform.position = transform.position;
            projectile.GetComponent<Rigidbody2D>().velocity = points[i] * projectileForce;
        }
        this.GetComponent<EnemyBehaviour>().speed = 4f;
        active = true;
        nextActionTime = Time.time + period;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

    }
}

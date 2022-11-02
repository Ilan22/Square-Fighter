using UnityEngine;

public class RadiusAttack : MonoBehaviour{
    public GameObject projectilePrefab;

    public float attackRadius = 6f;
    public float projectileForce = 20f;
    private float nextActionTime = 0.0f;

    private void Update(){
        if (Time.time > nextActionTime){
            nextActionTime += PlayerPrefs.GetFloat("shootSpeed", 2);

            switch(PlayerPrefs.GetInt("nbbullet", 1)){
                case 1:
                    one();
                    break;
                case 2:
                    two();
                    break;
                case 3:
                    three();
                    break;
            }
        }
    }

    private void one(){
        Transform enemyToAttack = null;
        float closestEnemyDistance = Mathf.Infinity;
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, attackRadius, LayerMask.GetMask("Enemy"));
        if (enemies.Length > 0){
            foreach (Collider2D enemy in enemies){
                if ((enemy.transform.position - transform.position).sqrMagnitude < closestEnemyDistance){
                    closestEnemyDistance = (enemy.transform.position - transform.position).sqrMagnitude;
                    enemyToAttack = enemy.transform;
                }
            }
            Vector3 difference = enemyToAttack.position - transform.position;
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            direction.Normalize();
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.transform.position = transform.position;
            projectile.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
        }
    }

    private void two(){
        Transform[] enemyToAttack = new Transform[2];
        float closestEnemyDistance = Mathf.Infinity;
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, attackRadius, LayerMask.GetMask("Enemy"));
        if (enemies.Length > 0){
            foreach (Collider2D enemy in enemies){
                if ((enemy.transform.position - transform.position).sqrMagnitude < closestEnemyDistance){
                    closestEnemyDistance = (enemy.transform.position - transform.position).sqrMagnitude;
                    enemyToAttack[1] = enemyToAttack[0];
                    enemyToAttack[0] = enemy.transform;
                }
            }
            foreach (Transform enemy in enemyToAttack){
                if (enemy is not null){
                    Vector3 difference = enemy.position - transform.position;
                    float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                    float distance = difference.magnitude;
                    Vector2 direction = difference / distance;
                    direction.Normalize();
                    GameObject projectile = Instantiate(projectilePrefab);
                    projectile.transform.position = transform.position;
                    projectile.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
                    projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
                }
            }
        }
    }

    private void three()
    {
        Transform[] enemyToAttack = new Transform[3];
        float closestEnemyDistance = Mathf.Infinity;
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, attackRadius, LayerMask.GetMask("Enemy"));
        if (enemies.Length > 0)
        {
            foreach (Collider2D enemy in enemies)
            {
                if ((enemy.transform.position - transform.position).sqrMagnitude < closestEnemyDistance)
                {
                    closestEnemyDistance = (enemy.transform.position - transform.position).sqrMagnitude;
                    enemyToAttack[2] = enemyToAttack[1];
                    enemyToAttack[1] = enemyToAttack[0];
                    enemyToAttack[0] = enemy.transform;
                }
            }
            foreach (Transform enemy in enemyToAttack)
            {
                if (enemy is not null)
                {
                    Vector3 difference = enemy.position - transform.position;
                    float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                    float distance = difference.magnitude;
                    Vector2 direction = difference / distance;
                    direction.Normalize();
                    GameObject projectile = Instantiate(projectilePrefab);
                    projectile.transform.position = transform.position;
                    projectile.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
                    projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
                }
            }
        }
    }
}

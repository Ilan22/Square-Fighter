using UnityEngine;

public class EnemyBehaviour : MonoBehaviour{
    private Transform player;
    public Rigidbody2D rb;
    public GameObject xpOrb;
    public GameObject explosionParticles;

    public int xpAmount;

    public float speed;
    public int life = 5;

    private void Start(){
        player = GameObject.Find("Player").transform;
    }

    void FixedUpdate(){
        rb.MovePosition(Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime));
    }

    private float coloNumberConversion(float num)
    {
        return (num / 255.0f);
    }

    public void hit(int amount){
        if (life - amount > 0)
            life -= amount;
        else{
            SpawnXP();
            ParticleSystem ps = Instantiate(explosionParticles, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();

            var col = ps.colorOverLifetime;
            col.enabled = true;

            Gradient grad = new Gradient();
            Color color = new Color();
            if (this.name.Contains("1"))
                color = new Color(coloNumberConversion(22), coloNumberConversion(184), coloNumberConversion(255));
            else if (this.name.Contains("2"))
                color = new Color(coloNumberConversion(174), coloNumberConversion(28), coloNumberConversion(30));
            else if (this.name.Contains("3"))
                color = new Color(coloNumberConversion(103), coloNumberConversion(247), coloNumberConversion(7));

            grad.SetKeys(new GradientColorKey[] { new GradientColorKey(color, 0.0f), new GradientColorKey(Color.white, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 1.0f) });

            col.color = grad;


            Destroy(gameObject);
        }
    }

    private void SpawnXP(){
        if (Random.Range(0, 101) < 60){
            GameObject g = Instantiate(xpOrb, transform.position, Quaternion.identity);
            g.GetComponent<XP>().xpAmount = xpAmount;
            switch (gameObject.name){
                case "1(Clone)":
                    g.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("xpOrbs/xpOrb1");
                    break;
                case "2(Clone)":
                    g.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("xpOrbs/xpOrb2");
                    break;
            }
        }
    }
}

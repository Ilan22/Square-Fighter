using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour{
    public PauseController pauseController;
    public PlayerLife playerLife;
    public CoinCollector coinCollector;
    public GameObject[] spawners;
    public GameObject[] particles;

    public Text lvlText;

    public int xpAmount = 0;
    public int level = 1;
    public int xpNeeded = 5;

    private bool attackable = true;

    public Bar bar;

    private void Start(){
        xpNeeded = 5;
        bar.setMaxValue(xpNeeded);
        PlayerPrefs.SetInt("enemylife", 0);
    }

    public void addXP(int amount){
        xpAmount += amount;
        if (xpAmount >= xpNeeded){
            level++;
            lvlText.text = level.ToString();
            xpAmount -= xpNeeded;
            xpNeeded = Mathf.RoundToInt(xpNeeded * 1.25f);
            bar.setMaxValue(xpNeeded);
            pauseController.pause();
            if (level % 5 == 0){
                PlayerPrefs.SetInt("enemylife", PlayerPrefs.GetInt("enemylife", 0) + 1);
                if (level == 5)
                    spawners[0].SetActive(true);
                else if (level == 10)
                    spawners[1].SetActive(true);
            }
        }
        bar.setValue(xpAmount);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "XP"){
            addXP(collision.GetComponent<XP>().xpAmount);
            Destroy(collision.gameObject);
        }else if (collision.tag == "Enemy"&& attackable){
            playerLife.hit(1);
            attackable = false;
            StartCoroutine(setAttackable(1));
            Camera.main.GetComponent<CameraFollow>().ShakeOnce(0.3f, .5f);
        }else if (collision.tag == "Coin"){
            coinCollector.add(1);
            Destroy(collision.gameObject);
            Instantiate(particles[0], transform.position, Quaternion.identity);
            Camera.main.GetComponent<CameraFollow>().ShakeOnce(0.3f, .5f);
        }else if (collision.tag == "Heart"){
            playerLife.heartCollected();
            Destroy(collision.gameObject);
            Instantiate(particles[1], transform.position, Quaternion.identity);
            Camera.main.GetComponent<CameraFollow>().ShakeOnce(0.3f, .5f);
        }else if (collision.tag == "Chest"){
            addXP(Mathf.RoundToInt(xpNeeded / 4f));
        }

    }

    IEnumerator setAttackable(float time){
        yield return new WaitForSeconds(time);
        attackable = true;
    }
}

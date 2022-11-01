using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public int life;
    public int maxLife;

    public Bar bar;

    private void Start()
    {
        life = 3;
        maxLife = 3;
    }

    public void hit(int amount){
        if (life > 0) life -= amount;
        bar.setValue(life);
        PlayerPrefs.SetInt("life", life);
    }

    public void addLife(){
        life = PlayerPrefs.GetInt("life", 3);
        maxLife = PlayerPrefs.GetInt("maxlife", 3);
        bar.setMaxValue(maxLife);
        bar.setValue(life);
    }

    public void heartCollected(){
        if (PlayerPrefs.GetInt("life", 3) < PlayerPrefs.GetInt("maxlife", 3)){
            life = PlayerPrefs.GetInt("life", 3) + 1;
            PlayerPrefs.SetInt("life", life);
            bar.setValue(life);
        }
    }
}

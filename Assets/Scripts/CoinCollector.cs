using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour{
    private int coins;
    public Text text;

    public void add(int amount){
        coins += amount;
        text.text = coins.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addAbility : MonoBehaviour
{
    public AroundSwords aroundSwords;
    public GameObject missileAbility;
    public GameObject novaAbility;
    public GameObject[] aroundZones;
    public PlayerLife playerLife;

    private void Start(){
        PlayerPrefs.SetFloat("shootSpeed", 2);
        PlayerPrefs.SetInt("nbbullet", 1);
        PlayerPrefs.SetInt("piercingshots", 0);
        PlayerPrefs.SetInt("aroundswords", 0);
        PlayerPrefs.SetInt("aroundswordsspeed", -70);
        PlayerPrefs.SetInt("missile", 0);
        PlayerPrefs.SetInt("aroundzone", 0);
        PlayerPrefs.SetFloat("xpmagnet", 0.5f);
        PlayerPrefs.SetInt("life", 3);
        PlayerPrefs.SetInt("maxlife", 3);
        PlayerPrefs.SetInt("reshot", 0);
        PlayerPrefs.SetInt("nova", 0);
        PlayerPrefs.SetInt("playerstrength", 0);
    }

    public void add(int choice){
        switch (choice){
            case 1:
                PlayerPrefs.SetFloat("shootSpeed", PlayerPrefs.GetFloat("shootSpeed", 2) - .5f);
                break;
            case 2:
                PlayerPrefs.SetInt("nbbullet", PlayerPrefs.GetInt("nbbullet", 1) + 1);
                break;
            case 3:
                PlayerPrefs.SetInt("piercingshots", PlayerPrefs.GetInt("piercingshots", 0) + 1);
                break;
            case 4:
                aroundSwords.ActivateSword(PlayerPrefs.GetInt("aroundswords"));
                PlayerPrefs.SetInt("aroundswords", PlayerPrefs.GetInt("aroundswords", 0) + 1);
                break;
            case 5:
                PlayerPrefs.SetInt("aroundswordsspeed", PlayerPrefs.GetInt("aroundswordsspeed", -70) - 30);
                break;
            case 6:
                missileAbility.SetActive(true);
                PlayerPrefs.SetInt("missile", PlayerPrefs.GetInt("missile", 0) + 1);
                break;
            case 7:
                int zoneActuelle = PlayerPrefs.GetInt("aroundzone", 0);
                PlayerPrefs.SetInt("aroundzone", zoneActuelle + 1);
                if (zoneActuelle > 0){
                    aroundZones[PlayerPrefs.GetInt("aroundzone", 0) - 2].SetActive(false);
                }
                aroundZones[PlayerPrefs.GetInt("aroundzone", 0) - 1].SetActive(true);
                break;
            case 8:
                PlayerPrefs.SetFloat("xpmagnet", PlayerPrefs.GetFloat("xpmagnet", 0.5f) + 1f);
                break;
            case 9:
                PlayerPrefs.SetInt("life", PlayerPrefs.GetInt("life", 3) + 1);
                PlayerPrefs.SetInt("maxlife", PlayerPrefs.GetInt("maxlife", 3) + 1);
                playerLife.addLife();
                break;
            case 10:
                PlayerPrefs.SetInt("reshot", PlayerPrefs.GetInt("reshot", 0) + 1);
                break;
            case 11:
                novaAbility.SetActive(true);
                PlayerPrefs.SetInt("nova", PlayerPrefs.GetInt("nova", 0) + 1);
                break;
            case 15:
                PlayerPrefs.SetInt("playerstrength", PlayerPrefs.GetInt("playerstrength", 0) + 1);
                break;
        }
    }
}

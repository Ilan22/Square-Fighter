using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceGenerator : MonoBehaviour{
    public Transform[] choices = new Transform[3];

    public void generate(){
        List<int> possibleChoices = new List<int>();
        if (PlayerPrefs.GetFloat("shootSpeed", 2) > .5f)
            possibleChoices.Add(1);
        if (PlayerPrefs.GetInt("nbbullet", 1) < 3)
            possibleChoices.Add(2);
        if (PlayerPrefs.GetInt("piercingshots", 0) < 2)
            possibleChoices.Add(3);
        if (PlayerPrefs.GetInt("aroundswords", 0) < 4)
            possibleChoices.Add(4);
        if (PlayerPrefs.GetInt("aroundswords", 0) > 0 && PlayerPrefs.GetInt("aroundswordsspeed", -70) > -130)
            possibleChoices.Add(5);
        if (PlayerPrefs.GetInt("missile", 0) < 1)
            possibleChoices.Add(6);
        if (PlayerPrefs.GetInt("aroundzone", 0) < 3)
            possibleChoices.Add(7);
        if (PlayerPrefs.GetFloat("xpmagnet", 0.5f) < 3.5f)
            possibleChoices.Add(8);
        if (PlayerPrefs.GetInt("maxlife", 3) < 5)
            possibleChoices.Add(9);
        if (PlayerPrefs.GetInt("reshot", 0) < 1)
            possibleChoices.Add(10);

        possibleChoices.Add(15);

        if (possibleChoices.Count < 3){
            for(int i = 0; i <= 3 - possibleChoices.Count; i++)
                possibleChoices.Add(15);
        }

        for (int i = 0; i <= 2; i++){
            int random = Random.Range(0, possibleChoices.Count);
            choices[i].GetComponent<chooseAbility>().choice = possibleChoices[random];
            choices[i].GetChild(0).GetComponent<Text>().text = possibleChoices[random].ToString();
            possibleChoices.RemoveAt(random);
        }
    }
}
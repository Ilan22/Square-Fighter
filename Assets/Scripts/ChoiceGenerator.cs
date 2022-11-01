using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice{
    public Choice(int number, string display, int fontSize, string secondary)
    {
        this.number = number;
        this.display = display;
        this.fontSize = fontSize;
        this.secondary = secondary;
    }

    public int number;
    public string display;
    public int fontSize;
    public string secondary;
}

public class ChoiceGenerator : MonoBehaviour{
    public Transform[] choices = new Transform[3];

    public void generate(){
        List<Choice> possibleChoices = new();

        float shootSpeed = PlayerPrefs.GetFloat("shootSpeed", 2);
        if (shootSpeed > .5f){
            int actual = 0;
            int next = 1;
            if (shootSpeed == 1.5f){
                actual = 1;
                next = 2;
            }else if (shootSpeed == 1f){
                actual = 2;
                next = 3;
            }
            possibleChoices.Add(new Choice(1, "FIRE RATE", 100, "<color=red>" + actual + "</color>→<color=green>" + next + "</color>"));
        }

        int nbbullet = PlayerPrefs.GetInt("nbbullet", 1);
        if (nbbullet < 3){
            int actual = 1;
            int next = 2;
            if (nbbullet == 2){
                actual = 2;
                next = 3;
            }
            possibleChoices.Add(new Choice(2, "BULLET NUMBER", 80, "<color=red>" + actual + "</color>→<color=green>" + next + "</color>"));
        }

        int piercingshots = PlayerPrefs.GetInt("piercingshots", 0);
        if (piercingshots < 2){
            int actual = 0;
            int next = 1;
            if (piercingshots == 1){
                actual = 1;
                next = 2;
            }
            possibleChoices.Add(new Choice(3, "PIERCING SHOT", 70, "<color=red>" + actual + "</color>→<color=green>" + next + "</color>"));
        }

        int aroundswords = PlayerPrefs.GetInt("aroundswords", 0);
        if (aroundswords < 4){
            int actual = 0;
            int next = 1;
            if (aroundswords == 1){
                actual = 1;
                next = 2;
            }else if (aroundswords == 2){
                actual = 2;
                next = 3;
            }else if (aroundswords == 3){
                actual = 3;
                next = 4;
            }
            possibleChoices.Add(new Choice(4, "SWORDS", 80, "<color=red>" + actual + "</color>→<color=green>" + next + "</color>"));
        }

        int aroundswordsspeed = PlayerPrefs.GetInt("aroundswordsspeed", -70);
        if (aroundswords > 0 && aroundswordsspeed > -130){
            int actual = 0;
            int next = 1;
            if (aroundswordsspeed == -100){
                actual = 1;
                next = 2;
            }
            possibleChoices.Add(new Choice(5, "SWORDS SPEED", 80, "<color=red>" + actual + "</color>→<color=green>" + next + "</color>"));
        }

        int missile = PlayerPrefs.GetInt("missile", 0);
        if (missile < 1){
            int actual = 0;
            int next = 1;
            possibleChoices.Add(new Choice(6, "MISSILE", 80, "<color=red>" + actual + "</color>→<color=green>" + next + "</color>"));
        }

        int aroundzone = PlayerPrefs.GetInt("aroundzone", 0);
        if (aroundzone < 3){
            int actual = 0;
            int next = 1;
            if (aroundzone == 1){
                actual = 1;
                next = 2;
            }else if (aroundzone == 2){
                actual = 2;
                next = 3;
            }
            possibleChoices.Add(new Choice(7, "AURA", 100, "<color=red>" + actual + "</color>→<color=green>" + next + "</color>"));
        }

        float xpmagnet = PlayerPrefs.GetFloat("xpmagnet", 0.5f);
        if (xpmagnet < 3.5f){
            int actual = 0;
            int next = 1;
            if (xpmagnet == 1.5f){
                actual = 1;
                next = 2;
            }else if (xpmagnet == 2.5f){
                actual = 2;
                next = 3;
            }
            possibleChoices.Add(new Choice(8, "XP MAGNET", 80, "<color=red>" + actual + "</color>→<color=green>" + next + "</color>"));
        }

        int maxlife = PlayerPrefs.GetInt("maxlife", 3);
        if (maxlife < 5){
            int actual = 0;
            int next = 1;
            if (maxlife == 4){
                actual = 1;
                next = 2;
            }
            possibleChoices.Add(new Choice(9, "MAX LIFE", 100, "<color=red>" + actual + "</color>→<color=green>" + next + "</color>"));
        }

        int reshot = PlayerPrefs.GetInt("reshot", 0);
        if (reshot < 1){
            int actual = 0;
            int next = 1;
            possibleChoices.Add(new Choice(10, "LAST BULLET RE SHOOT", 70, "<color=red>" + actual + "</color>→<color=green>" + next + "</color>"));
        }

        int nova = PlayerPrefs.GetInt("nova", 0);
        if (nova < 1){
            int actual = 0;
            int next = 1;
            possibleChoices.Add(new Choice(11, "nova", 100, "<color=red>" + actual + "</color>→<color=green>" + next + "</color>"));
        }

        int actualStrength = PlayerPrefs.GetInt("playerstrength", 0);
        int nextStrength = actualStrength + 1;
        Choice strength = new Choice(15, "STRENGTH", 60, "<color=red>" + actualStrength + "</color>→<color=green>" + nextStrength + "</color>");
        possibleChoices.Add(strength);

        if (possibleChoices.Count < 3){
            for(int i = 0; i <= 3 - possibleChoices.Count; i++)
                possibleChoices.Add(strength);
        }

        for (int i = 0; i <= 2; i++){
            int random = Random.Range(0, possibleChoices.Count);
            choices[i].GetComponent<chooseAbility>().choice = possibleChoices[random].number;
            choices[i].GetChild(0).GetComponent<Text>().text = possibleChoices[random].display;
            choices[i].GetChild(0).GetComponent<Text>().fontSize = possibleChoices[random].fontSize;
            choices[i].GetChild(1).GetComponent<Text>().text = possibleChoices[random].secondary;
            possibleChoices.RemoveAt(random);
        }
    }
}
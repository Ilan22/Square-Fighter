using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroundSwords : MonoBehaviour{
    public GameObject xpOrb;

    void Update(){
        transform.Rotate(0,0,PlayerPrefs.GetInt("aroundswordsspeed", -70) * Time.deltaTime);
    }

    public void ActivateSword(int sword){
        transform.GetChild(sword).gameObject.SetActive(true);
    }
}

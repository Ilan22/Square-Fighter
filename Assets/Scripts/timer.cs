using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Text text;
    private float time = 0f;

    void Update()
    {
        time += Time.deltaTime;

        string minutes = Mathf.Floor(time / 60).ToString("00");
        string seconds = Mathf.Floor(time % 60).ToString("00");

        text.text = string.Format("{0}:{1}", minutes, seconds);
    }
}

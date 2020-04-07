using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float countdowntime;
    public GameObject text;
    float timeleft;
    int minutes;
    int seconds;
    string str_minutes;
    string str_seconds;

    void Start()
    {
        StartCoroutine(countDown(countdowntime));
    }

    private IEnumerator countDown(float timer)
    {
        timeleft = timer;
        while (timeleft > 0)
        {
            timeCalculator();
            text.GetComponent<Text>().text = str_minutes + " : " + str_seconds;
            yield return new WaitForSeconds(1.0f);
            timeleft--;
        }

    }

    void timeCalculator()
    {
        minutes = (int)timeleft / 60;
        seconds = (int)timeleft % 60;
        str_minutes = "" + minutes;
        str_seconds = "" + seconds;
        if (minutes < 10)
        {
            str_minutes = "0" + minutes;
        }
        if (seconds < 10)
        {
            str_seconds = "0" + seconds;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public Color red;
    public Color white;
    public Color yellow;
    public Color blue;
    public Color black;

    public Color currentColor;

    public string detonate;
    public string abort;
    public string hold;
    public string press;

    public string currentString;

    int randomRoller;

    public bool complete;

    // Start is called before the first frame update
    void Start()
    {
        complete = false;

        //Generate Color & Word on Bomb
        randomRoller = Random.Range(1, 6);
        if (randomRoller == 1)
        {
            currentColor = red;
        }
        else if (randomRoller == 2)
        {
            currentColor = white;
        }
        else if (randomRoller == 3)
        {
            currentColor = yellow;
        }
        else if (randomRoller == 4)
        {
            currentColor = blue;
        }
        else
        {
            currentColor = black;
        }

        randomRoller = Random.Range(1, 5);
        if (randomRoller == 1)
        {
            currentString = detonate;
        }
        else if (randomRoller == 2)
        {
            currentString = abort;
        }
        else if (randomRoller == 3)
        {
            currentString = hold;
        }
        else
        {
            currentString = press;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Functionaltiy based on what is on bomb and what color and word there is
        if (currentString == detonate)
        {
            //if there is more than one battery, press and immediately release
            //else, hold
        }
        else if (currentColor == red && currentString == hold)
        {
            //press and immediately release
        }
        //else if (lit indicator FRK)
        //if there are more than two batteries, press and immediately release
        //else, hold
        else
        {
            //holding instructions
        }
    }
}

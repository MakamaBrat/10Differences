using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Timetext : MonoBehaviour
{
    string time;
    int minute;
    public Text text;
    void Start()
    {
        totime();
        minute = DateTime.Now.Minute;
    }

    // Update is called once per frame
    void Update()
    {if (minute != DateTime.Now.Minute)
        {
            totime();
            minute = minute = DateTime.Now.Minute;
        }
    }

    public void totime()
    {
        string hour;
        string min;
        if (DateTime.Now.Hour < 10)
        { hour = "0" + DateTime.Now.Hour.ToString(); }
        else { hour = DateTime.Now.Hour.ToString(); }
        if (DateTime.Now.Minute < 10)
        { min = "0" + DateTime.Now.Minute.ToString(); }
        else { min = DateTime.Now.Minute.ToString(); }


        text.text = hour + ":" + min; 
     
    }
}

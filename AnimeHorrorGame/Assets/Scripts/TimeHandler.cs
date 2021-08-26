using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeHandler : MonoBehaviour
{
    public static TimeHandler _instance;

    float time, tick;
    [SerializeField]
    float minutesInterval;

    const int DEFAULT_HOURS = 7;
    const int DEFAULT_MINUTES = 25;

    static int hours,minutes;

    public static int getHours { get { return hours; } }

    public static int getMinutes { get { return minutes; } }

    public event Action<int,int> onTimeChanged;

    void Awake()
    {
        _instance = this;
        time = (int)Time.time;
        tick = minutesInterval;
        hours = DEFAULT_HOURS;
        minutes = DEFAULT_MINUTES;
    }

    void Update()
    {
        time = (int)Time.time;
        if (time == tick)
        {
            minutes++;
            tick = time + minutesInterval;
            onTimeChanged(getHours,getMinutes);
            Debug.Log("//TIME HANDLER// (+1) Minute | NOW AT > " + getMinutes + " MINUTES");
            if (minutes == 60)
            {
                minutes = 0;
                hours++;
                onTimeChanged(getHours, getMinutes);
                Debug.Log("//TIME HANDLER// (+1) Hour | NOW AT > " + getHours + " HOUR(S)");
            }
        }
    }
}

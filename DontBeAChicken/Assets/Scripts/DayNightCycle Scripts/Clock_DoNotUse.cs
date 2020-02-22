using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock_DoNotUse : MonoBehaviour
{

    public Transform hourHand;
    public Transform minuteHand;

    float hoursToDegrees = 360f / 12f;
    float minutesToDegrees = 360f / 60f;
    DayNightCycle_Script controller;
    

    void Awake()
    {
        controller = GameObject.Find("DayNightController").GetComponent<DayNightCycle_Script>();
    }

    void Update()
    {
        float currentHour = 24 * controller.currentTimeOfDay;
        float currentMinute = 60 * (currentHour - Mathf.Floor(currentHour));

        hourHand.localRotation = Quaternion.Euler(currentHour * hoursToDegrees, 0, 0);
        minuteHand.localRotation = Quaternion.Euler(currentMinute * minutesToDegrees, 0, 0);
    }
}
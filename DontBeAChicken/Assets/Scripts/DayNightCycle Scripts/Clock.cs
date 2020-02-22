using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{

    [SerializeField] private Text Hours;
    [SerializeField] private Text Days;
    private DayNightCycle_Script DnN;

    void Start()
    {
        DnN = GetComponent<DayNightCycle_Script>();
        Hours = transform.Find("HoursText").GetComponent<Text>();
        Days = transform.Find("DaysText").GetComponent<Text>();

    }
    void Update()
    {

        // metratepei tis metablites int se string
        string HourString = DnN.Hourspassed.ToString("00");
        string MinutesString = DnN.minutesPassed.ToString("00");

        // emfaniszei tis metablites stin i8oni
        Hours.text = HourString + " : " + MinutesString;
        Days.text = DnN.Dayspassed.ToString();
    }
}
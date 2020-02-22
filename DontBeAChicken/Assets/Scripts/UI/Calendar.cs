using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar : MonoBehaviour
{
    [SerializeField] Transform Arrow_UI;
    [SerializeField] GameObject SunnyWeather_UI;
    [SerializeField] GameObject StormyWeather_UI;

    [Header("ArrowPoints")]
    [SerializeField] private Transform Sunday_Point;
    [SerializeField] private Transform Monday_Point;
    [SerializeField] private Transform Tuesday_Point;
    [SerializeField] private Transform Wednesday_Point;
    [SerializeField] private Transform Thursday_Point;
    [SerializeField] private Transform Friday_Point;
    [SerializeField] private Transform Saturday_Point;

    //private DayNightCycle_Script dayNightCycle_Script;
    private static Calendar _instance;

    public static Calendar GetInstance() { return _instance; }

    private void Awake()
    {
        //dayNightCycle_Script = FindObjectOfType<DayNightCycle_Script>();
        if (!_instance)
        {
            _instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //UpdateArrowsPosition();
    }

    public void UpdateArrowsPosition()
    {
        #region Old Yandere code
        //if (dayNightCycle_Script.DaysCount == 1)
        //{
        //    Arrow_UI.position = Vector2.MoveTowards(Arrow_UI.position, Monday_Point.position, 7.0f);
        //}
        //if (dayNightCycle_Script.DaysCount == 2)
        //{
        //    Arrow_UI.position = Vector2.MoveTowards(Arrow_UI.position, Tuesday_Point.position, 7.0f);
        //}
        //if (dayNightCycle_Script.DaysCount == 2)
        //{
        //    Arrow_UI.position = Vector2.MoveTowards(Arrow_UI.position, Tuesday_Point.position, 7.0f);
        //} 
        #endregion


        switch (DayNightCycle_Script.GetInstance().DaysCount)
        {
            case 1: // Monday

                Arrow_UI.position = Vector2.MoveTowards(Arrow_UI.position, Monday_Point.position, 7.0f);
                SunnyWeather_UI.SetActive(true);
                StormyWeather_UI.SetActive(false);

                break;

            case 2: // Tuesday

                Arrow_UI.position = Vector2.MoveTowards(Arrow_UI.position, Tuesday_Point.position, 7.0f);
                SunnyWeather_UI.SetActive(true);
                StormyWeather_UI.SetActive(false);

                break;

            case 3: // Wednesday

                Arrow_UI.position = Vector2.MoveTowards(Arrow_UI.position, Wednesday_Point.position, 7.0f);
                SunnyWeather_UI.SetActive(false);
                StormyWeather_UI.SetActive(true);

                break;

            case 4: // Thursday

                Arrow_UI.position = Vector2.MoveTowards(Arrow_UI.position, Thursday_Point.position, 7.0f);
                SunnyWeather_UI.SetActive(true);
                StormyWeather_UI.SetActive(false);

                break;

            case 5: // Friday

                Arrow_UI.position = Vector2.MoveTowards(Arrow_UI.position, Friday_Point.position, 7.0f);
                SunnyWeather_UI.SetActive(true);
                StormyWeather_UI.SetActive(false);

                break;

            case 6: // Saturday

                Arrow_UI.position = Vector2.MoveTowards(Arrow_UI.position, Saturday_Point.position, 7.0f);
                SunnyWeather_UI.SetActive(true);
                StormyWeather_UI.SetActive(false);

                break;

            case 0: // Sunday

                Arrow_UI.position = Vector2.MoveTowards(Arrow_UI.position, Sunday_Point.position, 7.0f);
                SunnyWeather_UI.SetActive(true);
                StormyWeather_UI.SetActive(false);

                break;

        }
    }
}
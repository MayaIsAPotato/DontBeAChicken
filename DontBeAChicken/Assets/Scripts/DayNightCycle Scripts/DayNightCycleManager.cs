using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycleManager : MonoBehaviour
{
    //private DayNightCycle_Script dayNightCycle_Script;
    private AnimalsManager animalsManager;
    public bool hasChangedDay = false;

    private static DayNightCycleManager _instance;

    public static DayNightCycleManager GetInstance() { return _instance; }

    void Awake()
    {
        //dayNightCycle_Script = FindObjectOfType<DayNightCycle_Script>();

        animalsManager = FindObjectOfType<AnimalsManager>();

        // Debug.Log(dayNightCycle_Script.gameObject.name);

        if (!_instance)
        {
            _instance = this;
        }
    }

    void Start()
    {

    }

    void Update()
    {
        // animalsManager.AnimalsSounds();
        DaysPassed();
    }

    #region blah
    public void Morning()
    {
        //dayNightCycle_Script.currentTimeOfDay = 0.25f;
        DayNightCycle_Script.GetInstance().currentTimeOfDay = 0.25f;
    }
    public void Afternoon()
    {
        //dayNightCycle_Script.currentTimeOfDay = 0.5f;
        DayNightCycle_Script.GetInstance().currentTimeOfDay = 0.5f;
    }
    public void Night()
    {
        //dayNightCycle_Script.currentTimeOfDay = 0.75f;
        DayNightCycle_Script.GetInstance().currentTimeOfDay = 0.75f;
    }
    public void Midnight()
    {
        DayNightCycle_Script.GetInstance().currentTimeOfDay = 0.99f;
    }

    public void EnableDayNightCycle()
    {
        //dayNightCycle_Script.enabled = true;
        DayNightCycle_Script.GetInstance().enabled = true;
    }

    public void DisableDayNightCycle()
    {
        //dayNightCycle_Script.enabled = false;
        DayNightCycle_Script.GetInstance().enabled = false;
    }
    #endregion

    public void DaysPassed()
    {
        int _days = DayNightCycle_Script.GetInstance().DaysCount;

        switch (_days)
        {
            case 1:

                if (hasChangedDay == false)
                {
                    //Yiannis
                    UIManager.GetInstance().Timer();
                    //

                    //UIManager.GetInstance().UpdateCalendar();
                    

                }

                break;

            case 2:

                if (hasChangedDay == true)
                {
                    //Yiannis
                    UIManager.GetInstance().Timer();
                    //

                    //UIManager.GetInstance().UpdateCalendar();

                }

                break;

            case 3:

                if (hasChangedDay == false)
                {
                    //Yiannis
                    UIManager.GetInstance().Timer();
                    //

                    //UIManager.GetInstance().UpdateCalendar();
                }

                break;

            case 4:

                if (hasChangedDay == true)
                {
                    //Yiannis
                    UIManager.GetInstance().Timer();
                    //

                    //UIManager.GetInstance().UpdateCalendar();

                }

                break;

            case 5:

                if (hasChangedDay == false)
                {
                    //Yiannis
                    UIManager.GetInstance().Timer();
                    //

                    //UIManager.GetInstance().UpdateCalendar();

                }

                break;

            case 6:

                if (hasChangedDay == true)
                {
                    //Yiannis
                    UIManager.GetInstance().Timer();
                    //

                    //UIManager.GetInstance().UpdateCalendar();
                }

                break;

            case 7:

                if (hasChangedDay == false)
                {
                    //Yiannis
                    UIManager.GetInstance().Timer();
                    //

                    //UIManager.GetInstance().UpdateCalendar();
                }

                break;
        }

    }


}

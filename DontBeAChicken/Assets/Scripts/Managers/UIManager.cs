using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public static UIManager GetInstance() { return _instance; }

    [SerializeField] GameObject CalendarUpdatedUI;
    [SerializeField] Animator UInotifications;

    [Header("Panels")]
    [SerializeField] GameObject CalendarPanel;
    public GameObject GameLogo;
    public GameObject pressAnyKeyPanel;
    

    public float timer = 3.5f;
    bool TimerOn = false;

    void Awake()
    {
        CalendarPanel.SetActive(false);

        GameLogo.SetActive(false);
        //pressAnyKeyPanel.SetActive(false);

        if (!_instance)
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //CalendarPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(TimerOn == true) 
        {
            timer -= 1f * Time.unscaledDeltaTime; 
        }
        else 
        {
            timer = 3.5f;
        }
        
    }

    //public void PressAnyKeyPanel() 
    //{
    //    //set actives the pressAnyKeyPanel before the game starts.
    //    pressAnyKeyPanel.SetActive(true);
    //    PressAnykeyPanel.GetInstance().pressAnyKey();
    //}

    //Yiannis
    public void Timer (/*float timer = 3.5f*/) 
    {
        TimerOn = true;
        if (timer >= 3.5f)
        {
            //timer -= 1f * Time.unscaledDeltaTime;
            CalendarUpdatedUI.SetActive(true);
            UInotifications.Play("UI_notificationsOpen");
        }
        if (timer <= 0.0f)
        {
            UpdateCalendar();
            CalendarUpdatedUI.SetActive(false);
            UInotifications.Play("UI_notificationsClose");
        }
    }
    //

    public void UpdateCalendar()
    {
        CalendarPanel.SetActive(true); // enables calendar.
        Calendar.GetInstance().UpdateArrowsPosition();
        Debug.Log("Let me update the calendar");
        ControllerManager.GetInstance().B_button.SetActive(true);


        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            if
            (
                DayNightCycle_Script.GetInstance().DaysCount == 1 ||
                DayNightCycle_Script.GetInstance().DaysCount == 3 ||
                DayNightCycle_Script.GetInstance().DaysCount == 5 ||
                DayNightCycle_Script.GetInstance().DaysCount == 7
            )
            {
                CalendarPanel.SetActive(false);
                ControllerManager.GetInstance().B_button.SetActive(false);
                AudioManager.GetInstance().selectAudioPlay();

                DayNightCycleManager.GetInstance().hasChangedDay = true;
                TimerOn = false;
            }
            else
            {
                CalendarPanel.SetActive(false);
                ControllerManager.GetInstance().B_button.SetActive(false);
                AudioManager.GetInstance().selectAudioPlay();

                DayNightCycleManager.GetInstance().hasChangedDay = false;
                TimerOn = false;
            }


        }
    }


}
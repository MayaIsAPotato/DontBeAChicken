using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject DebugPanel;
    public bool isActive = false;

    private WeatherManager weatherManager;
    private DayNightCycleManager dayNightCycleManager;

    private void Awake()
    {
        DebugPanel.SetActive(false);

        weatherManager = FindObjectOfType<WeatherManager>();
        dayNightCycleManager = FindObjectOfType<DayNightCycleManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #region Weather
        //Sunny:
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weatherManager.sunny();
        }
        //Rainy:
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weatherManager.rainy();
        }
        #endregion

        #region DayNight
        if (Input.GetKeyDown(KeyCode.F1))
        {
            dayNightCycleManager.Morning();
        }
        if (Input.GetKeyDown(KeyCode.F2)) 
        {
            dayNightCycleManager.Afternoon();
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            dayNightCycleManager.Night();
        }
        #endregion

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (isActive)
            {
                DebugMenuDisabled();
            }
            else
            {
                DebugMenuEnabled();
            }
        }
    }

    private void DebugMenuEnabled() 
    {
        DebugPanel.SetActive(true);
        isActive = true;
    }
    private void DebugMenuDisabled() 
    {
        DebugPanel.SetActive(false);
        isActive = false;
    }
}

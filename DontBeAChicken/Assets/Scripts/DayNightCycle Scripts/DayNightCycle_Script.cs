using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle_Script : MonoBehaviour
{
    private static DayNightCycle_Script _instance;

    public static DayNightCycle_Script GetInstance() { return _instance;  }

    public Light sun;
    //secondsInFullDay is the seconds that the sun moves around the enviroment.
    public float secondsInFullDay = 1440f;
    [Range(0, 1)]
    public float currentTimeOfDay = 0;
    [HideInInspector]
    public float timeMultiplier = 1f;

    //it shows how many days passed
    public int DaysCount;
    //
    public float digitalHoursOfDay;

    public float sunInitialIntensity;

    public float intensityMultiplier = 1f;

    [SerializeField] public int Dayspassed;

    // UIMenu UImenuScript;

    //Enviroment lights:
    #region enviromentLights
    //private Light[] lights;
    //private Renderer[] rend; //--> This gives access to the renderer because I wanted a glow effect(Emission) for the light blubs.
    //[Header("Enviroment Lights")]
    //[SerializeField] private GameObject lightParent;
    #endregion
    private LightsManager lightsManager;

    //metraei tis ores,ta lepta kai tis meres poy perasan gia na tis emfanisei
    [Header("Clock")]
    [SerializeField] public int Hourspassed;
    [SerializeField] public int minutesPassed;

    private void Awake()
    {
        lightsManager = FindObjectOfType<LightsManager>();

        if (!_instance)
        {
            _instance = this;
        }
    }

    void Start()
    {
        //UIMenu.GetComponent<UImenuScript>();
        sunInitialIntensity = sun.intensity;
        
        #region enviromentLights (Not used)
        //lights = lightParent.GetComponentsInChildren<Light>(true);
        //rend = lightParent.GetComponentsInChildren<Renderer>();
        #endregion

    }

    void Update()
    {
        UpdateSun();

        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;
        
        //metraei tin ora ta lepta kai tis meres (meta apo 24 lepta i mera allazei)
        minutesPassed = Mathf.FloorToInt(Time.time) % 60;
        Hourspassed = Mathf.FloorToInt(Time.time / 60) % 24;
        Dayspassed = Mathf.FloorToInt(Time.time / (60 * 24));

        if (currentTimeOfDay >= 1)
        {
            currentTimeOfDay = 0;
            DaysCount +=1;
            Debug.Log ("One day passed!");
        }

        if (DaysCount == 7) 
        {
            Debug.Log("You Failed!(seven days passed)");
            //UImenuScript.GameOver();

            //θα παίξει το cutscene που δείχνει να σκοτώνουν το κοτόπουλο.
            //έπειτα θα βγει το UI για να επιλέξεις τι θα κάνεις.
        }
    }
    //UpdateSun method is actually moves the sun around the enviroment.
    void UpdateSun()
    {
        //the sun rotates 360 degrees around the x-axis according to the current time of day.

        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);

        // 0,25 is sunrise, 0,5 is noon, 0,75 is sunset .
        //float intensityMultiplier = 1f;


        if (currentTimeOfDay <= 0.25f || currentTimeOfDay >= 0.75f)
        {
            intensityMultiplier = 0;

            //Turns on all the lights 
           lightsManager.EnvironmentLightsOn();
        }
        else if (currentTimeOfDay <= 0.25f)
        {
            Debug.Log(" 0.25");
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
        }
        else if (currentTimeOfDay >= 0.73f)
        {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
        }
        else if (currentTimeOfDay >= 0.26)
        {
            Debug.Log("0.26");

            //Turns off all the lights.
            lightsManager.EnvironmentLightsOff();
        }

        #region OldCode
        //if (currentTimeOfDay >= 0.25f )
        //{

        //    intensityMultiplier = 0.5f;
        //    sunInitialIntensity = 0.5f;
        //}
        //else if (currentTimeOfDay <= 0.23f )
        //{
        //    intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
        //    sunInitialIntensity = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));

        //}
        //else if (currentTimeOfDay >= 0.73f)
        //{
        //    intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.73f) * (1 / 0.02f));
        //    sunInitialIntensity = Mathf.Clamp01((currentTimeOfDay - 0.73f) * (1 / 0.02f));
        //}
        #endregion

        #region EnviromentLights (NotUsed)
        //void EnviromentLightsOn()
        //{
        //    //Turns on all the lights 
        //    foreach (Light light in lights)
        //    {
        //        light.enabled = true;
        //    }
        //    foreach (Renderer renderer in rend)
        //    {
        //        renderer.material.EnableKeyword("_EMISSION"); //--> it enables the glow effect for the light blub.
        //    }
        //    Debug.Log("All the enviroment lights are enabled now");
        //}

        //void EnviromentLightsOff()
        //{
        //    //Turns off all the lights.
        //    foreach (Light light in lights)
        //    {
        //        light.enabled = false;
        //    }
        //    foreach (Renderer renderer in rend)
        //    {
        //        renderer.material.DisableKeyword("_EMISSION"); //--> it disables the glow effect for the light blub.
        //    }
        //    Debug.Log("All the enviroment lights are disabled now");
        //}
        #endregion

        sun.intensity = sunInitialIntensity * intensityMultiplier;
    }
}
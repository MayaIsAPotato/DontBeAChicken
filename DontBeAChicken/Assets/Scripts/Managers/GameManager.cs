using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private DayNightCycleManager dayNightCycleManager;
    private CutscenesManager cutscenesManager;
    private ControllerManager controllerManager;
    private GameObject sun;
    private GameObject player;

    private void Awake()
    {
        //pressAnyKeyPanel = GameObject.Find("PressAnyKeyPanel");
        player = GameObject.Find("Chicken(Player)");
        player.SetActive(false);
        //controllerManager.buttons.SetActive(false);
        cutscenesManager = FindObjectOfType<CutscenesManager>();
        dayNightCycleManager = FindObjectOfType<DayNightCycleManager>();
        //controllerManager = FindObjectOfType<ControllerManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //UIManager.GetInstance().PressAnyKeyPanel();
        UIManager.GetInstance().pressAnyKeyPanel.SetActive(true);

        dayNightCycleManager.DisableDayNightCycle();
        sun = GameObject.Find("Directional Light");
        setSun(); //--> changes sun's position .
    }

    // Update is called once per frame
    void Update()
    {
        //UIManager.GetInstance().PressAnyKeyPanel();
    }

    void setSun() 
    {
        sun.transform.position = new Vector3(1.9f, 5.15f, 2.81f);
        sun.transform.rotation = Quaternion.Euler(10.82f, -190f, -360f);
        Debug.Log("Sun's position changed");
    }



}

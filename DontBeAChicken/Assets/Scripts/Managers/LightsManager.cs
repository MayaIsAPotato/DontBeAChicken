using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsManager : MonoBehaviour
{
    private Light[] lights;
    private Renderer[] rend; //--> This gives access to the renderer because I wanted a glow effect(Emission) for the light blubs.
    [Header("Enviroment Lights")]
    [SerializeField] private GameObject lightParent;

    void Start()
    {
        lights = lightParent.GetComponentsInChildren<Light>(true);
        rend = lightParent.GetComponentsInChildren<Renderer>();

        //When the game starts lights are disabled.
        //Change the lights later from the gameManager
        EnvironmentLightsOff();
    }

    public void EnvironmentLightsOn()
    {
        //Turns on all the lights 
        foreach (Light light in lights)
        {
            light.enabled = true;
        }
        foreach (Renderer renderer in rend)
        {
            renderer.material.EnableKeyword("_EMISSION"); //--> it enables the glow effect for the light blub.
        }
        //Debug.Log("All the enviroment lights are enabled now");
    }

    public void EnvironmentLightsOff()
    {
        //Turns off all the lights.
        foreach (Light light in lights)
        {
            light.enabled = false;
        }
        foreach (Renderer renderer in rend)
        {
            renderer.material.DisableKeyword("_EMISSION"); //--> it disables the glow effect for the light blub.
        }
        //Debug.Log("All the enviroment lights are disabled now");
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingBolt : MonoBehaviour
{
    //[SerializeField]
    private Light LightingBoltLight;
    [SerializeField]
    private float Boltintensity;

    public float timer;
    public float timeToWait = 150;

    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
       LightingBoltLight = GetComponentInChildren<Light>();
       //LightingBoltLight.intensity = Boltintensity;
        
    }

    public void StartLightingBolt() 
    {
        if(timer >= timeToWait) 
        {
            Debug.Log("OOps I did it again");
            Debug.Log("Bolt Function called");

            LightingBoltLight.intensity += /*3f **/ Time.deltaTime;

            if (LightingBoltLight.intensity >= 7f)
            {
                Debug.Log("i tried to ++");
                LightingBoltLight.intensity -= /*3f **/ Time.deltaTime;
                timer = 0;


            }
            if (LightingBoltLight.intensity <= 0f)
            {
                Debug.Log("I tried to --");
                LightingBoltLight.intensity = 0f;
                timer = 0;
            }
            //Bolt();
        }
    }

    private void Bolt() 
    {
        Debug.Log("Bolt Function called");

        LightingBoltLight.intensity += /*3f **/ Time.deltaTime;

        if (LightingBoltLight.intensity >= 7f)
        {
            Debug.Log("i tried to ++");
            LightingBoltLight.intensity -= /*3f **/ Time.deltaTime;
            timer = 0;

            
        }
        if (LightingBoltLight.intensity <= 0f)
        {
            Debug.Log("I tried to --");
            LightingBoltLight.intensity = 0f;
            timer = 0;
        }

    }

    public void ResertTimer()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartLightingBolt();

        timer += Time.deltaTime;
    }
}

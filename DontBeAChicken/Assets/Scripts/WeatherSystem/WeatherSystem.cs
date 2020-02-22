using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherSystem : MonoBehaviour
{
    [SerializeField] private Light sun;
    [SerializeField] private GameObject rainClouds;
    [SerializeField] private GameObject _rain;
    [SerializeField] private ParticleSystem rainParticle;
    public float timer = 10f;

    private Fog fog;
    public DayNightCycle_Script _DayNightCycle_Script;
    private WeatherManager weatherManager;
    private AudioManager audioManager;

    //Fade scripts for rainClouds:
    [Header("Fade Scripts RainClouds")]
    public FadeIn FadeInScript;
    public FadeOut FadeOutScript;

    //Fade scripts for sunnyClouds:
    [Header("Fade Scripts SunnyClouds")]
    public MeshFadeIn MeshFadeIn_Script;
    public MeshFadeOut MeshFadeOut_Script;

    //Bools:
    private bool onetime_bool = false; //--> this bool calls something only one time.
    private bool clouds_bool = false;
    public bool cold_bool = false;
    public bool isRainy = false;

    public enum WeatherState
    {
        //Weather states:
        Default,
        sunny,
        rainy
    }

    public WeatherState state = WeatherState.Default;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        weatherManager = FindObjectOfType<WeatherManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        fog = GetComponent<Fog>();
        // _rain.SetActive(false);
        rainParticle.Stop();
        //For rainy weather.
        // FadeInScript.startFading(); //---> calls the startFading method from the script(FadeIn) to fade in the rain clouds in the game.
    }

    // Update is called once per frame
    void Update()
    {
        //For Rainy weather.

        //αλλάζει το χρώμα του ήλιου / changes sun's color to a darker one.
        // sun.color -= (Color.white / 5.0f) * Time.deltaTime;

        //FadeInScript.startFading();

        switch (state) 
        {
            case WeatherState.Default:
                {
                   // if () 
                   // {
                       // _DayNightCycle_Script.sunInitialIntensity = sun.intensity;
                        state = WeatherState.sunny;
                    //onetime_bool = false;
                    break;
                   // }
                }
            case WeatherState.sunny:
                {
                    //_rain.SetActive(false);                
                    // onetime_bool = false;
                    _DayNightCycle_Script.intensityMultiplier += 0.1f * Time.deltaTime;
                    if (_DayNightCycle_Script.intensityMultiplier >=1f) 
                    {
                        _DayNightCycle_Script.intensityMultiplier = 1f;
                    }
                    if (clouds_bool == true)
                    {
                        FadeOutScript.startFadeOut(); //--> this method makes the rain clouds slowly dissapear.
                        MeshFadeIn_Script.startFadeInMesh();
                        rainParticle.loop = false;
                        fog.sunnyFog(); //--> Makes sunny fog Appear.
                        // sun.intensity += 1.1f * Time.deltaTime;
                        //bools:
                        //1:
                        clouds_bool = false;
                        //2:
                        onetime_bool = false;
                        //3:
                        cold_bool = false; //--> It's not cold anymore because the cold_bool is false.
                    }
                    if(isRainy == true) 
                    {
                        state = WeatherState.rainy;
                    }
                    if(isRainy == false) 
                    {
                        timer += Time.deltaTime;
                        if(timer >= 5) 
                        {
                            timer = 10;
                            audioManager.RainAudioStop();
                        }
                    }
                    //_DayNightCycle_Script.sunInitialIntensity = sun.intensity;
                    //sun.color += (Color.white / 5.0f) * Time.deltaTime;
                    break;
                }
            case WeatherState.rainy:
                {
                    // _rain.SetActive(true);
                    // onetime_bool = false;
                   _DayNightCycle_Script.intensityMultiplier -= 0.1f * Time.deltaTime;
                    if(_DayNightCycle_Script.intensityMultiplier <= 0.2f)
                    {
                        _DayNightCycle_Script.intensityMultiplier = 0.2f;
                    }

                    if (!onetime_bool)
                    {
                        FadeInScript.startFadeIn(); //--> This method makes the rain clouds slowly appear.
                        MeshFadeOut_Script.startFadeOutMesh(); //--> This method makes the sunny clouds slowly disappear.

                        rainParticle.Play();
                        rainParticle.loop = true;
                        fog.RainyFog();//--> Makes rainy fog Appear.
                       
                        //sun.intensity -= 0.15f * Time.deltaTime;
                        //Bools:
                        //1:
                        onetime_bool = true;
                        //2:
                        clouds_bool = true; 
                        //3:
                        cold_bool = true; //--> It is cold now because the cold_bool is true.
                    }
                    timer -= Time.deltaTime;
                    if(timer <= 0) 
                    {
                        timer = 0;
                        audioManager.RainAudioPlay();
                    }
                    if(isRainy == false) 
                    {
                        state = WeatherState.sunny;
                    }
                    //sun.color -= (Color.white / 5.0f) * Time.deltaTime; //--> αλλάζει το χρώμα του ήλιου / changes sun's color to a darker one.
                    break;
                }
        }
        
    }
    
}

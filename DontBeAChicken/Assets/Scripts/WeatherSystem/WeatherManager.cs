using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    private WeatherSystem weatherSystem;
    // Start is called before the first frame update
    private void Awake()
    {
        weatherSystem = FindObjectOfType<WeatherSystem>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sunny() 
    {
        weatherSystem.isRainy = false;
    }
    public void rainy() 
    {
        weatherSystem.isRainy = true;
    }
}

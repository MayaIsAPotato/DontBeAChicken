using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{
    [SerializeField]
    private Color _rainyFogCol;
    [SerializeField]
    private Color _sunnyFogCol;

    public bool IsRainy;
    public bool IsSunny;
    //public float fogColorTransition = 1f;
    public float timer = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(IsSunny == true) 
        {
            if (timer <= 1) 
            {
                
                RenderSettings.fogColor = Color.Lerp(_rainyFogCol, _sunnyFogCol, timer);
                timer += 0.1f * Time.deltaTime;
            }
        }
        if(IsRainy == true) 
        {
            if (timer <= 1) 
            {
                RenderSettings.fogColor = Color.Lerp(_sunnyFogCol, _rainyFogCol, timer);
                timer += 0.1f * Time.deltaTime;
            }
        }
    }
    public void RainyFog() 
    {
        timer = 0;
        IsSunny = false;
        IsRainy = true;
        //RenderSettings.fogColor = Color.Lerp(_sunnyFogCol, _rainyFogCol, Mathf.PingPong(Time.time, 1));
        Debug.Log("The fog is rainy");
    }
    public void sunnyFog() 
    {
        timer = 0;
        IsSunny = true;
        IsRainy = false;
        //RenderSettings.fogColor = Color.Lerp (_rainyFogCol, _sunnyFogCol, Mathf.PingPong(Time.time, 1));
        Debug.Log("The fog is rainy");
    }
}

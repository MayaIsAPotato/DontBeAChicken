using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _playerHealth = 10f;
    [SerializeField] private float _playerhypothermia = 0f;

    //Sliders,Bars:
    //[SerializeField] private Slider PlayerhealthBar;
    [SerializeField] private Slider PlayerHypothermiaBar;
    [SerializeField] private GameObject HypothermiaBar_Gameobj;
    //

    [SerializeField] private bool underShelter_bool = false;

    //δίνει πρόσβαση στο σκρίπτ WeatherSystem.
    public WeatherSystem weatherSystemScript;
    // Start is called before the first frame update
    void Start()
    {
        // PlayerhealthBar = GetComponent<Slider>();
        //PlayerHypothermiaBar = GetComponent<Slider>();
        HypothermiaBar_Gameobj.SetActive(false); //--> Disables the UI slider when the game starts.
    }

    void UpdateHealth_Hypothermia_Bar() 
    {
        PlayerHypothermiaBar.value = _playerhypothermia;
       // PlayerhealthBar.value = health;
    }
    // Update is called once per frame
    void Update()
    {
        UpdateHealth_Hypothermia_Bar();


        if (weatherSystemScript.cold_bool == true)
        {
            HypothermiaBar_Gameobj.SetActive(true); //--> Enables the UI slider If it's cold.

            if (underShelter_bool == false)
            {
                _playerhypothermia += 0.5f * Time.deltaTime;
            }

            if (_playerhypothermia >= 100f) //--> if hypothermia level reaches 100 then you die.
            {
                HypothermiaDeath();
            }
        }
        else if (weatherSystemScript.cold_bool == false)
        {
            _playerhypothermia -= 5f * Time.deltaTime;

            if (_playerhypothermia <= 0f)
            {
                _playerhypothermia = 0f;
                HypothermiaBar_Gameobj.SetActive(false);
            }
        }
        
    }

    void HypothermiaDeath()
    {
        Debug.Log("Player Died from the cold weather");
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Shelter"))
        {
            underShelter_bool = true;
            _playerhypothermia -= 5f * Time.deltaTime;

            if (_playerhypothermia <= 0f)
            {
                _playerhypothermia = 0f;
            }
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Shelter"))
        {
            underShelter_bool = false;
        }
    }
}

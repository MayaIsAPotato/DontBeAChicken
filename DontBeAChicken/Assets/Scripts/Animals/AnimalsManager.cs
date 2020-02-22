using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum AnimalType
{
    Bull,
    Cat,
    Chicken,
    Cow,
    Dog,
    Goat,
    Goose,
    Horse,
    Ostrich,
    Pidgeon,
    Rabbit,
    Raven,
    Sheep,
    Stork

}

public abstract class AnimalsManager : MonoBehaviour
{
    #region Old Code
    //private DayNightCycle_Script dayNightCycle_Script;
    //private AudioManager audioManager;
    //public bool tutorialDay = true;//allakse script meta

    //// Start is called before the first frame update

    //private void Awake()
    //{
    //    audioManager = FindObjectOfType<AudioManager>();
    //    dayNightCycle_Script = FindObjectOfType<DayNightCycle_Script>();
    //}

    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    //if (!audioManager.audioIsPlaying)
    //    //{
    //    //    StartCoroutine(audioManager.roosterGrowl());
    //    //}

    //}

    //public void AnimalsSounds()
    //{
    //    if (tutorialDay == false && !audioManager.audioIsPlaying)
    //    {
    //        //ean einai proi 
    //        if (dayNightCycle_Script.currentTimeOfDay >= 0.28)
    //        {
    //            StartCoroutine(audioManager.roosterGrowl());
    //        }
    //        if (dayNightCycle_Script.currentTimeOfDay >= 0.29)
    //        {
    //            StopCoroutine(audioManager.roosterGrowl());
    //        }
    //    }
    //}
    #endregion


    public AnimalType animalType;

    public abstract void Behaviour();

    public abstract void Sound();
}


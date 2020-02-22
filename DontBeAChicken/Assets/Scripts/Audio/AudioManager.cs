using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    public static AudioManager GetInstance() { return _instance; }

    [Header("AudioSources")]
    [HideInInspector] public AudioSource _audioData;
    [SerializeField] private AudioSource _audioDataSFX;
    [SerializeField] private AudioSource _rainAudio;
    [SerializeField] private AudioSource _selectSound;
    [Header("SFX Clips")]
    [SerializeField] private AudioClip _dayAmbience;
    [Header("Animals sounds")]
    public AudioSource _RoosterGrowl;
    [Header("UI sounds")]
    //[SerializeField] private AudioClip _selectSound;

    [HideInInspector] public bool audioIsPlaying;

    #region DayNightCycle script
    private DayNightCycle_Script dayNightCycle_Script;
    #endregion

    private void Awake()
    {
        // dayNightCycle_Script = FindObjectOfType<DayNightCycle_Script>();
        if (!_instance)
        {
            _instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _audioData = GetComponent<AudioSource>();
        audioIsPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        //_audioData.Play(_selectSound);
        //if(dayNightCycle_Script.currentTimeOfDay <= 0.75 && dayNightCycle_Script.currentTimeOfDay >= 0.25) 
        //{
        //    DayAmbience();
        //}
        //else if () 
        //{

        //}
    }

    public void selectAudioPlay() 
    {
        _selectSound.Play();
    }

    public void RainAudioPlay() 
    {
        _rainAudio.Play(0);
    }
    public void RainAudioStop() 
    {
        _rainAudio.Stop();
    }

    public void DayAmbience()
    {
       // _audioDataSFX.PlayOneShot(_dayAmbience);
    }

    public IEnumerator roosterGrowl()
        {
            //for(int i = 0; i < _RoosterGrowl.Length; i++)
            //{ 
                audioIsPlaying = true;
                yield return new WaitForSeconds(4f);
                _RoosterGrowl.Play(0);
                Debug.Log("Rooster growled 1");
                yield return new WaitForSeconds(5f);
                _RoosterGrowl.Play(0);
                Debug.Log("Rooster growled 2");
                yield return new WaitForSeconds(8f);
                _RoosterGrowl.Play(0);
                Debug.Log("Rooster growled 3");
                audioIsPlaying = false;
            //}
        }
    
}

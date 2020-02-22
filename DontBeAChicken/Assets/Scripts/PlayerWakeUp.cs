using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWakeUp : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] private GameObject _playerVision;
    [SerializeField] private GameObject _pressButton;
    [Header("Animators")]
    [SerializeField] private Animator _playerVision_Animator;
    [SerializeField] private Animator _PlayerVisionCamera_Animator;
    [Header("Audio Sources")]
    [SerializeField] private AudioSource _audioData;
    [SerializeField] private AudioSource _RoosterGrowl;
    //[SerializeField] private AudioClip _SelectSound

    private DayNightCycleManager dayNightCycleManager;
    private AudioManager audioManager;

    //Bools
    private bool ButtonPressed;
    private bool DelayHappened;
    
    public bool WakeUpDone = false;

    //private bool audioIsPlaying;

    [Header("Player scripts")]
    private PlayerWakeUp playerWakeUp;
    private ChickenController chickenController;
    private CameraController cameraRotation;
    private Pause pause;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        dayNightCycleManager = FindObjectOfType<DayNightCycleManager>();
        pause = FindObjectOfType<Pause>();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerWakeUp = GetComponent<PlayerWakeUp>();
        chickenController = GetComponent<ChickenController>();
        cameraRotation = GetComponentInChildren<CameraController>();
        chickenController.enabled = false;
        cameraRotation.enabled = false;

        DelayHappened = false;
        ButtonPressed = false;
        //audioIsPlaying = false;
        _playerVision.SetActive(true);
        _pressButton.SetActive(false);
        StartCoroutine(pressButtonDelay());
    }

    // Update is called once per frame
    void Update()
    {
        if (pause.isPaused == false)
        {
            //StartCoroutine(roosterGrowl());
            if (!audioManager.audioIsPlaying)
            {
                StartCoroutine(audioManager.roosterGrowl());
            }
            if (ButtonPressed == false && DelayHappened == true)
            {
                if (Input.GetKeyDown(KeyCode.JoystickButton2))
                {
                    dayNightCycleManager.EnableDayNightCycle(); // Enables DayNightCycle because it was closed for the intro cutscene.
                   
                    _audioData.Play(0);// Plays select sound.
                    _pressButton.SetActive(false); // Disables Press"X" Button.
                    //Animators
                    _playerVision_Animator.Play("ChickenVision_anim");
                    _PlayerVisionCamera_Animator.SetBool("IsDefault", false);
                    //_PlayerVisionCamera_Animator.Play("ChickenVisionCamera");
                    //Bool
                    ButtonPressed = true; // Button has been pressed
                    //Coroutines
                    StartCoroutine(EnablePlayerScripts()); // Starts coroutine to enable player's scripts.
                    StopCoroutine(audioManager.roosterGrowl()); // Stops coroutine rooster growls.
                    StartCoroutine(DisableScript()); // Disables the playerWakeUp script.
                }
            }
        }
    }

    IEnumerator EnablePlayerScripts() 
    {
        yield return new WaitForSeconds(6.5f);
        chickenController.enabled = true;
        cameraRotation.enabled = true;
        _PlayerVisionCamera_Animator.SetBool("IsDefault", true);
    }

    IEnumerator pressButtonDelay() 
    {
        yield return new WaitForSeconds(3f);
        _pressButton.SetActive(true);
        DelayHappened = true;
    }

    IEnumerator DisableScript()
    {
        yield return new WaitForSeconds(7f);
        WakeUpDone = true;
        playerWakeUp.enabled = false;
    }
    
}

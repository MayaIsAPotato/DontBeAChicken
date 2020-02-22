using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutscenesManager : MonoBehaviour
{
    [SerializeField] private GameObject _introductionCutscene;
    //[SerializeField] private GameObject _endingCutscene;
    [SerializeField] private Camera _cutsceneCamera;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _skipButtonUI;

    private GameObject _cutsceneObjects;
    private GameObject _objectsReplacement;
    private GameObject mainMenuCamera;
    private GameObject birdsFlock; //--> for IntroductionCutscene.
    private PlayableDirector[] playableDirectors;
    

    public float cutsceneTime;
    public bool cutsceneActive = false;

    private bool anyButtonPressed = false;

    private Pause pause;

    private void Awake()
    {
        pause = FindObjectOfType<Pause>();
        playableDirectors = FindObjectsOfType<PlayableDirector>();
    }

    // Start is called before the first frame update
    void Start()
    {
        mainMenuCamera = GameObject.Find("MainMenuCamera");
        _cutsceneCamera.enabled = false;
        birdsFlock = GameObject.Find("BirdsFlock(IntroCutscene)");
        _cutsceneObjects = GameObject.Find("Objects");
        _objectsReplacement = GameObject.Find("ObjectsReplacement");
        _objectsReplacement.SetActive(false);
        birdsFlock.SetActive(false);
        _introductionCutscene.SetActive(false);
        _skipButtonUI.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        #region CutsceneTimer
        if (cutsceneActive == true)
        {
            cutsceneTime -= Time.deltaTime;
            if (cutsceneTime <= 0)
            {
                _cutsceneCamera.enabled = false;
                cutsceneActive = false;
                cutsceneTime = 0f;
                introductionCutsceneEnd();
            }
        }
        #endregion
        SkipCutscene();
        #region cutscenesPause
        if (pause.isPaused)
        {
            foreach (PlayableDirector playableDirector in playableDirectors)
            {
                playableDirector.Pause();
            }
        }
        else
        {
            foreach (PlayableDirector playableDirector in playableDirectors)
            {
                playableDirector.Play();
            }
        }
        #endregion
    }

    #region SkipCutscene
    public void SkipCutscene()
    {
        if (cutsceneActive == true && cutsceneTime >= 0 && pause.isPaused == false)
        {
            //Skip Cutscene
            for (int i = 0; i < 20; i++)
            {
                if (Input.GetKeyDown("joystick 1 button " + i) && anyButtonPressed == false)
                {
                    print("joystick 1 button " + i);
                    StartCoroutine(showSkipButton());
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton6) && anyButtonPressed == true)//If select button is pressed cutscene will be skiped.
        {
            cutsceneTime = 0f;
            _skipButtonUI.SetActive(false);
            Debug.Log("Cutscene skiped");

            if (cutsceneTime <= 0)
            {
                _cutsceneCamera.enabled = false;
                cutsceneActive = false;
                cutsceneTime = 0f;
                introductionCutsceneEnd();
            }
        }
    }

    IEnumerator showSkipButton()
    {
        _skipButtonUI.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        anyButtonPressed = true;
        yield return new WaitForSeconds(4f);
        _skipButtonUI.SetActive(false);
        anyButtonPressed = false;
    }
    #endregion

    public void ChickenDeath()
    {
        //Call this method from other scripts.
    }

    #region introductionCutscene
    public void IntroductionCutscene()
    {
        //Call this method from other scripts.
        cutsceneActive = true; //Makes true the boolean for the game to know that the cutscene is active.
        _introductionCutscene.SetActive(true); //Activates the Cutscene.
        mainMenuCamera.SetActive(false); //Diactivates mainMenuCamera.
        _cutsceneCamera.enabled = true; //Enables CutsceneCamera.
        birdsFlock.SetActive(true); //Activates Birds for cutscene.
        _cutsceneObjects.SetActive(true);
        _objectsReplacement.SetActive(false);

        cutsceneTime = 200.02f; // 3:20:20
    }
    public void introductionCutsceneEnd()
    {
        _introductionCutscene.SetActive(false);
        _cutsceneObjects.SetActive(false);
        _objectsReplacement.SetActive(true);
        _player.SetActive(true);
        // maya added
        cutsceneActive = false;
        _cutsceneCamera.enabled = false;
    }
    #endregion

    #region endingCutscene
    public void EndingCutscene()
    {
        //Call this method from other scripts.
        cutsceneActive = true; //Makes true the boolean for the game to know that the cutscene is active.
        _cutsceneCamera.enabled = true;
    }
    public void EndingCutsceneEnd()
    {
        //_endingCutscene.SetActive(false);
    }
    #endregion

}

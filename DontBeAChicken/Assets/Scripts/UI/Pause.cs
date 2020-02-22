using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private MainMenu mainmenu;
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private GameObject mainMenuPanel;
    [SerializeField]
    private GameObject optionsPanel;
    [SerializeField]
    private Animator PanelAnimator;
    [SerializeField]
    private GameObject UI;

    [Header("Player Scripts Accessiblity")]
    [SerializeField] private ChickenController chickenController;
    [SerializeField] private CameraController cameraController;

    public bool isPaused = false;


    private static Pause _instance;

    public static Pause GetInstance() { return _instance; }

    void Awake()
    {
        if (!_instance)
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Find those scripts in the game.
        //chickenController = FindObjectOfType<ChickenController>();
        //cameraController = FindObjectOfType<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && mainmenu.MainMenuIsActive == false)//Prepei na allakseis se controller
        {
            if (isPaused)
            {
                Continue();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame() 
    {
        Debug.Log("game is paused");
        UI.SetActive(false);
        mainMenuPanel.SetActive(false);
        pausePanel.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
        PanelAnimator.Play("Panel_UI_Open_anim");

        chickenController.enabled = false;
        cameraController.enabled = false;
    }

    public void Continue() 
    {
        Debug.Log("game is Continuing");
        UI.SetActive(true);
        optionsPanel.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
        PanelAnimator.Play("Panel_UI_Close_anim");

        chickenController.enabled = true;
        cameraController.enabled = true;
    }

    public void ExitToMainMenu() 
    {
        Time.timeScale = 1f;
        mainmenu.MainMenuIsActive = true;
        pausePanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}

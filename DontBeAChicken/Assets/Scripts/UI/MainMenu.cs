using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Animator PanelAnimator;
    [SerializeField]
    private Animator LogoAnimator;

    [SerializeField] private GameObject MainMenuCamera;

    public bool MainMenuIsActive = true;
    #region Cutscene
    private CutscenesManager cutscenesManager;
    #endregion

    private void Awake()
    {
        #region Cutscene
        cutscenesManager = FindObjectOfType<CutscenesManager>();
        #endregion
    }
    // Start is called before the first frame update
    void Start()
    {
        PanelAnimator.Play("Panel_UI_Open_anim");
    }

    // Update is called once per frame
    void Update()
    {
        if(MainMenuIsActive == false) 
        {
            LogoAnimator.Play("LogoDisappear");
            MainMenuCamera.SetActive(false);
        }
        else 
        {
            LogoAnimator.Play("LogoAppear");
            MainMenuCamera.SetActive(true);
        }
    }

    public void StartGame() 
    {
        //CutsceneStart.
        #region CutsceneStart
        cutscenesManager.IntroductionCutscene();
        #endregion
        PanelAnimator.Play("Panel_UI_Close_anim");
        MainMenuIsActive = false;
    }
}

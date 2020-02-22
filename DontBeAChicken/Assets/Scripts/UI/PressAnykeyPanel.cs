using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnykeyPanel : MonoBehaviour
{

    private static PressAnykeyPanel _instanse;
    
    public static PressAnykeyPanel GetInstance() { return _instanse; }

    [SerializeField] private Animator PanelAnyKeyAnimator;
    [SerializeField] private Animator PressAnyKeyAnimator;
    [SerializeField] private GameObject pressAnyKeyPanel;
    [SerializeField] private GameObject pressAnyKeyText;

    public bool pressAnyButton = false;
    public bool anyButtonPressed = false;

    private void Awake()
    {
        pressAnyKeyText.SetActive(false); // sets false the text.

        if (!_instanse)
        {
            _instanse = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pressAnyKey();
    }

    public void pressAnyKey() 
    {
        if (pressAnyButton == false)
        {
            StartCoroutine(showtext());
        }

        if(pressAnyButton == true) 
        {
            for (int i = 0; i < 20; i++)
            {
                if (Input.GetKeyDown("joystick 1 button " + i) && anyButtonPressed == false)
                {
                    anyButtonPressed = true;
                    Debug.Log("AHA!!!!");
                    AudioManager.GetInstance().selectAudioPlay();
                    print("joystick 1 button " + i);
                    //PressAnyKeyAnimator.Play("ButtonScaleDown");
                    PressAnyKeyAnimator.SetBool("IsScaledDown", true);
                    //pressAnyKeyText.SetActive(false);
                    PanelAnyKeyAnimator.Play("PressAnyKeyPanelClose");
                    StartCoroutine(DisablePanel());
                }
            }
        }
    }

    IEnumerator showtext() 
    {
        Debug.Log("Enumerator called");
        yield return new WaitForSeconds(2f);
        pressAnyKeyText.SetActive(true);
        //PressAnyKeyAnimator.Play("ButtonScaleUp");
        pressAnyButton = true; 
    }

    IEnumerator DisablePanel()
    {
        UIManager.GetInstance().GameLogo.SetActive(true);
        yield return new WaitForSeconds(1f);
        Debug.Log("Disable Panel");
        pressAnyKeyPanel.SetActive(false);
    }
}

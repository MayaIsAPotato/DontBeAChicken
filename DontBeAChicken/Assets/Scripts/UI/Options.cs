using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    [SerializeField]
    private MainMenu mainmenu;
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private GameObject mainMenuPanel;
    [SerializeField]
    private GameObject optionsPanel;
    // Start is called before the first frame update
    void Start()
    {
        //mainmenu = FindObjectOfType<MainMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void backButton()
    {
        if (mainmenu.MainMenuIsActive == false) 
        {
            optionsPanel.SetActive(false);
            pausePanel.SetActive(true);
        }
        else if (mainmenu.MainMenuIsActive == true)
        {
            optionsPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    GameObject GameOverUI;
    // Start is called before the first frame update
    void Start()
    {
        GameOverUI.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameOver()
    {
        //This method is called when the player dies.
        GameOverUI.SetActive(true);
    }
}

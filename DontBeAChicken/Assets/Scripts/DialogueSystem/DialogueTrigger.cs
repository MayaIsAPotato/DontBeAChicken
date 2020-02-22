using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{   //----------------------------------------
    public Dialogue dialogue;
    private DialogueManager dialogueManager;
    //----------------------------------------

    private ControllerManager controllerManager;
    private Pause pause;

    //Bools:
    public bool withoutControllerInput = false; //if it doesn't take input from the controller. Kane metaonomasia se ControllerInput Kai tis aparethtes allages.
    //public bool DisplayNextStncWithoutInput = false;
    public bool playerExitedTrigger = false;


    void Awake()
    {
        dialogueManager = FindObjectOfType<DialogueManager>(); //Find the dialogue manager script.
        controllerManager = FindObjectOfType<ControllerManager>(); //Find the controller manager script.
        pause = FindObjectOfType<Pause>();
    }

    public void TriggerDialogue() // Triggers dialogue without having to press first a button.
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue); 
    }


    void Update()
    {
        if(dialogueManager.dialogueStarted == true) 
        {
            dialogueManager.Delay -= Time.deltaTime;
            if(dialogueManager.Delay <= 0f) 
            {
                dialogueManager.Delay = 0f;
            }
        }
    }

    //If the player walks into a trigger and press A then the converstation of the trigger will start.
    private void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Player") 
        {
            playerExitedTrigger = false;
            
            controllerManager.A_button.SetActive(true); //Show the UI button that the player has to press to start converstation.

            if (dialogueManager.dialogueStarted == false && pause.isPaused == false && withoutControllerInput == false)
            {
                //controllerManager.A_button.SetActive(true);
                if (Input.GetKeyDown(KeyCode.JoystickButton0/*A button*/))
                {
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue); //starts the dialogue.
                }
            }
            //Start dialogue Without Controller input.
            else if (dialogueManager.dialogueStarted == false && withoutControllerInput == true && pause.isPaused == false) // Starts dialogue without pressing the Button to start converstation.
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue); //starts the dialogue.
            }
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            controllerManager.A_button.SetActive(false); //Disables the UI button.
            playerExitedTrigger = true;
        }
    }
}

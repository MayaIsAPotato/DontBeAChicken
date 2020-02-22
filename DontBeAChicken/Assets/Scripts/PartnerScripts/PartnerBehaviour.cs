using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PartnerBehaviour : MonoBehaviour
{
    #region Scripts Accesibility

    [SerializeField] private PlayerWakeUp playerWakeUp;
    private DialogueManager dialogueManager;
    private ControllerManager controllerManager;
    private DialogueTrigger dialogueTrigger;

    #endregion

    public GameObject _dialogue1;
    public GameObject _dialogue2;

    [SerializeField] private GameObject[] target = new GameObject[4]; //The destination targets for the agent to go to.
    //public Transform target;

    private NavMeshAgent _jeff;

    //bools
    public bool hasFinishedDialogue = false;

    public enum TutorialStages
    {
        WakingUp,
        QuestsInformation,
        WalkNormaly,
        WalkSneaky,
        TakeObjects,
        Jump,
        JumpAndInteract,
        MoveObjects,
        Glide
    };

    public TutorialStages stage = TutorialStages.WakingUp;

    private void Awake()
    {
        //playerWakeUp = FindObjectOfType<PlayerWakeUp>();
        controllerManager = FindObjectOfType<ControllerManager>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueTrigger = GameObject.Find("Dialogue2(WaitDialogue)").GetComponent<DialogueTrigger>();

        _jeff = GetComponent<NavMeshAgent>();

        _dialogue1.SetActive(false);
        _dialogue2.SetActive(false);

    }

    private void Start()
    {
        //_jeff.updateRotation = false;
    }

    private void Update()
    {
        Tutorial();

        #region oldCode
        //if (dialogueManager.dialogueStarted == true) //if dialogue has started.
        //{
        //    hasFinishedDialogue = false; //dialogue is not finished.
        //}

        //if(hasFinishedDialogue == true) 
        //{
        //    controllerManager.A_button.SetActive(false);
        //}
        #endregion

    }

    // Updates if agent should stop or start moving Depending if the player is inside or outside of the trigger.
    #region UpdateAgents stop start dest 
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            //Debug.Log("Agent IsMoving because player is OnTrigger");
            _jeff.isStopped = false;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            //Debug.Log("Agent Isn't Moving because player exited the trigger");
            _jeff.isStopped = true;
            //βαλε LookAt(Player) -> transform.LookAt(/*Player*/);
        }
    }
    #endregion 

    //IEnumerator ShowDialogueAfterSecs(float seconds = 6.5f)
    //{
    //    //hasFinishedDialogue = false;

    //    yield return new WaitForSeconds(seconds);
    //    if (hasFinishedDialogue == true && dialogueTrigger.playerExitedTrigger == false)
    //    {
    //        hasFinishedDialogue = false;
    //        _dialogue2.SetActive(true);
    //    }
    //    //yield break;

    //}

    private void Tutorial()
    {
        switch (stage)
        {

            case TutorialStages.WakingUp:

                //Debug.Log("wakingUp");

                if (playerWakeUp.WakeUpDone == true) // Player wakeUp script ended.
                {
                    _dialogue1.SetActive(true); // dialogue1 activates.
            
                    if (dialogueManager.dialogueStarted == true) //if dialogue started.
                    {
                        hasFinishedDialogue = false; // dialogue has not finished yet.
                    }

                    if (hasFinishedDialogue == true) //If dialogue has finished :
                    {
                        _dialogue1.SetActive(false); 

                        //controllerManager.A_button.SetActive(false);

                        //stage = TutorialStages.dest0;
                        StartDestination();
                    }

                }

                break;

            case TutorialStages.QuestsInformation:

                //Debug.Log("OOps I dId It AgAiN");

                stage = TutorialStages.WalkNormaly;
                //add big dialogue
                #region WorkInProgress

                //Na ksekinaei to coroutine an den exei vgei apo to trigger o player.

                //StartCoroutine(ShowDialogueAfterSecs());

                //if (dialogueManager.dialogueStarted == false)
                //{
                //    if (hasFinishedDialogue == true || dialogueTrigger.playerExitedTrigger == true)
                //    {
                //        _dialogue2.SetActive(false);
                //        stage = TutorialStages.WalkNormaly;
                //    }
                //} 

                #endregion

                break;

            case TutorialStages.WalkNormaly:

                break;

            case TutorialStages.WalkSneaky:

                break;

            case TutorialStages.TakeObjects:

                break;

            case TutorialStages.Jump:

                break;

            case TutorialStages.JumpAndInteract:

                break;

            case TutorialStages.MoveObjects:

                break;

            case TutorialStages.Glide:

                break;

        }
    }

    public enum DestinationStates{ dest0, dest1, dest2, dest3};

    public DestinationStates state = DestinationStates.dest0;

    void StartDestination() 
    {
        switch (state) 
        {
            case DestinationStates.dest0:

                controllerManager.A_button.SetActive(false);

                _jeff.destination = target[0].transform.position;

                if (Vector3.Distance(_jeff.transform.position, target[0].transform.position) <= 1)
                {
                    state = DestinationStates.dest1;
                    //Debug.Log("Transitioning to Dest1");
                }
                break;

            case DestinationStates.dest1:

                _jeff.destination = target[1].transform.position;

                if (Vector3.Distance(_jeff.transform.position, target[1].transform.position) <= 1)
                {
                    state = DestinationStates.dest2;
                    //Debug.Log("Transitioning to Dest2");
                }

                break;

            case DestinationStates.dest2:

                _jeff.destination = target[2].transform.position;

                if (Vector3.Distance(_jeff.transform.position, target[2].transform.position) <= 1)
                {
                    state = DestinationStates.dest3;
                    //Debug.Log("Transitioning to Dest3");
                }

                break;

            case DestinationStates.dest3:

                _jeff.destination = target[3].transform.position;

                if (Vector3.Distance(_jeff.transform.position, target[3].transform.position) <= 1)
                {
                    //Debug.Log("Transitioning to ....");
                }

                break;
        }
    }
}


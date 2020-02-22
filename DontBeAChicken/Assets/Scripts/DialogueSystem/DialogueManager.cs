using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    //[SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Animator animator;
    [SerializeField] private Image dialogueBox;
    private Queue<string> sentences;
    public bool dialogueStarted = false;
    public float Delay = 0.5f;

    private Pause pause;
    private AudioManager audioManager;
    private PartnerBehaviour partnerBehaviour;


    [Header("Player Scripts Accessiblity")]
    [SerializeField] private ChickenController chickenController;
    [SerializeField] private CameraController cameraController;

    private void Awake()
    {
        pause = FindObjectOfType<Pause>();
        audioManager = FindObjectOfType<AudioManager>();
        //chickenController = GameObject.Find("Chicken(Player)").GetComponent<ChickenController>();
        //cameraController = FindObjectOfType<CameraController>();
        partnerBehaviour = FindObjectOfType<PartnerBehaviour>();
    }

    void Start()
    {
        sentences = new Queue<string>();
    }

    void Update()
    {

        if (dialogueStarted == true && Delay <= 0f /*&& DisplayNextStncWithoutInput == false*/)
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton0/*A button*/) && pause.isPaused == false)
            {
                audioManager.selectAudioPlay();
                DisplayNextSentence();
            }
        }    

        //if(dialogueStarted == true && DisplayNextStncWithoutInput == true) 
        //{
        //    //τελειωσε τον διαλογο αφου έχει τυπωθεί και το τελευταίο γράμμα.
        //}
        #region Pause
        if (pause.isPaused == true) //If the game is paused the dialogue box will disappear.
        {
            dialogueBox.enabled = false;
            dialogueText.enabled = false;
        }
        else 
        {
            dialogueBox.enabled = true;
            dialogueText.enabled = true;
        }
        #endregion

    }
    public void StartDialogue(Dialogue dialogue) 
    {
        #region ChickenPlayer
        chickenController.enabled = false;
        cameraController.enabled = false;
        #endregion

        animator.SetBool("IsOpen", true);

        dialogueStarted = true;
        //Debug.Log("Starting converstation with" + dialogue.name);

        //nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);

        }
            DisplayNextSentence(); 
    }

    public void DisplayNextSentence() 
    {
        if(sentences.Count == 0) //If there are not anymore sentences then the dialogue ends.
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        //Debug.Log(sentence);
    }

    IEnumerator TypeSentence (string sentence) 
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) 
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue() 
    {
        Debug.Log("End of the converstation.");
        #region ChickenPlayer
        chickenController.enabled = true;
        cameraController.enabled = true;
        #endregion
        animator.SetBool("IsOpen", false);
        dialogueStarted = false;
        partnerBehaviour.hasFinishedDialogue = true;
        Delay = 0.5f;
    }
}

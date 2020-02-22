using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwing : MonoBehaviour
{
    [Header("Cameras")]
    [SerializeField] private Transform MainCamera;
    [SerializeField] private Transform SwingCamera;

    [Header("-----------")]
    [SerializeField] private Transform PlayerSwingPos;
    [SerializeField] private Transform ExitSwingPos;
    [SerializeField] private Transform player;

    [Header("PlayerScripts")]
    private ChickenController chickenController;
    private CameraController cameraController;

    [Header("UI")]
    [SerializeField] private Animator UIanimator;

    public bool IsOnSwing = false;
    public bool anyButtonPressed = false;

    // Start is called before the first frame update
    private void Awake()
    {
        chickenController = FindObjectOfType<ChickenController>();
        cameraController = FindObjectOfType<CameraController>();
    }

    void Start()
    {
        //SwingCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Player") 
        {
            if (IsOnSwing == false) 
            {
                UIanimator.SetBool("IsScaledUp", true);
                ControllerManager.GetInstance().A_button.SetActive(true); //Sets active A button.
            }

            if (Input.GetKeyDown(KeyCode.JoystickButton0) && IsOnSwing == false) 
            {
                ControllerManager.GetInstance().A_button.SetActive(false);
                UIanimator.SetBool("IsScaledUp", false);
                player.position = PlayerSwingPos.position;
                player.rotation = Quaternion.Euler(0f, 0f, 0f); //Sets player rotation in 0f,0f,0f for the player to face a specific direction.
                player.parent = PlayerSwingPos; //player becomes child of PlayerSwingPos
                //MainCamera.SetActive(false);
                //SwingCamera.SetActive(true);
                MainCamera.position = SwingCamera.position; //Changes Camera position
                chickenController.enabled = false;
                cameraController.enabled = false;
                IsOnSwing = true;

                //If input is detected:


            }
            else if (/*Input.GetKeyDown(KeyCode.JoystickButton1) &&*/ IsOnSwing == true) 
            {
                InputDetection();
                #region oldCode
                /*
                player.position = ExitSwingPos.position;
                player.rotation = Quaternion.Euler(0f,0f,0f); //Sets player rotation in 0f,0f,0f for the player to face a specific direction.
                player.parent = null; //player is no longer child of PlayerSwingPos
                //MainCamera.SetActive(true);
                //SwingCamera.SetActive(false);
                SwingCamera.position = MainCamera.position; //Changes camera position back 
                chickenController.enabled = true;
                cameraController.enabled = true;
                ControllerManager.GetInstance().B_button.SetActive(false);
                IsOnSwing = false;
                */
                #endregion
            }
        }
    }

    #region WIP InputDetection
    public void InputDetection()
    {
        for (int i = 0; i < 20; i++)
        {
            if (Input.GetKeyDown("joystick 1 button " + i) && anyButtonPressed == false && Pause.GetInstance().isPaused == false) //Any buttonPressed
            {
                StartCoroutine(showButtonToPress());
                print("joystick 1 button " + i);
            }
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton1) && anyButtonPressed == true)
        {
            ControllerManager.GetInstance().B_button.SetActive(false);
            AudioManager.GetInstance().selectAudioPlay();
            StopAllCoroutines();
            anyButtonPressed = false;
            //------------------------------------------------------------//
            player.position = ExitSwingPos.position;
            player.rotation = Quaternion.Euler(0f, 0f, 0f); //Sets player rotation in 0f,0f,0f for the player to face a specific direction.
            player.parent = null; //player is no longer child of PlayerSwingPos
            //MainCamera.SetActive(true);
            //SwingCamera.SetActive(false);
            SwingCamera.position = MainCamera.position; //Changes camera position back 
            chickenController.enabled = true;
            cameraController.enabled = true;
            ControllerManager.GetInstance().B_button.SetActive(false);
            IsOnSwing = false;
        }
    }

    IEnumerator showButtonToPress()
    {
        ControllerManager.GetInstance().B_button.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        anyButtonPressed = true;
        yield return new WaitForSeconds(4f);
        ControllerManager.GetInstance().B_button.SetActive(false);
        anyButtonPressed = false;
    }
    #endregion

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Player") 
        {
            UIanimator.SetBool("IsScaledUp", false);
            ControllerManager.GetInstance().A_button.SetActive(false);
        }
    }
}

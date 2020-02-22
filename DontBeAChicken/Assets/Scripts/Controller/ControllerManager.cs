using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    [Header("Buttons UI")]
    [SerializeField] public GameObject buttons;
    [SerializeField] public GameObject A_button;
    [SerializeField] public GameObject B_button;
    [SerializeField] public GameObject X_button;
    [SerializeField] public GameObject Y_button;

    private static ControllerManager _instance;

    public static ControllerManager GetInstance() { return _instance;  }

    public bool pressAnyButton;

    void Awake()
    {
        if (!_instance) 
        {
            _instance = this;
        }
    }

    #region WIP InputDetection
    //public void InputDetection()
    //{
    //    if (pressAnyButton == false)
    //    {
    //        for (int i = 0; i < 20; i++)
    //        {
    //            if (Input.GetKeyDown("joystick 1 button " + i))
    //            {
    //                AudioManager.GetInstance().selectAudioPlay();
    //                print("joystick 1 button " + i);
    //            }
    //        }
    //    }
    //}

    //IEnumerator showButtonToPress()
    //{
    //    pressAnyButton = true;
    //    //TadeButton
    //    Debug.Log("Enumerator called");
    //    yield return new WaitForSeconds(4f);
    //    pressAnyButton = false;
    //}
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

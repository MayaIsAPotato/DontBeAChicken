using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleUI_Trigger : MonoBehaviour
{
    [SerializeField] private GameObject bubbleUI;
    [SerializeField] private Transform playerPos;

    private float _dist;
    // Start is called before the first frame update
    void Start()
    {
        //playerPos = playerPos.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _dist = Vector3.Distance(bubbleUI.transform.position, playerPos.position);
    }

    private void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Player") 
        {
            bubbleUI.SetActive(true);

            ////don't scale it further away than 4 units
            //if (_dist < 10f) //for scale up
            //{
            //    //bubbleUI.transform.localScale = Vector3.forward;
            //    Vector3 newScale = transform.localScale;
            //    newScale *= 1.2f;
            //    bubbleUI.transform.localScale = newScale;
            //    return;
            //}
            #region while
            //while (_dist <= 10f && _dist >= 0f)
            //{
            //    //bubbleUI.transform.localScale = Vector3.forward;
            //    Vector3 newScale = transform.localScale;
            //    newScale *= 1.2f;
            //    bubbleUI.transform.localScale = newScale;
            //    return;
            //}
            #endregion
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Player") 
        {
            bubbleUI.SetActive(false);
        }   
    }
}

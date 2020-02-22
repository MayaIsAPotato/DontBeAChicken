using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MinorDialogueTrigger : MonoBehaviour
{
    [TextArea(3, 10)]
    public string sentences;
    private TextMeshPro textmeshPro;

    private Animator bubbleAnimator;

    // Start is called before the first frame update
    void Start()
    {
        textmeshPro = GetComponentInChildren<TextMeshPro>();
        bubbleAnimator = GetComponentInChildren<Animator>();
        textmeshPro.SetText(sentences);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Player") 
        {
            bubbleAnimator.SetBool("IsOpen", true);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Player") 
        {
            bubbleAnimator.SetBool("IsOpen", false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    private SpriteRenderer[] rend;
    public GameObject clouds;
    // Start is called before the first frame update
    void Start()
    {
        //rend = GetComponent<SpriteRenderer>();
        //rend = GetComponentInChildren<SpriteRenderer>();
        // rend = GetComponentsInChildren<SpriteRenderer>();

         rend = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < rend.Length; i++)
        {
            Color c = rend[i].material.color;
            c.a = 0f;
            rend[i].material.color = c;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeInEnumerator()
    {
        for (int i = 0; i < rend.Length; i++)
        {
            for (float f = 0f; f <= 1; f += 0.05f)
            {
                Color c = rend[i].material.color;
                c.a = f;
                rend[i].material.color = c;
                yield return new WaitForSeconds(0.05f);
            }
        }
    }

    public void startFadeIn()
    {
        StartCoroutine("FadeInEnumerator");
        Debug.Log("fadeInStarted, Clouds are appearing now");
    }
}

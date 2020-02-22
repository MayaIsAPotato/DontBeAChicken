using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    private SpriteRenderer[] rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator FadeOutEnumerator()
    {
        for (int i = 0; i < rend.Length; i++)
        {
            for (float f = 1f; f >= -0.05f; f -= 0.05f)
            {
                Color c = rend[i].material.color;
                c.a = f;
                rend[i].material.color = c;
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
    public void startFadeOut()
    {
        StartCoroutine("FadeOutEnumerator");
        Debug.Log("fadeInStarted, Rain clouds will start disappearing now");
    }
}

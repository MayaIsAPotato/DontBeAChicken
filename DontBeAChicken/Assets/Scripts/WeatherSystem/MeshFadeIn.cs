using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshFadeIn : MonoBehaviour
{
    //public GameObject SunnyDayClouds;
    private MeshRenderer[] meshRend;
    [SerializeField] private GameObject sunnyCloudsParent;
    // Start is called before the first frame update
    void Start()
    {
        meshRend = sunnyCloudsParent.GetComponentsInChildren<MeshRenderer>();

        //clouds.GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f, 0f);
    }

    IEnumerator FadeInMeshEnumerator()
    {
        foreach (MeshRenderer meshrenderer in meshRend)
        {
            for (float f = 0f; f <= 1f; f += 0.05f)
            {
                yield return new WaitForSeconds(0.05f);
                Color c = meshrenderer.material.color;
                c.a = f;
                meshrenderer.material.color = c;

            }
        }
    }
    public void startFadeInMesh()
    {
        StartCoroutine("startFadeInMeshEnumerator");
        Debug.Log("fadeInStarted, sunny clouds are appearing now");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

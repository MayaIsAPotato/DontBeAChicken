using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshFadeOut : MonoBehaviour
{
    private MeshRenderer[] meshRend;
    [SerializeField] private GameObject sunnyCloudsParent;
    // Start is called before the first frame update
    void Start()
    {
        meshRend = sunnyCloudsParent.GetComponentsInChildren<MeshRenderer>();

        //clouds.GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f, 0f);
       
    }

    IEnumerator FadeOutMeshEnumerator()
    {
         foreach (MeshRenderer meshrenderer in meshRend)
        {
            
            for (float f = 1f; f >= -0.05f; f -= 0.05f)
            {
                yield return new WaitForSeconds(0.05f);
                Color c = meshrenderer.material.color;
                c.a = f;
                meshrenderer.material.color = c;
                //Debug.Log("fadeOutStarted, sunny clouds are disappearing now");
               
            }
        }
    }
    public void startFadeOutMesh()
    {
        StartCoroutine("FadeOutMeshEnumerator");
        Debug.Log("fadeOutStarted, sunny clouds are disappearing now");
    }
}

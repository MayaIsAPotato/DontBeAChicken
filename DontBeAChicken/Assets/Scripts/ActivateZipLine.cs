using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateZipLine : MonoBehaviour
{
    private ZipLine zipLineScript;
    private bool CanZip_bool = false;
    // Start is called before the first frame update
    void Start()
    {
        zipLineScript = GameObject.Find("Chicken").GetComponent<ZipLine>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(CanZip_bool);
        if (CanZip_bool == true && Input.GetKeyDown("f")) 
        {
            zipLineScript.UseZipLine();
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            CanZip_bool = !CanZip_bool;
        }
    }
}

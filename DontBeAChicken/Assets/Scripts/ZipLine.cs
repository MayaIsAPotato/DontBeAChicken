using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZipLine : MonoBehaviour
{
    [SerializeField] private Transform endPos;

    private float time = 5;
    private float elapsedTime = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UseZipLine() 
    {
        Vector3 startingPos = transform.position;
    
        while (elapsedTime < time) 
        {
            transform.position = Vector3.Lerp(startingPos, endPos.position, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            Debug.Log("Player is ziplining!");

        }

    }

}

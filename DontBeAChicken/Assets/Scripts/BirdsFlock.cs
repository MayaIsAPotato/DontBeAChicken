using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsFlock : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 0.02f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotation in y
        //position z
        //The birds are actually doing a 360 rotation in y axis while they are moving in z axis.
        Vector3 BirdsMovement = new Vector3(0f, 0f, 1f) * Time.deltaTime;
        transform.Rotate(0.0f, 360f * _rotationSpeed * Time.deltaTime, 0f);
        transform.Translate(BirdsMovement);
    }
}

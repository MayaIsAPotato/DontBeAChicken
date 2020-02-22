using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsRotation : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 0.001f;
    [SerializeField]
    private GameObject _clouds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       _clouds.transform.Rotate(0.0f, 360f * _rotationSpeed * Time.deltaTime, 0f);
    }
}

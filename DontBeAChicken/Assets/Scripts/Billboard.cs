using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {
	public Camera m_Camera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		transform.LookAt (transform.position + m_Camera.transform.rotation * Vector3.forward, m_Camera.transform.rotation * Vector3.up);
	}
}

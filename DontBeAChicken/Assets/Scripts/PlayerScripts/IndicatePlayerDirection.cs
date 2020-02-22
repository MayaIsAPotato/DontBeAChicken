using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatePlayerDirection : MonoBehaviour
{
	private Transform _playerTransform;
	private Rigidbody _playerRb;

	void Start()
    {
		_playerTransform = GetComponentInParent<Transform>();
		_playerRb = GetComponentInParent<Rigidbody>();
	}

    void Update()
    {
		transform.rotation = Quaternion.Euler(0.0f, _playerTransform.rotation.y, 0.0f);
		
	}
}

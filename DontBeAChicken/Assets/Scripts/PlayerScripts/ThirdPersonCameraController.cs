using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
	//public GameObject player;
	//private Vector3 _offset;

	[SerializeField] private float _rotSpeed = 1.0f;
	[SerializeField] private Transform _player;
	[SerializeField] private Transform _target;
	[SerializeField] private float _viewRange = 10.0f;
	private Vector3 _defaultRot;

	void Start()
	{
		_defaultRot = transform.rotation.eulerAngles;
		//_offset = transform.position - player.transform.position;
	}

	void Update()
	{
		//transform.position = player.transform.position + _offset;
		//transform.LookAt(player.transform);
		CameraControl();
	}
	
	void CameraControl()
	{
		float horizontal = _rotSpeed * Input.GetAxis("Horizontal R");
		float vertical = _rotSpeed * Input.GetAxis("Vertical R");

		if (Mathf.Approximately(horizontal + vertical, 0.0f))
		{
			//transform.rotation = Quaternion.Euler(_defaultRot);
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_defaultRot), 0.05f);
		}
		else
		{
			Debug.Log("Angle X: " + transform.localEulerAngles.x + " Vertical: " + vertical);
			transform.localEulerAngles = new Vector3
				(
				Mathf.Clamp(transform.localEulerAngles.x + vertical, -1 * _viewRange,  _viewRange),
					transform.localEulerAngles.y + horizontal,
					0.0f
				);
		}
	}
	
}

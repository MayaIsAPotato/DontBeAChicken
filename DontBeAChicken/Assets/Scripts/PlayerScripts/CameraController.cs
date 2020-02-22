using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] private Transform _chicken;
	[SerializeField] private Transform _camera;
	[SerializeField] private Transform _cameraStartingPos;
	[SerializeField] private Transform _cameraSecondPos;

	[SerializeField] private float _sphereRadius;
	[SerializeField] private float _maxDistance;

	[SerializeField] GameObject _currentHitObject;

	[SerializeField] LayerMask layerMask;

	[SerializeField] private float _sensX = 3f;
	[SerializeField] private float _sensY = 3f;
	private float _rotationY = 0.0f;
	private float _rotationX = 0f;
	private float _minimumY = -15f;
	private float _maximumY = 15f;
	private float _minimumX = -40f;
	private float _maximumX = 40f;
	private float _cameraSpeed = 0.5f;
	private float _currentHitDistance;

	private Vector3 origin;
	private Vector3 direction;

	void Update()
	{
		CameraRotation();
		CameraMovement();
	}

	void CameraRotation()
	{
		float horizontal = Input.GetAxis("Horizontal R");
		float vertical = Input.GetAxis("Vertical R");

		if (!Mathf.Approximately(horizontal + vertical, 0.0f))
		{
			if (!Mathf.Approximately(horizontal, 0.0f))
			{
				_rotationY -= horizontal * _sensX;
				_rotationY = Mathf.Clamp(_rotationY, _minimumX, _maximumX);
				transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, _rotationY, 0.0f);
			}

			if (!Mathf.Approximately(vertical, 0.0f))
			{
				_rotationX -= vertical * _sensY;
				_rotationX = Mathf.Clamp(_rotationX, _minimumY, _maximumY);
				transform.localEulerAngles = new Vector3(_rotationX, transform.localEulerAngles.y, 0.0f);
			}
		}
		else //if (!Mathf.Approximately(_rotationX, 0.0f) || !Mathf.Approximately(_rotationY, 0.0f))
		{
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0.0f, _chicken.transform.eulerAngles.y, 0.0f)), 0.05f);
			_rotationX = 0.0f;
			_rotationY = 0.0f;
		}
	}

	void CameraMovement()
	{
		RaycastHit hit;


		origin = _camera.position;
		direction = _cameraSecondPos.position;

		float cameraTransition = _cameraSpeed * Time.deltaTime;

		


		if (Physics.SphereCast(origin, _sphereRadius, direction, out hit, _maxDistance, layerMask, QueryTriggerInteraction.UseGlobal ))
		{
			_currentHitObject = hit.transform.gameObject;
			_currentHitDistance = hit.distance;

			if (hit.collider.tag != "Player")
			{
				_camera.transform.position = Vector3.MoveTowards(_camera.position, _cameraSecondPos.position, cameraTransition);

				Debug.Log("Camera can't see the player");

				if (hit.collider.tag == "Player")
				{
					_camera.transform.position = Vector3.MoveTowards(_cameraSecondPos.position, _cameraStartingPos.position, cameraTransition);

					Debug.Log("Camera can see the player perfectly fine after its transform");
				}
			}
			else
			{
				Debug.Log("Camera can see the player perfectly fine");
			}

		}
		else
		{
			_currentHitDistance = _maxDistance;
			_currentHitObject = null;
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Debug.DrawLine(origin, origin + direction * _currentHitDistance);
	}
}

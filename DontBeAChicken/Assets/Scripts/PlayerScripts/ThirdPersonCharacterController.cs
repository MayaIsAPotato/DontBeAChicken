using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
	[SerializeField] private float _moveSpeed;
	private Animator _anim;
	private Vector3 _previousPos;

	void Start()
	{
		_anim = GetComponent<Animator>();
		_previousPos = transform.position;
	}

	void FixedUpdate()
	{
		PlayerMovement();
	}

	void PlayerMovement()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		Vector3 playerMovement = new Vector3(horizontal, .0f, vertical) * _moveSpeed * Time.deltaTime;
		transform.Translate(playerMovement);

		if (!Mathf.Approximately(vertical, 0.0f))
		{
			_anim.SetBool(vertical > 0 ? "movingFwd" : "movingBwd", true);
			_anim.SetBool(vertical > 0 ? "movingBwd" : "movingFwd", false);
		}
		else
		{
			_anim.SetBool("movingFwd", false);
			_anim.SetBool("movingBwd", false);
		}


		#region Archived
		//int animSpeed = vertical > 0 ? 1 : vertical < 0 ? -1 : 0;
		//_anim.SetFloat("speed", animSpeed);

		//if (animSpeed != 0 )
		//{
		//	_anim.Play("Walking");
		//}   
		#endregion


	}
}
	


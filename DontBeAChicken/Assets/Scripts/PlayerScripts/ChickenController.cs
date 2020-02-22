using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
	private static ChickenController _instance;
	public static ChickenController GetInstance() {return _instance;}

    [SerializeField] private float _moveSpeed;
	[SerializeField] private float _jumpSpeed;
	[SerializeField] private float _glideSpeed;
	[SerializeField] private float _jumpHeight;
	[SerializeField] private Animator _chickenAnimator;

	private Rigidbody _rb;
	private bool _jumped;
	private bool _jumping;
	private bool _gliding;
	private float _totalJumpDist = 0.0f;
	private float _currentJumpDist = 0.0f;
	private Vector3 _jumpPos;
	private float _glidingForce = 10.0f; // i havent test this i might delete later

	private static List<GameObject> _playerItems = new List<GameObject>(); //when the player picks up an item, it should be added to this list

	private enum RotationAxis { joyX = 1, joyY = 2 }

	private RotationAxis _axes = RotationAxis.joyX;

	private float _sensX = 10.0f;
	private float _sensY = 10.0f;
	private float _rotationX = 0f;
	private float _minimumY = -15f;
	private float _maximumY = 15f;


	void Awake()
	{
		if (!_instance)
		{
			_instance = this;
		}
	}

	// Start is called before the first frame update
	void Start()
    {
        //_chickenAnimator = GetComponent<Animator>();
		_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveChicken();
		JumpChicken();
		RotateChicken();
		GlideChicken();
	}

	public static bool HasItem(GameObject item) 
	{ 
		return _playerItems.Contains(item); 
	}

    public void MoveChicken()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 translation = new Vector3(horizontal, 0.0f, vertical) * Time.deltaTime * _moveSpeed;
        transform.Translate(translation);

		if (vertical != 0 && horizontal != 0)
		{
			_chickenAnimator.SetBool("IsRunning", true);
		}
		else
		{
			_chickenAnimator.SetBool("IsRunning", false);
		}
        //_rb.AddForce(translation );
        //AnimateBakaou(vertical);

    }

	void JumpChicken() 
	{
		float jump = Input.GetAxis("Jump");

		if (!_jumped &&  !Mathf.Approximately(jump, 0.0f))
		{
			_jumped = true;
			_jumping = true;
			_currentJumpDist = 0.0f;
			_jumpPos = new Vector3(transform.position.x, transform.position.y + _jumpHeight, transform.position.z);
			_totalJumpDist = Vector3.Distance(transform.position, _jumpPos);
			Vector3 previousPos = transform.position;
			transform.position = Vector3.Lerp(transform.position, _jumpPos, (_currentJumpDist  + ( _jumpSpeed/100 ) ) / _totalJumpDist);
			_currentJumpDist += Vector3.Distance(previousPos, transform.position);
		}
		else if (_jumping && _jumped)
		{
			Vector3 previousPos = transform.position;
			transform.position = Vector3.Lerp(transform.position, _jumpPos, (_currentJumpDist + (_jumpSpeed / 100)) / _totalJumpDist);
			_currentJumpDist += Vector3.Distance(previousPos, transform.position);
			_jumping = !(_currentJumpDist >= _totalJumpDist);
		}

	}

	void RotateChicken()
	{
		float horizontal = Input.GetAxis("Horizontal");

		transform.Rotate(0, horizontal * _sensX, 0);
	}

	void GlideChicken()
	{
		bool glide = Input.GetKey("joystick button 3");

		if (_jumping && !_gliding && glide)
		{
			Debug.Log("The chicken tried to glide but you havent add sth baka");
			_gliding = true;
			_rb.AddForce(Vector3.forward, ForceMode.Force);
			_rb.velocity = new Vector3(0, -10, 0);
			//
			//
			//
		}
		else if (_jumping && !glide)
		{
			JumpChicken();
		}

	}


	//private void AnimateBakaou(float vertical)
 //   {
 //       _chickenAnimator.SetBool("moving", !Mathf.Approximately(vertical, 0.0f));
 //   }

	private void OnCollisionEnter(Collision collision)
	{
		_jumped = !collision.gameObject.CompareTag("Ground");
	}
}

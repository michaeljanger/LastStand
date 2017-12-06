using UnityEngine;

public class MovePlayer : MonoBehaviour
{
	public CharacterController CharacterController; 
	public float moveSpeed = 5f;
	public float turnSpeed = 15f;
	public float gravity = 21f;

	private float h;
	private float v;
	private float mh;
	private float mv;
	private float s;
	private float deadzone = 0.1f;
	private Vector3 moveDirection = Vector3.zero;
	private Vector3 turnDirection = Vector3.zero;
	void Awake()
	{
		CharacterController = GetComponent<CharacterController> ();
	//	camera = Camera.main;
	}
	void Update()
	{
		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis ("Vertical");
		mh = Input.GetAxis ("Mouse X");
		mv = Input.GetAxis ("Mouse Y");
		moveDirection = Vector3.zero;

		ProcessVerticalMovement (v);
		ProcessHorizontalMovement (h, mh);

		if (moveDirection.magnitude > 1) { 
			moveDirection.Normalize ();
		}
		moveDirection = transform.TransformDirection (moveDirection);
		moveDirection.y -= gravity * Time.deltaTime;
		CharacterController.Move (moveDirection * moveSpeed * Time.deltaTime);
		//Rotate
		//transform.Rotate(moveDirection);
		if (Input.GetKeyDown(KeyCode.W))
			transform.forward = new Vector3(0f, 0f, 1f);
		else if (Input.GetKeyDown(KeyCode.S))
			transform.forward = new Vector3(0f, 0f, -1f);
		else if (Input.GetKeyDown(KeyCode.A))
			transform.forward = new Vector3(1f, 0f, 0f);
		else if (Input.GetKeyDown(KeyCode.D))
			transform.forward = new Vector3(-1f, 0f, 0f);
	}
	void ProcessVerticalMovement(float v)
	{
		if (v > deadzone || v < -deadzone) {
		
			moveDirection = new Vector3 (0f, 0f, v);
		}

	}
	void ProcessHorizontalMovement(float h, float m)
	{

				moveDirection.x = h;
			
		}
	}

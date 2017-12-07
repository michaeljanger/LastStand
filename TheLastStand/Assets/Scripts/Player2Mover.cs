using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Mover : MonoBehaviour {
	public GameObject player2;
	public Camera mainCamera;
	public CharacterController controller2;
	public float moveSpeed = 5f;
	public float gravity = 20.0f;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		CharacterController controller = GetComponent<CharacterController>();

		float x = Input.GetAxis("HorizontalP2");
		float y = 0f;
		float z = Input.GetAxis("VerticalP2");
		var jumpspeed = 8;


		Vector3 inputVector = mainCamera.transform.TransformDirection(x, 0f, z);
		Vector3 rotationVector = mainCamera.transform.TransformDirection(x, 0f, z);
		inputVector *= moveSpeed;

		controller.SimpleMove(inputVector); 
		if (inputVector != Vector3.zero){
			transform.rotation = Quaternion.Slerp(transform.rotation,  Quaternion.LookRotation(rotationVector),  Time.deltaTime * 20); // What this means is that it is rotating FROM the first parameter to the second at the pace of the third parameter        
			transform.rotation = Quaternion.Euler(y , transform.rotation.eulerAngles.y , y);
			//transform.rotation = Quaternion.FromToRotation(inputVector , transform.forward);
		}


	}
}

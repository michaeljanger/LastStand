using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {
	public GameObject player;
	public Camera mainCamera;
	public CharacterController controller;
	public float moveSpeed = 5f;
	public float gravity = 20.0f;

		
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		CharacterController controller = GetComponent<CharacterController>();

		float x = Input.GetAxis("Horizontal");
		float y = 0f;
		float z = Input.GetAxis("Vertical");
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

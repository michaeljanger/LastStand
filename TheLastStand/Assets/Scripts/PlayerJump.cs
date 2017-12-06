using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour {
	public float jspeed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float jgravity = 20.0F;
	public CharacterController controller; 
	private Vector3 moveDirection = Vector3.zero;
	void Update() {
		
		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			//moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			//moveDirection = transform.TransformDirection(moveDirection);
			//moveDirection *= jspeed;
			if (Input.GetKeyDown(KeyCode.JoystickButton1))
				moveDirection.y = jumpSpeed;

		}
		moveDirection.y -= jgravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}

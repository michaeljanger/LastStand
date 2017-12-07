using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2SwingController : MonoBehaviour {
	//call player components
	public CharacterController controller;
	public GameObject playerchar;
	public Animator characteranim;

	//call player swing position
	public bool PlayerSwingisUp;
	public bool PlayerSwingisDown;
	public bool PlayerSwingisLeft;
	public bool PlayerSwingisRight;
	public bool PlayerSwingisIdle;

	// Use this for initialization
	void Start () {
		//characteranim = GetComponent<Animator>();
		var characteranim = GetComponent<Animator>();
		PlayerSwingisUp = false;
		PlayerSwingisDown = false;
		PlayerSwingisRight = false;
		PlayerSwingisLeft = false;
		PlayerSwingisIdle = true;

	}
	
	// Update is called once per frame
	void Update () {
		
		float x = Input.GetAxis("4th axisP2");
		float y = Input.GetAxis("5th axisP2");

		if (x == 0 && y == 0 && PlayerSwingisIdle == false) {

			//play anim
			PlayerSwingisIdle = true;
			if (PlayerSwingisIdle == true) {
				characteranim.Play ("idle");
				Debug.Log ("idle");
			}
		}
		else 
		{
			PlayerSwingisIdle = false;
		}
		//right swing
		if (x == 1 && PlayerSwingisIdle == false  && PlayerSwingisRight == false) {
			PlayerSwingisRight = true;
			PlayerSwingisIdle = false;
			//play anim
			characteranim.Play ("rightswing");
			Debug.Log ("rightswing");
		}
		else 
		{
			PlayerSwingisRight = false;
		}
		//left swing
		if (x == -1  && PlayerSwingisIdle == false && PlayerSwingisLeft == false) {
			PlayerSwingisLeft = true;
			PlayerSwingisIdle = false;
			//play anim
			Debug.Log("leftswing");
			characteranim.Play ("leftswing");
		}
		else 
		{
			PlayerSwingisLeft = false;
		}
		//up swing
		if (y == -1 && PlayerSwingisIdle == false && PlayerSwingisUp == false) {
			PlayerSwingisUp = true;
			PlayerSwingisIdle = false;
			//play anim
			characteranim.Play ("upswing");
			Debug.Log("upswing");
		}
		else 
		{
			PlayerSwingisUp = false;
		}

		//down swing
		if (y == 1 && PlayerSwingisIdle == false && PlayerSwingisDown == false) {
			PlayerSwingisDown = true;

			//play anim
			characteranim.Play ("downswing");
			Debug.Log("downswing");
		}
		else 
		{
			PlayerSwingisDown = false;
		}

	}
}

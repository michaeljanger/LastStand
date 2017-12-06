using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwing : MonoBehaviour {
	public CharacterController controller;
	public GameObject playerchar;
	public Animator characteranim;
	// Use this for initialization
	void Start () {
		//characteranim = GetComponent<Animator>();
		var characteranim = GetComponent<Animator>();
		var idle = characteranim.GetBool ("idle");
		var leftswing = characteranim.GetBool ("leftswing");
		var rightswing = characteranim.GetBool ("rightswing");
		var upswing = characteranim.GetBool ("upswing");
		var downswing = characteranim.GetBool ("downswing");
	}
	
	// Update is called once per frame
	void Update () {
		
		float x = Input.GetAxis("4th axis");
		float y = Input.GetAxis("5th axis");

		if (x == 0 && y == 0) {
			characteranim.SetBool ("idle", true);
			characteranim.Play ("idle");
			Debug.Log("idle");
		}
		//right swing
		if (x == 1 ) {
			characteranim.SetBool ("rightswing", false);
			characteranim.SetBool ("idle", false);
			characteranim.Play ("rightswing");
			Debug.Log("rightswing");
		}
		//left swing
		if (x == -1 ) {
			characteranim.SetBool ("leftswing", false);
			characteranim.SetBool ("idle", false);
			Debug.Log("leftswing");
			characteranim.Play ("leftswing");
		}
		//up swing
		if (y == -1) {
			characteranim.SetBool ("upswing", false);
			characteranim.SetBool ("idle", false);
			characteranim.Play ("upswing");
			Debug.Log("upswing");
		}
		//down swing
		if (y == 1 ) {
			characteranim.SetBool ("downswing", false);
			characteranim.SetBool ("idle", false);
			characteranim.Play ("downswing");
			Debug.Log("downswing");
		}

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.W))
			transform.Rotation = new Vector3(0f, 0f, 1f);
		else if (Input.GetKeyDown(KeyCode.S))
			transform.Rotation = new Vector3(0f, 0f, -1f);
		else if (Input.GetKeyDown(KeyCode.A))
			transform.Rotation = new Vector3(1f, 0f, 0f);
		else if (Input.GetKeyDown(KeyCode.D))
			transform.Rotation = new Vector3(-1f, 0f, 0f);
	}
}

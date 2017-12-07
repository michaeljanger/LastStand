using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2killed : MonoBehaviour {
	public GameObject object1;
	public GameObject object2;
	public bool p2alive;
	// Use this for initialization
	void Start () {
		p2alive = true;
	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider other){
		Debug.Log ("P1 col");
		if (other.gameObject.CompareTag("PlayerTag") && p2alive == true)
		{
			Debug.Log ("killed by P1");
			Instantiate(object1, transform.position, transform.rotation);
			Instantiate(object2, transform.position, transform.rotation);
			Destroy(gameObject);
			p2alive = false;
		}
	}
}
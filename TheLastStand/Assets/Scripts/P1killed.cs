using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1killed : MonoBehaviour {
	public GameObject object1;
	public GameObject object2;
	public bool p1alive;
	// Use this for initialization
	void Start () {
		p1alive = true;
	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider other){
		Debug.Log ("P2 col");
		if (other.gameObject.CompareTag("Player2Tag") && p1alive == true)
		{
			Debug.Log ("killed by P2");
			Destroy(gameObject);
			Instantiate(object1, transform.position, transform.rotation);
			Instantiate(object2, transform.position, transform.rotation);
			p1alive = false;
		}
	}
}
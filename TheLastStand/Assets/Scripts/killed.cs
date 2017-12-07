using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killed : MonoBehaviour {
	public GameObject object2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other){
		Debug.Log ("col enemy");
		if (other.gameObject.CompareTag("PlayerTag"))
		{
			Debug.Log ("killed enemy");
			Instantiate(object2, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}
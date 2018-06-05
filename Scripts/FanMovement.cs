using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanMovement : MonoBehaviour {
	public int power = 30;
	// Use this for initialization
	void OnTriggerStay (Collider col) 
	{
		Rigidbody rigidBody = col.gameObject.GetComponent<Rigidbody>();
		if (rigidBody != null) 
		{
			rigidBody.AddForce (transform.forward * power);
		}	
	}
	
}

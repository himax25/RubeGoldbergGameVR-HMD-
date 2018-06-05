using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineRebounce : MonoBehaviour {

	float bounceHight = 10;
	void OnTriggerStay(Collider col) 
	{
		Rigidbody rigidBody = col.gameObject.GetComponent<Rigidbody>();
		if (rigidBody.CompareTag("Throwable"))
		{
			//rigidBody.AddForce(transform.forward*);
			Vector3 velocity = rigidBody.velocity;
			rigidBody.velocity = new Vector3(velocity.x, -velocity.y, velocity.z);
			rigidBody.AddForce (transform.forward*bounceHight);
		}
	}
}

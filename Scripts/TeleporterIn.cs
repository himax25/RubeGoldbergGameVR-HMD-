using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterIn : MonoBehaviour {

	public GameObject signBoard;
	// Reference the other teleporter to get the destination of the Teleporter;
	public GameObject destinationTeleporter;
	// Define audio effect
	public AudioSource teleportAudioSource; 
	public int power = 30;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Rotate the signboard
		signBoard.transform.Rotate(Vector3.up * (Time.deltaTime*180), Space.World);	
	}
	void OnTriggerStay (Collider col) 
	{
		Rigidbody rigidBody = col.gameObject.GetComponent<Rigidbody>();
		if (rigidBody.CompareTag ("Throwable"))
		{
			teleportAudioSource.Play();
			rigidBody.position = destinationTeleporter.transform.position; 
			Vector3 velocity = rigidBody.velocity;
			rigidBody.velocity = new Vector3(velocity.x, -velocity.y, velocity.z);
			rigidBody.AddForce (transform.forward * power);
		}
	}
}

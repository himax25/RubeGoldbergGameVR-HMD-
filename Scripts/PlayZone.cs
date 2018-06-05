using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayZone : MonoBehaviour {
	// The place to start the game
	public bool rightLocation;
	// Use this for initialization
	void Start () 
	{
		rightLocation = false;	
	}
	
	// The Player is only able to throw the ball in the platform to set the value as true.
	void OnTriggerEnter (Collider col)
	{
		if (col.tag == "Throwable")
		{
			rightLocation = true;
		}
	}
	void OnTriggerExit (Collider col)
	{
		if (col.tag == "Throwable")
		{
			rightLocation = false;
		}
	}
}

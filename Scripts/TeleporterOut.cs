using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterOut : MonoBehaviour {

	public GameObject signBoard;
	
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour {

	//Create a reference to the StarPoofPrefab
	public GameObject starPoof;
	public GameObject starInstance;
	public AudioSource audioSource;
	public GameManager gameManager;
	// Use this for initialization
	void Start () 
	{
		gameManager.SetCountText (); // for displaying the score	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//rotation star 180 degree every second
		starInstance.transform.Rotate(Vector3.up * (Time.deltaTime*180), Space.World);	
	}

	void OnTriggerStay (Collider col)
	{
		if (col.gameObject.CompareTag ("Throwable") && gameManager.gameActive)
		{
			Rigidbody rB = col.GetComponent<Rigidbody>();	
			if (!rB.isKinematic)
			{
				audioSource.Play();
				// instantiate the starPoof Prefab where this star is located
				Instantiate (starPoof, transform.position, Quaternion.Euler(-90, 0, 0));
				// Make sure the poof animates vertically
				gameManager.GetPoint(); // Calculate point
				gameManager.SetCountText (); // Display point;
				// Destroy the star. 
				starInstance.SetActive(false);
			}
		}
	}
}

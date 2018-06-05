using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public GameManager gameManager;
	public GameObject instructionInfo;
	public AudioSource audioSource;	
	public Rigidbody rigidBody;
	public Renderer ballRenderer;
	public Material activeMaterial;
	public Material inactiveMaterial;
	public Transform ballStart;
	// Time sleep for reset as 5 sec
	public float resetInSecond;


	// Use this for initialization
	void Start () 
	{
		ballRenderer = GetComponent<Renderer>();
		ResetPosition ();	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!gameManager.gameActive) 
		{
			ballRenderer.material = inactiveMaterial;
		} else 
		{
			ballRenderer.material = activeMaterial;
		}	
	}

	// Ball Bound Effect
	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.CompareTag("Trampoline"))
		{
			Vector3 velocity = rigidBody.velocity;
			velocity = new Vector3(velocity.x, -velocity.y, velocity.z);
			rigidBody.AddForce (transform.forward * 300);
		}
		else if (col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("Building_Structure"))
		{
			audioSource.Play();	
		}
		// Reset ball's position if the ball is located at Teezone, Playzone.
		else if (col.gameObject.CompareTag("Tee") && gameManager.gameActive)
		{
			ResetPosition();	
		}
	}
	public void ResetPosition()
	{
		ResetPhysics();
		// Locate the initial ball location with inactive ball material
		transform.position = ballStart.position;
		transform.rotation = Quaternion.identity;
		gameManager.gameActive = false;
		ballRenderer.material = inactiveMaterial;

	}
		private void ResetPhysics ()
	{
		rigidBody.angularVelocity = Vector3.zero;
		rigidBody.velocity = Vector3.zero;
		rigidBody.isKinematic = false;
	}
	public void GameOn()
	{
		// Trigger the game to start by setting active material of the ball
		gameManager.gameActive = true;
		instructionInfo.SetActive(false);
		ballRenderer.material = activeMaterial;
	}
}

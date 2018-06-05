using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour {

	public GameObject goalPoof;
	public AudioSource goalAudioSource;
	public Text levelEndMessage;
	public Text levelUpMsg;
	public GameManager gameManager;
	
	
	void OnTriggerStay (Collider col) 
	{
		if (col.gameObject.CompareTag("Throwable"))
		{
			Rigidbody rigidBody = col.gameObject.GetComponent<Rigidbody>();
			if (!rigidBody.isKinematic)
			{
				Instantiate (goalPoof, transform.position, Quaternion.Euler(-90, 0, 0));
				// Make sure the poof animates vertically
				goalAudioSource.Play();
				SetMessageOnCam();        // for displaying the level end message on the Camera	
				rigidBody.gameObject.SetActive(false);
				gameManager.gameActive = false;
				gameManager.LoadLevel(); // Call Levelup module
			}
		}
	}

	void SetMessageOnCam ()
	{
		if (gameManager.level.Equals(4))
		{
			levelEndMessage.text = "Congraturation. \n Can you play again?";
		} else
		{
		levelEndMessage.text = "Mission Completed! \n Challenge to next level!";
		}
	}
}

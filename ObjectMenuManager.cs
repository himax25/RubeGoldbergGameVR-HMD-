using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectMenuManager : MonoBehaviour {

	public List<GameObject> objectList;	//handled automatically at start
	public List<GameObject> objectPrefabList;	//set manually in inspector and MUST match order of scene menu objects

	public int currentObject = 0;
	// Initialize the number of each game object
	public int[] noOfObj = {0,0,0,0}; 
	public Text numberOfObjects;
	public GameManager gameManager;

	// Display Object Menu to choose
	public bool isActive = false;

	// Use this for initialization
	void Start () {
		// Generate Object items
		foreach(Transform child in transform)
		{
			objectList.Add(child.gameObject);
		}

		// Hide all items
		foreach (GameObject obj in objectList)
		{
			obj.SetActive (false);
		} 
	}

	public void MenuLeft()
	{
		objectList[currentObject].SetActive(false);
		currentObject --;
		if(currentObject <0)
		{
			currentObject = objectList.Count - 1;
		}
		// Only show if the total number of each game object is less than Max. For instance, #of each game object at Level 2 is 2 as Max for each object.
		if (noOfObj[currentObject] < gameManager.level) 
		{
			objectList[currentObject].SetActive(true);
		}
	}
	public void MenuRight()
	{
		objectList[currentObject].SetActive(false);
		currentObject ++;
		if(currentObject > objectList.Count -1)
		{
			currentObject = 0;
		}
		// Only show if the total number of each game object is less than Max. For instance, #of each game object at Level 2 is 2 as Max for each object.
		if (noOfObj[currentObject] < gameManager.level) 
		{
			objectList[currentObject].SetActive(true);
		}
	}
	public void SpawnCurrentObject()
	{
		// Only show if the total number of each game object is less than Max. For instance, #of each game object at Level 2 is 2 as Max for each object.
		if (noOfObj[currentObject] < gameManager.level) 
		{
			noOfObj[currentObject] += 1;
			objectList[currentObject].SetActive(true);
			Instantiate(objectPrefabList[currentObject],
				objectList[currentObject].transform.position,
				objectList[currentObject].transform.rotation);
		}
	}

	// Switch the menu display)
	public void TurnOnOffMenu()
	{
		//if the value of 'isActive' is False, then only true.
		isActive ^= true;
		if (!isActive && !gameManager.gameActive)
		{
			//Turn on the menu of objects
			objectList [currentObject].SetActive (true);
		} else {
			//Turn off the menu of objects
			foreach (GameObject obj in objectList) 
			{
				obj.SetActive (false);
			}
		}
	}
	// Update is called once per frame
	void Update () 
	{
		if(isActive && !gameManager.gameActive)
		{
			ShowNumberOfObjects();
		} else
		{
			numberOfObjects.text = "";
		}

	}
	void ShowNumberOfObjects()
	{
		// This information is to show how many game object the play left on the Camera screen. 
		switch (gameManager.level) {
			case 1:
				// There is only the 1st game object to be avialiable at level 1.
				numberOfObjects.text = 
				"Number of Game object you have: \n \n" +
			   	" Metal Plank   = " + noOfObj[0].ToString() + "/" + gameManager.level.ToString();
			   	break;
			case 2:
				// There are the 1st & 2nd game objects to be avialiable at level 2.
				numberOfObjects.text = 
				"Number of Game object you have: \n \n" +
			   	" Metal Plank   = " + noOfObj[0].ToString() + "/" + gameManager.level.ToString() + 
				"\n Fan                = " + noOfObj[1].ToString() + "/" + gameManager.level.ToString();
			   	break;
			case 3:
				// There are the 1st, 2nd, & 3rd game objects to be avialiable at level 3.
				numberOfObjects.text = 
				"Number of Game object you have: \n \n" +
			   	" Metal Plank   = " + noOfObj[0].ToString() + "/" + gameManager.level.ToString() + 
				"\n Fan                = " + noOfObj[1].ToString() + "/" + gameManager.level.ToString() +
			   	"\n Tube Curve   = " + noOfObj[2].ToString() + "/" + gameManager.level.ToString();
			   	break;
			case 4:
				// There are the 1st, 2nd, 3rd, & 4th game objects to be avialiable at level 4.
				numberOfObjects.text = 
				"Number of Game object you have: \n \n" +
			   	" Metal Plank   = " + noOfObj[0].ToString() + "/" + gameManager.level.ToString() + 
				"\n Fan                = " + noOfObj[1].ToString() + "/" + gameManager.level.ToString() +
			   	"\n Tube Curve   = " + noOfObj[2].ToString() + "/" + gameManager.level.ToString() +
				"\n Trampoline   = " + noOfObj[3].ToString() + "/" + gameManager.level.ToString(); 
			   	break;
		}
	}
}
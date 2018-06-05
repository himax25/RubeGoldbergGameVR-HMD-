using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	public Ball ball;
	// Parameter for level
	public int level = 1;
	// Text vlaues for game record
	public Text level1Record;
	public Text level2Record;
	public Text level3Record;
	public Text level4Record;	
	// Level title at the Scoreboard
	public Text levelMsg; 
	// Parameter for score /w Message
	public bool gameActive;
	public Text scoreMsg;
	public Text timeRecord;
	private int point;
	private float timer;
	// Use this for initialization
	void Start () 
	{
		point = 0;
		timer = 0.00f;
		gameActive = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gameActive)
		{
			timer += Time.deltaTime;
			timeRecord.text = "Timer: " + timer.ToString("F1") + " Sec.";
		}
	}
	
	public void LoadLevel()
	{
		string sceneName = "";
		if (level < 5) 
		{
			level +=1;
			switch(level) {
				case 2: 
					// Store Level 1 score info with time record
					UpdateLevelScore("Level1", point.ToString() + " Points ( " + timer.ToString("F0") + " Sec.)");
					//Loading next level
					sceneName = "Level2";
					break;
				case 3:
					// Store Level 2 score info with time record
					UpdateLevelScore("Level2", point.ToString() + " Points ( " + timer.ToString("F0") + " Sec.)");
					//Loading next level
					sceneName = "Level3";
					break;
				case 4:
					// Store Level 3 score info with time record
					UpdateLevelScore("Level3", point.ToString() + " Points ( " + timer.ToString("F0") + " Sec.)");
					//Loading next level
					sceneName = "Level4";
					break;
				case 5:
					// Store Level 4 score info with time record
					UpdateLevelScore("Level4", point.ToString() + " Points ( " + timer.ToString("F0") + " Sec.)");
					//Loading next level
					sceneName = "Level1";
					level = 1;
					break;	
			}
			SteamVR_LoadLevel.Begin(sceneName);
		}	
	}
	public void SetCountText()
	{
		levelMsg.text = "Game Level: " + level.ToString();
		scoreMsg.text = "Score: " + point.ToString();
		//Loading previous score info 
		level1Record.text = "<b>[Level 1]    </b>" + PlayerPrefs.GetString("Level1");
		level2Record.text = "<b>[Level 2]    </b>" + PlayerPrefs.GetString("Level2");
		level3Record.text = "<b>[Level 3]    </b>" + PlayerPrefs.GetString("Level3");
		level4Record.text = "<b>[Level 4]    </b>" + PlayerPrefs.GetString("Level4");
	}
	public void GetPoint()
	{
		point += 10;
	}
	void UpdateLevelScore(string levelNo, string scoreValue)
	{
		PlayerPrefs.SetString(levelNo, scoreValue);
	}
}
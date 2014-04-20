﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject Player;
	private PlayerScript m_playerScript;
	public int intScore = 0;
	public int intPlayerLives = 5;
	private GameObject[] m_moveablePlatforms;

	public GUISkin NeonKnightGUI;

	void Start () 
	{
		m_moveablePlatforms = GameObject.FindGameObjectsWithTag("MoveablePlatform");

		Player = GameObject.Find("NeonKnight"); 
		m_playerScript = Player.GetComponent<PlayerScript>();

		intPlayerLives *= 2;
	}

	void Update () 
	{
		if(intPlayerLives <= 0)
			Application.LoadLevel("LoseScreen");
	}

	void OnGUI()
	{
		GUI.skin = NeonKnightGUI;
		GUI.Label(new Rect (0, 0, 170, 50), "Lives: " + intPlayerLives/2 + "");
		GUI.Label(new Rect (Screen.width / 2 - 100, 10, 200, 50), "Score: " + intScore + "");
	}

	public void KillPlayer()
	{
		Player.transform.position = m_playerScript.StartingPosition;
		intPlayerLives--;

		ResetPlatformPositions();
	}

	public void ResetPlatformPositions()
	{
		foreach(GameObject platform in m_moveablePlatforms)
		{
			if(platform.GetComponent<HorizontalPlatformBehavior>() != null)
				platform.transform.position = platform.GetComponent<HorizontalPlatformBehavior>().GetStartPosition();
			if(platform.GetComponent<VerticalPlatformBehavior>() != null)
				platform.transform.position = platform.GetComponent<VerticalPlatformBehavior>().GetStartPosition();
		}
	}
	void IncreaseScore(Collider2D collider)
	{
		switch(collider.tag)
		{
		case "SmallCollect":
			intScore += 100;
			break;
		case "LargeCollect":
			intScore += 300;
			break;
		}
	}
}

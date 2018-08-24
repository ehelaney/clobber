using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCanvas : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void OnGoToGame()
	{
		FindObjectOfType<GameStateEngine>().ChangeGameState(GameStates.Main);
	}

	public void OnGoToCredits()
	{
		FindObjectOfType<GameStateEngine>().ChangeGameState(GameStates.Credits);
	}
}

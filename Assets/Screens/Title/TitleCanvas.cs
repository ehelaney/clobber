using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCanvas : MonoBehaviour 
{
	public GameScene creditsScene;

	public GameEventNoParams startGameEvent;

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
		startGameEvent.Raise();
	}

	public void OnGoToCredits()
	{
		GameSceneController.Instance.ChangeScene(creditsScene);
	}
}

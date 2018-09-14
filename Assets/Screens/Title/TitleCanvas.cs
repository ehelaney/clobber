using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCanvas : MonoBehaviour 
{
	public GameScene firstLevelScene;
	public GameScene creditsScene;

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
		GameSceneController.Instance.ChangeScene(firstLevelScene);
	}

	public void OnGoToCredits()
	{
		GameSceneController.Instance.ChangeScene(creditsScene);
	}
}

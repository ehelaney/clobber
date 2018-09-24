using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Events;

public class GameSceneController : ScriptableSingleton<GameSceneController> 
{
	private GameScene currentScene = null;
	public GameScene CurrentScene
	{
		get
		{
			return currentScene;
		}
	}

	public void ChangeScene(GameScene newScene)
	{
		SceneManager.LoadScene(newScene.SceneName, LoadSceneMode.Single);
		currentScene = newScene;
	}
}
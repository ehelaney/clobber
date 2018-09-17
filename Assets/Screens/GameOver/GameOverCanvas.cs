using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCanvas : MonoBehaviour
{
	public GameScene titleScene;

	public void OnBackToStart()
	{
		GameSceneController.Instance.ChangeScene(titleScene);
	}
}

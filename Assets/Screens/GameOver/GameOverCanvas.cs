using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCanvas : MonoBehaviour
{
	public void OnBackToStart()
	{
		FindObjectOfType<GameStateEngine>().ChangeGameState(GameStates.Title);
	}
}

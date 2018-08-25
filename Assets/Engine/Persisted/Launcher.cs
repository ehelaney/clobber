using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
	public GameStates launchingState;
	
	// Update is called once per frame
	void Update ()
	{
		FindObjectOfType<GameStateEngine>().ChangeGameState(launchingState);
		Destroy(this);
	}
}

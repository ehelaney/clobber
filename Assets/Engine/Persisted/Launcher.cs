﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
	public GameStates launchingState;
	
	// Update is called once per frame
	void Update ()
	{
		//this is all throwaway code until we have something more properly transitioning the levels
		PlayerInfo.Instance.StartGame();
		FindObjectOfType<GameStateEngine>().ChangeGameState(launchingState);
		Destroy(this);
	}
}

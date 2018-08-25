using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

public class GameStateEngine : MonoBehaviour
{

	#region Game State Engine

	private FiniteStateMachine _gameStateMachine = new FiniteStateMachine();

	public GameStates CurrentState
	{
		get
		{
			return _gameStateMachine.GetCurrentState<GameStates>();
		}
	}

	public void ChangeGameState(GameStates newState)
	{
		Debug.Log("ChangeGameState: " + newState);
		_gameStateMachine.ChangeState<GameStates>(newState);
	}

	public void AddListener(GameStates state, UnityAction action, bool away)
	{
		_gameStateMachine.AddStateListener<GameStates>(state, action, away);
	}

	public void AddAllStateListener(UnityAction action)
	{
		_gameStateMachine.AddTransitionListener(action);
	}

	#endregion Game State Engine

	#region MonoBehaviour

	void Awake()
	{
		int stateCount = Enum.GetNames(typeof(GameStates)).Length;
		for (int i = 0; i < stateCount; ++i)
		{
			_gameStateMachine.AddStates<GameStates>((GameStates)i);
		}
	}

	#endregion MonoBehaviour
}
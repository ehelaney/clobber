using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class GameEventListenerInt : GameEventListener<int>
{
	[SerializeField]
	public GameEventInt gameEvent;

	public UnityEventInt eventResponse;

	private void OnEnable()
	{
		response = eventResponse;
		gameEvent.RegisterListener(this);
	}

	private void OnDisable()
	{
		gameEvent.UnregisterListener(this);
	}
}

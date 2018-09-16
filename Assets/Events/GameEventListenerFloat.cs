using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class GameEventListenerFloat : GameEventListener<float>
{
	[SerializeField]
	public GameEventFloat gameEvent;

	public UnityEventFloat floatEventResponse;

	private void OnEnable()
	{
		response = floatEventResponse;
		gameEvent.RegisterListener(this);
	}

	private void OnDisable()
	{
		gameEvent.UnregisterListener(this);
	}
}

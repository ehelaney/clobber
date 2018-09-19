using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Game Event Listener", menuName = "Events/Int Listener")]
public class GameEventListenerScriptableObjectInt : GameEventListenerScriptableObject<int>
{
	[SerializeField]
	public GameEventInt gameEvent;

	public UnityEventInt eventResponse;

	private void OnEnable()
	{
		response = eventResponse;
		if (gameEvent != null) gameEvent.RegisterListener(this);
	}

	private void OnDisable()
	{
		if (gameEvent != null) gameEvent.UnregisterListener(this);
	}
}

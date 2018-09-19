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
		gameEvent.RegisterListener(this);
	}

	private void OnDisable()
	{
		gameEvent.UnregisterListener(this);
	}
}

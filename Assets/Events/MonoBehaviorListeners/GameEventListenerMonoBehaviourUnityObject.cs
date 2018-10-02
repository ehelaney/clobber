using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class GameEventListenerMonoBehaviourUnityObject : GameEventListenerMonoBehaviour<UnityEngine.Object>
{
	[SerializeField]
	public GameEventUnityObject gameEvent;

	public UnityEventUnityObject unityObjectEventResponse;

	private void OnEnable()
	{
		response = unityObjectEventResponse;
		gameEvent.RegisterListener(this);
	}

	private void OnDisable()
	{
		gameEvent.UnregisterListener(this);
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Game Event Listener", menuName = "Events/Float Listener")]
public class GameEventListenerScriptableObjectUnityObject : GameEventListenerScriptableObject<UnityEngine.Object>
{
	[SerializeField]
	public GameEventUnityObject gameEvent;

	public UnityEventUnityObject unityObjectEventResponse;

	private void OnEnable()
	{
		response = unityObjectEventResponse;
		if (gameEvent != null) gameEvent.RegisterListener(this);
	}

	private void OnDisable()
	{
		if (gameEvent != null) gameEvent.UnregisterListener(this);
	}
}

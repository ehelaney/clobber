using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerScriptableObject<T> : ScriptableObject, IGameEventListener<T>
{
	[SerializeField]
	public UnityEvent<T> response;

	public void OnEventRaised(T val)
	{
		response.Invoke(val);
	}
}
using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerNoParams
{
	[SerializeField]
	public GameEventNoParams gameEvent;

	[SerializeField]
	public UnityEvent response;

	private void OnEnable()
	{
		gameEvent.RegisterListener(this);
	}

	private void OnDisable()
	{
		gameEvent.UnregisterListener(this);
	}



	public void OnEventRaised()
	{
		response.Invoke();
	}
}
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event", menuName = "Events/No Parameters")]
public class GameEventNoParams : ScriptableObject
{
	private List<GameEventListenerNoParams> listeners = new List<GameEventListenerNoParams>();

	public void Raise()
	{
		for (int i = listeners.Count - 1; i >= 0; i--)
		{
			listeners[i].OnEventRaised();
		}
	}

	public void RegisterListener(GameEventListenerNoParams listener)
	{
		listeners.Add(listener);
	}

	public void UnregisterListener(GameEventListenerNoParams listener)
	{
		listeners.Remove(listener);
	}
}
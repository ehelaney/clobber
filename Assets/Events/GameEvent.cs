using System.Collections.Generic;
using UnityEngine;

// taken from: https://www.raywenderlich.com/6183-scriptable-objects-tutorial-getting-started

public class GameEvent<T> : ScriptableObject
{
	protected List<GameEventListener<T>> listeners = new List<GameEventListener<T>>();

	public void Raise(T val)
	{
		for (int i = listeners.Count - 1; i >= 0; i--)
		{
			listeners[i].OnEventRaised(val);
		}
	}

	public void RegisterListener(GameEventListener<T> listener)
	{
		listeners.Add(listener);
	}

	public void UnregisterListener(GameEventListener<T> listener)
	{
		listeners.Remove(listener);
	}
}
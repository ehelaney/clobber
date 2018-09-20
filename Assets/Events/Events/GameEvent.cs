using System.Collections.Generic;
using UnityEngine;

// taken from: https://www.raywenderlich.com/6183-scriptable-objects-tutorial-getting-started

public abstract class GameEvent<T> : ScriptableObject
{
	protected List<IGameEventListener<T>> listeners = new List<IGameEventListener<T>>();

	public void Raise(T val)
	{
		for (int i = listeners.Count - 1; i >= 0; i--)
		{
			listeners[i].OnEventRaised(val);
		}
	}

	public void RegisterListener(IGameEventListener<T> listener)
	{
		listeners.Add(listener);
	}

	public void UnregisterListener(IGameEventListener<T> listener)
	{
		listeners.Remove(listener);
	}
}
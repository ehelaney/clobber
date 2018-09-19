using UnityEngine;
using System.Collections;

public interface IGameEventListener<T>
{
	void OnEventRaised(T val);
}

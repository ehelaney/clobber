using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event", menuName = "Events/Int")]
public class GameEventInt : GameEvent<int>
{
	public void Raise()
	{
		base.Raise(0);
	}
}
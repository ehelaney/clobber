using UnityEngine;
using System.Collections;

public class TransitionToGameOverScreenSuccess : RoomAction
{
	public override void Execute()
	{
		RoomSelector.Instance.GoToGameOver();
	}
}

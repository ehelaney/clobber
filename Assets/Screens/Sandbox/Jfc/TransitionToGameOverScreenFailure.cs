using UnityEngine;
using System.Collections;

public class TransitionToGameOverScreenFailure : RoomAction
{
	public override void Execute()
	{
		RoomSelector.Instance.GoToGameOver();
	}
}


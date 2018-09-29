using UnityEngine;
using System.Collections;

public class TransitionToGameOverScreen : RoomAction
{
	public override void Execute()
	{
		RoomSelector.Instance.GoToGameOver();
	}
}

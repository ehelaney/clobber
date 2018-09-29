using UnityEngine;
using System.Collections;

public class PlayerIsDead : RoomCondition
{
	public override bool ConditionMet()
	{
		return PlayerInfo.Instance.PlayerIsDead;
	}
}

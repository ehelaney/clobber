using UnityEngine;
using System.Collections;

public class AllEnemiesDead : RoomCondition
{
	public override bool ConditionMet()
	{
		return (!EnemyFactory.Instance.AnyEnemiesStillAlive());
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPointsLoot", menuName = "Loot/Points Loot Type")]
public class PointsLootType : LootType
{
	public int earnedPoints;

	public override void OnCollect()
	{
		PlayerInfo.Instance.GainPoints(earnedPoints);
	}
}
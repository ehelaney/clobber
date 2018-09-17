using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="NewHeartLoot", menuName="Loot/Heart Loot Type")]
public class HeartLootType : LootType
{
	public int heartPieces;

	public override void OnCollect()
	{
		PlayerInfo.Instance.ChangeHealth(heartPieces);
	}
}

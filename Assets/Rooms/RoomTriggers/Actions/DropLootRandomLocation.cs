using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDropLoot", menuName = "Room Action/Drop Loot Random Location")]
public class DropLootRandomLocation : RoomAction
{
	public LootTableDefinition lootTable;

	public override void Execute()
	{
		var floor = FindObjectOfType<FloorController>();
		Vector3 worldPoint = floor.GetWorldCoordinatesOfPoint(Random.Range(2, 16), Random.Range(2, 6));
		FindObjectOfType<LootSystem>().ExecuteLootTable(lootTable, worldPoint);
	}
}


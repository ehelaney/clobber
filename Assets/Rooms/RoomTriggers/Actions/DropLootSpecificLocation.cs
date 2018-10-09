using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDropLoot", menuName = "Room Action/Drop Loot Specific Location")]
public class DropLootSpecificLocation : RoomAction
{
	public LootTableDefinition lootTable;
	public Vector2Int tileLocation;

	public override void Execute()
	{
		var floor = FindObjectOfType<FloorController>();
		Vector3 worldPoint = floor.GetWorldCoordinatesOfPoint(tileLocation.x, tileLocation.y);
		FindObjectOfType<LootSystem>().ExecuteLootTable(lootTable, worldPoint);
	}
}

using UnityEngine;
using System.Collections;

public class LootSystem : MonoBehaviour
{
	public ObjectPool lootPool;

	void Start()
	{
		lootPool.Initialize();
	}

	public void OnEnemyDeath(EnemyTypeDefinition enemyDef, Vector2 pos)
	{
		ExecuteLootTable(enemyDef.LootTable, pos);
	}

	public void ExecuteLootTable(LootTableDefinition lootTable, Vector2 pos)
	{
		Debug.Log("Executing loot table: " + lootTable.HelpfulName);

		foreach (var lootRow in lootTable.LootChances)
		{
			if (lootRow.Chance > Random.value * 100f)
			{
				SpawnLoot(lootRow.LootType, pos);
				if (!lootTable.MultiDrop) break;
			}
		}
	}

	private void SpawnLoot(LootType lootType, Vector2 pos)
	{
		var newLoot = lootPool.InitNewObject().GetComponent<Loot>();
		newLoot.Initialize(lootType, pos);
	}
}

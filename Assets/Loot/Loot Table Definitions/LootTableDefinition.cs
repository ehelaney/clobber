using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLootTable", menuName = "Loot/Loot Table", order = 1)]
public class LootTableDefinition : ScriptableObject
{
	[SerializeField]
	private string helpfulName;
	public string HelpfulName
	{
		get
		{
			return helpfulName;
		}
	}

	[SerializeField]
	private bool multiDrop;
	public bool MultiDrop
	{
		get
		{
			return multiDrop;
		}
	}

	[SerializeField]
	private LootTableEntry[] lootChances;
	public LootTableEntry[] LootChances
	{
		get
		{
			return lootChances;
		}
	}
}

[Serializable]
public class LootTableEntry
{
	public LootType LootType;

	[Range(0f, 100f)]
	public float Chance;
}
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLootType", menuName = "Loot Type", order = 53)]
public class LootTypeDefinition : ScriptableObject
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
	private Sprite sprite;
	public Sprite Sprite
	{
		get
		{
			return sprite;
		}
	}

	[SerializeField]
	private float lifeTime;
	public float LifeTime
	{
		get
		{
			return lifeTime;
		}
	}

	[SerializeField]
	private LootBehaviorType behaviorType;
	public LootBehaviorType BehaviorType
	{
		get
		{
			return behaviorType;
		}
	}

	[SerializeField]
	private long behaviorValue;
	public long BehaviorValue
	{
		get
		{
			return behaviorValue;
		}
	}

}

public enum LootBehaviorType
{
	Health,
	Points
}

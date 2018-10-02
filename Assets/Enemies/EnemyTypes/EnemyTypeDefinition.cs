using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyType", menuName = "Clobber Misc/Enemy Type")]
public class EnemyTypeDefinition : ScriptableObject
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
	private int pointsForKilling;
	public int PointsForKilling
	{
		get
		{
			return pointsForKilling;
		}
	}

	[SerializeField]
	private int health;
	public int Health
	{
		get
		{
			return health;
		}
	}

	[SerializeField]
	private int collisionStrength = 1;
	public int CollisionStrength
	{
		get
		{
			return collisionStrength;
		}
	}

	[SerializeField]
	private SoundDefinition onHitSound;
	public SoundDefinition OnHitSound
	{
		get
		{
			return onHitSound;
		}
	}

	[SerializeField]
	private LootTableDefinition lootTable;
	public LootTableDefinition LootTable
	{
		get
		{
			return lootTable;
		}
	}

	public EnemyAIType aiType;
	public ProjectileWeaponDefinition weapon;
}
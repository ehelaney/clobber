using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyType", menuName = "Enemy Type", order = 51)]
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
	private SoundDefinition onHitSound;
	public SoundDefinition OnHitSound
	{
		get
		{
			return onHitSound;
		}
	}
}
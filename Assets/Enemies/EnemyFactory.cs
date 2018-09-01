using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
	public static EnemyFactory Instance { get; private set; }

	public ObjectPool enemyPool;

	public EnemyTypeDefinition[] enemyTypes;

	private Dictionary<int, EnemyTypeDefinition> enemyTypeDefMap = new Dictionary<int, EnemyTypeDefinition>();

	public EnemyDeathSystem DeathSystem;
	public EnemyHitSystem HitSystem;

	// Use this for initialization
	void Start ()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
			return;
		}

		enemyPool.Initialize();

		for (int i = 0; i < enemyTypes.Length; i++)
		{
			var enemyType = enemyTypes[i];
			for (int j = i + 1; j < enemyTypes.Length; j++)
			{
				if (enemyType.ID == enemyTypes[j].ID)
				{
					Debug.LogError("Cannot have multiple enemy type definitions with the same ID.");
					Application.Quit();
				}
			}

			enemyTypeDefMap.Add(enemyType.ID, enemyType);
		}
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public Enemy SpawnNewEnemy(int enemyID, Vector2 pos)
	{
		var newEnemy = enemyPool.InitNewObject();
		var enemy = newEnemy.GetComponent<Enemy>();
		enemy.Initialize(enemyTypeDefMap[enemyID], pos);
		return enemy;
	}

	/// <summary>
	/// This is an expensive call, don't call it in a tight loop
	/// </summary>
	/// <returns></returns>
	public bool AnyEnemiesStillAlive()
	{
		return (enemyPool.ActiveCount > 0);
	}
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
	public ObjectPool enemyPool;

	public EnemyTypeDefinition[] enemyTypes;

	private Dictionary<int, EnemyTypeDefinition> enemyTypeDefMap = new Dictionary<int, EnemyTypeDefinition>();

	// Use this for initialization
	void Start ()
	{
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
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class EnemyKilledEvent : UnityEvent<int> { }

public class EnemyFactory : Singleton<EnemyFactory>
{
	public ObjectPool enemyPool;

	public EnemyDeathSystem DeathSystem;
	public EnemyHitSystem HitSystem;
	public LootSystem LootSystem;

	public EnemyKilledEvent EnemyKilled;

	// Use this for initialization
	void Start ()
	{
		enemyPool.Initialize();

		//this is backwards, but necessary because the PlayerInfo is a globally persisted object
		EnemyKilled.AddListener(PlayerInfo.Instance.OnEnemyKilled);
	}

	public Enemy SpawnNewEnemy(EnemyTypeDefinition enemyType, Vector2 pos)
	{
		var newEnemy = enemyPool.InitNewObject();
		var enemy = newEnemy.GetComponent<Enemy>();
		enemy.Initialize(enemyType, pos);
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

	public void OnEnemyDeath(EnemyTypeDefinition enemyType, Vector2 pos)
	{
		DeathSystem.OnEnemyDeath(enemyType, pos);
		LootSystem.OnEnemyDeath(enemyType, pos);

		if (EnemyKilled != null)
		{
			EnemyKilled.Invoke(enemyType.PointsForKilling);
		}
	}
}
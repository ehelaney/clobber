using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyFactory : Singleton<EnemyFactory>
{
	public ObjectPool enemyPool;

	public EnemyDeathSystem DeathSystem;
	public EnemyHitSystem HitSystem;
	public LootSystem LootSystem;

	public GameEventInt scoredPointsEvent;

	// Use this for initialization
	void Start ()
	{
		enemyPool.Initialize();
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

		scoredPointsEvent.Raise(enemyType.PointsForKilling);
	}
}
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

	public void SpawnEnemies()
	{
		MapConfiguration map = RoomConfiguration.instance.mapConfiguration;
		Array2DEnemySpawnDefinition enemyMap = RoomConfiguration.instance.enemyMap;

		int xchunk = (map.MapSize_x / enemyMap.size.x);
		int ychunk = (map.MapSize_y / enemyMap.size.y);

		//initial take to get something functional.  I think ideally, the map should return the
		//first safe spot taking into account any walls, etc.
		Vector2 position = map.mapCenter;
		position.x -= map.MapSize_x / 2;
		position.y += map.MapSize_y / 2;
		position.x += xchunk / 2;
		position.y -= ychunk / 2;
		Vector2 initialPosition = position;

		for(int x = 0; x < enemyMap.size.x; x++)
		{
			for( int y = 0; y < enemyMap.size.y; y++)
			{
				EnemyTypeDefinition enemy = enemyMap.GetValue(x,y);
				if( null != enemy )
				{
					SpawnNewEnemy(enemy, position);
				}
				position.x += xchunk;
			}
			position.y -= ychunk;
			position.x = initialPosition.x;
		}
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
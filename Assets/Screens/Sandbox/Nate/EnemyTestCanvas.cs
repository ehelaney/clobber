using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestCanvas : MonoBehaviour
{
	public GameObject enemyPrefab;

	private List<Enemy> aliveEnemies = new List<Enemy>();

	private EnemyFactory enemyFactory;

	// Use this for initialization
	void Start ()
	{
		enemyFactory = FindObjectOfType<EnemyFactory>();	
	}

	public void OnSpawnRandomEnemy()
	{
		var nextEnemy = enemyFactory.SpawnNewEnemy(Random.Range(1, 4), new Vector2(Random.Range(-2.5f, 2.5f), Random.Range(-2.5f, 2.5f)));
		aliveEnemies.Add(nextEnemy);
	}

	public void OnKillEnemies()
	{
		foreach(var enemy in aliveEnemies)
		{
			enemy.Kill();
		}

		aliveEnemies.Clear();
	}
}

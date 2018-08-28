using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestCanvas : MonoBehaviour
{
	public GameObject enemyPrefab;

	private List<Enemy> aliveEnemies = new List<Enemy>();


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnSpawnRandomEnemy()
	{
		var nextEnemy = Instantiate(enemyPrefab, new Vector2(Random.Range(-2.5f, 2.5f), Random.Range(-2.5f, 2.5f)), Quaternion.identity, transform).GetComponent<Enemy>();
		nextEnemy.TypeDefinition = new EnemyTypeDefinition()
		{
			PointsForKilling = Random.Range(1, 1000)
		};
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

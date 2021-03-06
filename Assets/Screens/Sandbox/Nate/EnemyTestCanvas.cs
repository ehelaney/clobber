﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestCanvas : MonoBehaviour
{
	public EnemyTypeDefinition[] possibleRandomEnemyTypesToSpawn;
	public SoundDefinition soundEffectToPlay;

	private List<Enemy> aliveEnemies = new List<Enemy>();

	private EnemyFactory enemyFactory;


	// Use this for initialization
	void Start ()
	{
		enemyFactory = FindObjectOfType<EnemyFactory>();	
	}

	public void OnSpawnRandomEnemy()
	{
		if (possibleRandomEnemyTypesToSpawn.Length > 0)
		{
			var nextEnemy = enemyFactory.SpawnNewEnemy(
				possibleRandomEnemyTypesToSpawn[Random.Range(0, possibleRandomEnemyTypesToSpawn.Length)], 
				new Vector2(Random.Range(-2.5f, 2.5f), Random.Range(-2.5f, 2.5f)));
			aliveEnemies.Add(nextEnemy);
		}
	}

	public void OnKillEnemies()
	{
		foreach(var enemy in aliveEnemies)
		{
			enemy.Kill();
		}

		aliveEnemies.Clear();
	}

	public void OnDamagePlayer()
	{
		PlayerInfo.Instance.ChangeHealth(-1);
	}

	public void OnPlaySoundEffect()
	{
		SoundManager.Instance.PlaySound(soundEffectToPlay, new Vector2(Random.Range(-2.5f, 2.5f), Random.Range(-2.5f, 2.5f)));
	}
}

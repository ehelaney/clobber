using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMenu : MonoBehaviour
{
	public EnemyTypeDefinition[] possibleRandomEnemyTypesToSpawn;
	public SoundDefinition soundEffectToPlay;

	private EnemyFactory enemyFactory;

	private CanvasGroup canvasGroup;

	private bool visible = true;


	// Use this for initialization
	void Start ()
	{
		enemyFactory = FindObjectOfType<EnemyFactory>();	
		canvasGroup = GetComponent<CanvasGroup>();
		visible = false; //start with debug menu hidden
		RefreshDebugUI();
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.F7))
		{
			visible = !visible;
			RefreshDebugUI();
		}
	}

	void RefreshDebugUI()
	{
		canvasGroup.interactable = visible;
		canvasGroup.alpha = visible ? 1.0f : 0;
	}

	public void OnSpawnRandomEnemy()
	{
		if (possibleRandomEnemyTypesToSpawn.Length > 0)
		{
			enemyFactory.SpawnNewEnemy(
				possibleRandomEnemyTypesToSpawn[Random.Range(0, possibleRandomEnemyTypesToSpawn.Length)], 
				new Vector2(Random.Range(-2.5f, 2.5f), Random.Range(-2.5f, 2.5f)));
		}
	}

	public void OnSpawnEnemies()
	{
		enemyFactory.SpawnEnemies();
	}

	public void OnKillEnemies()
	{
		var foundEnemies = FindObjectsOfType<Enemy>();
		foreach(var enemy in foundEnemies)
		{
			enemy.Kill();
		}
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

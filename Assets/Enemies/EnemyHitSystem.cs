using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitSystem : MonoBehaviour
{
	public ObjectPool hitPool;

	void Start()
	{
		hitPool.Initialize();
	}

	public void OnEnemyHit(EnemyTypeDefinition enemyDef, Vector2 pos, AudioClip clip)
	{
		Debug.Log("Enemy Hit at: " + pos.ToString());

		var hit = hitPool.InitNewObject().GetComponent<EnemyHit>();
		hit.Init(pos);

		SoundManager.instance.PlayClip(clip); //play hit sound effect
	}
}

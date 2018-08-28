using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathSystem : MonoBehaviour
{
	public ObjectPool pointsPool;

	void Start()
	{
		pointsPool.Initialize();
	}

	public void OnEnemyDeath(EnemyTypeDefinition enemyDef, Vector2 pos)
	{
		Debug.Log("Enemy Died at: " + pos.ToString() + "  You get points: " + enemyDef.PointsForKilling.ToString());

		var points = pointsPool.InitNewObject().GetComponent<PointsNotification>();
		points.Init(enemyDef.PointsForKilling, pos + Vector2.up);
	}
}

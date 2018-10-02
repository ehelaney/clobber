using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class RoomSpawn
{
	public EnemyTypeDefinition enemyType;
	public SpawnPatternDefinition spawnPattern;
	public Vector2Int centerPoint;
}

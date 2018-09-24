using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "NewObstacleConfiguration", menuName = "Room/New Obstacle Configuration")]
public class ObstacleConfiguration : ScriptableObject
{

	public TileBase[] obstacle; //if more than one tiles is assigned, it will pick from them at random (with equal probability)
	public float chancePerTile; //a number [0,1] that is a % chance for if a tile is going to contain this obstacle
}

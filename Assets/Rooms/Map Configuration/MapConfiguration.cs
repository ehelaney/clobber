using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "NewMapConfiguration", menuName = "Room/New Map Configuration")]
public class MapConfiguration : ScriptableObject
{
	[Range(10, 50)]
	public int MapSize_x;

	[Range(10, 50)]
	public int MapSize_y;

	public Vector2 mapCenter;

	public Vector2 MapOrigin
	{
		get
		{
			return new Vector2(mapCenter.x - MapSize_x / 2, mapCenter.y - MapSize_y / 2);
		}
	}

	// Tiles for basic edges + outside corners
	public TileBase TopEdgeTile;
	public TileBase RightEdgeTile;
	public TileBase BottomEdgeTile;
	public TileBase LeftEdgeTile;
	
	// Inside corners
	public TileBase TopLeftInsideCornerTile;
	public TileBase TopRightInsideCornerTile;
	public TileBase BottomLeftInsideCornerTile;
	public TileBase BottomRightInsideCornerTile;
	
	// Floor
	public TileBase FloorTile;

}

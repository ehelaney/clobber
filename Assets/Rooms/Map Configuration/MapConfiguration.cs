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

	[SerializeField]
	private Vector2 mapCenter;

	public Vector2 MapOrigin
	{
		get
		{
			return new Vector2(mapCenter.x - MapSize_x / 2, mapCenter.y - MapSize_y / 2);
		}
	}

	// Tiles for basic edges + outside corners
	public TileBase TopLeftEdgeTile;
	public TileBase TopEdgeTile;
	public TileBase TopRightEdgeTile;
	public TileBase RightEdgeTile;
	public TileBase BottomRightEdgeTile;
	public TileBase BottomEdgeTile;
	public TileBase BottomLeftEdgeTile;
	public TileBase LeftEdgeTile;
	
	// Inside corners
	public TileBase TopLeftInsideTile;
	public TileBase TopRightInsideTile;
	public TileBase BottomLeftInsideTile;
	public TileBase BottomRightInsideTile;

	// Center Tile (no edges)
	public TileBase MiddleTile;
	
	// Floor
	public TileBase FloorTile;

}

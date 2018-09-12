using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapController : MonoBehaviour 
{
	[Range(10, 50)]
	public int MapSize_x;

	[Range(10, 50)]
	public int MapSize_y;

	public Vector3Int MapOrigin;

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


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}

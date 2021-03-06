﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
public class WallController : MonoBehaviour 
{

	public enum WallType
	{
		Null = 0,
		Empty,
		CenterWall,
		LeftEdgeWall,
		RightEdgeWall,
		BottomEdgeWall,
		TopEdgeWall,
		TopLeftInsideWall,
		TopRightInsideWall,
		BottomLeftInsideWall,
		BottomRightInsideWall
	}
	private MapConfiguration mapGenerator;
	private ObstacleConfiguration[] obstacleConfiguration;

	private Tilemap tilemap;
	
	private WallType[,] tileSchematic;

	private int MapSize_x;
	private int MapSize_y;

	// Use this for initialization
	void Start () 
	{
		tilemap = GetComponent<Tilemap>();
		mapGenerator = RoomConfiguration.Instance.mapConfiguration;
		obstacleConfiguration = RoomConfiguration.Instance.obstacleConfigurations;

		MapSize_x = mapGenerator.MapSize_x;
		MapSize_y = mapGenerator.MapSize_y;

		tilemap.size = new Vector3Int(MapSize_x, MapSize_y, 0);

		tileSchematic = GenerateSchematic();
		FillTilemap(tileSchematic);
	}

	WallType[,] GenerateSchematic()
	{
		WallType [,] schematic = new WallType[MapSize_x, MapSize_y];
		
		Random.InitState(42);

		// Fill edges
		for (int x = 0; x < MapSize_x; x++)
		{
			schematic[x, 0] = WallType.BottomEdgeWall; 
			schematic[x, MapSize_y - 1] = WallType.TopEdgeWall;
		}
		for (int y = 0; y < MapSize_y; y++)
		{
			schematic[0, y] = WallType.LeftEdgeWall;
			schematic[MapSize_x - 1, y] = WallType.RightEdgeWall; 
		}

		// Set corners
		schematic[0, 0] = WallType.BottomLeftInsideWall; 
		 schematic[MapSize_x - 1, 0] = WallType.BottomRightInsideWall; 
		 schematic[0, MapSize_y - 1] = WallType.TopLeftInsideWall;
		schematic[MapSize_x - 1, MapSize_y - 1] = WallType.TopRightInsideWall;

		return schematic;
	}

	void FillTilemap(WallType[,] schematic)
	{
		for(int x = 0; x < schematic.GetLength(0); x++)
		{
			for (int y = 0; y < schematic.GetLength(1); y++)
			{
				switch (schematic[x,y])
				{
					case WallType.LeftEdgeWall:
					{
						PaintTile(x, y, mapGenerator.LeftEdgeTile);
						break;
					}
					case WallType.TopEdgeWall:
					{
						PaintTile(x, y, mapGenerator.TopEdgeTile);
						break;
					}
					case WallType.RightEdgeWall:
					{
						PaintTile(x, y, mapGenerator.RightEdgeTile);
						break;
					}
					case WallType.BottomEdgeWall:
					{
						PaintTile(x, y, mapGenerator.BottomEdgeTile);
						break;
					}
					case WallType.TopLeftInsideWall:
					{
						PaintTile(x, y, mapGenerator.TopLeftInsideCornerTile);
						break;
					}
					case WallType.TopRightInsideWall:
					{
						PaintTile(x, y, mapGenerator.TopRightInsideCornerTile);
						break;
					}
					case WallType.BottomLeftInsideWall:
					{
						PaintTile(x, y, mapGenerator.BottomLeftInsideCornerTile);
						break;
					}
					case WallType.BottomRightInsideWall:
					{
						PaintTile(x, y, mapGenerator.BottomRightInsideCornerTile);
						break;
					}
					case WallType.Null:
					{
							foreach (var obstacleConfig in obstacleConfiguration)
							{
								if (Random.value < obstacleConfig.chancePerTile)
								{
									PaintTile(x, y, obstacleConfig.obstacle[Random.Range(0, obstacleConfig.obstacle.Length)]);
									break;
								}
							}
							break;
					}
					default:
					{
						Debug.Log(string.Format("Un-paintable tile[{0}] at X:{1}, Y:{2}.", System.Enum.GetName(typeof(WallType), schematic[x, y]), x, y));
						break;
					}
				}
			}
		}
	}

	void PaintTile(int x, int y, TileBase tile)
	{
		tilemap.SetTile(new Vector3Int(x, y, 0), tile);
	}
}

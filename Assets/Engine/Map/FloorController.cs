using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
public class FloorController : MonoBehaviour 
{
	private Tilemap map;

	private MapGenerator mapGenerator;

	// Use this for initialization
	void Start () 
	{
		map = GetComponent<Tilemap>();
		mapGenerator = FindObjectOfType<MapGenerator>();

		map.size = new Vector3Int(mapGenerator.MapSize_x, mapGenerator.MapSize_y, 0);
		transform.parent.transform.position = mapGenerator.MapOrigin;

		FillTilemap();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void FillTilemap()
	{
		for(int x = 0; x < mapGenerator.MapSize_x; x++)
		{
			for (int y = 0; y < mapGenerator.MapSize_y; y++)
			{
				map.SetTile(new Vector3Int(x, y, 0), mapGenerator.FloorTile);
			}
		}
	}
}

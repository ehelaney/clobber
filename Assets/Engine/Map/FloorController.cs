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
		mapGenerator = transform.parent.parent.gameObject.GetComponent<MapGenerator>();

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
				map.SetTile(mapGenerator.MapOrigin + new Vector3Int(x, y, 0), mapGenerator.FloorTile);
			}
		}
	}
}

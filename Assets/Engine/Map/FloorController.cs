using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
public class FloorController : MonoBehaviour 
{
	private Tilemap map;

	private MapController mapController;

	// Use this for initialization
	void Start () 
	{
		map = GetComponent<Tilemap>();
		mapController = transform.parent.parent.gameObject.GetComponent<MapController>();

		FillTilemap();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void FillTilemap()
	{
		for(int x = 0; x < mapController.MapSize_x; x++)
		{
			for (int y = 0; y < mapController.MapSize_y; y++)
			{
				map.SetTile(mapController.MapOrigin + new Vector3Int(x, y, 0), mapController.FloorTile);
			}
		}
	}
}

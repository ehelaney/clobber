using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class CameraThreshold : MonoBehaviour
{

	// Use this for initialization
	void Awake ()
	{
		var mapConfig = RoomConfiguration.Instance.mapConfiguration;
		var origin = mapConfig.MapOrigin;

		Vector2[] newPoints = new Vector2[4];
		newPoints[0] = origin;
		newPoints[1] = new Vector2(origin.x + mapConfig.MapSize_x, origin.y);
		newPoints[2] = new Vector2(origin.x + mapConfig.MapSize_x, origin.y + mapConfig.MapSize_y);
		newPoints[3] = new Vector2(origin.x, origin.y + mapConfig.MapSize_y);

		GetComponent<PolygonCollider2D>().SetPath(0, newPoints);
	}
	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileThresholds : MonoBehaviour
{
	public GameObject top;
	public GameObject bottom;
	public GameObject left;
	public GameObject right;

	public float distanceFromMap = 5.0f;

	void Awake ()
	{
		var mapConfig = RoomConfiguration.Instance.mapConfiguration;
		var mapCenter = mapConfig.mapCenter;

		float verticalDiff = ((mapConfig.MapSize_y / 2f) + distanceFromMap);
		top.transform.position = new Vector2(mapCenter.x, mapCenter.y + verticalDiff);
		bottom.transform.position = new Vector2(mapCenter.x, mapCenter.y - verticalDiff);

		float horizontalDiff = ((mapConfig.MapSize_x / 2f) + distanceFromMap);
		left.transform.position = new Vector2(mapCenter.x - horizontalDiff, mapCenter.y);
		right.transform.position = new Vector2(mapCenter.x + horizontalDiff, mapCenter.y);

		top.GetComponent<BoxCollider2D>().size = new Vector2(horizontalDiff * 2f, 1f);
		bottom.GetComponent<BoxCollider2D>().size = new Vector2(horizontalDiff * 2f, 1f);
		left.GetComponent<BoxCollider2D>().size = new Vector2(1f, verticalDiff * 2f);
		right.GetComponent<BoxCollider2D>().size = new Vector2(1f, verticalDiff * 2f);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileThreshold : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.layer == 14 ||
			col.gameObject.layer == 15) //if it's a bullet
		{
			col.gameObject.SetActive(false);
		}
	}
}

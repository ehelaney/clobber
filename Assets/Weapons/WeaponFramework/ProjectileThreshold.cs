using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileThreshold : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.layer == 8) //if it's a bullet
		{
			col.gameObject.SetActive(false);
		}
	}
}

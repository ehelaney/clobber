using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetPreloads : MonoBehaviour
{
	private void Start()
	{
		Resources.LoadAll("Singletons");
	}
}

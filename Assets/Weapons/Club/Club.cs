using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour 
{
	private Vector3 localPos;
	// Use this for initialization
	void Start () 
	{
		// Cache the current location relative to the parent
		localPos = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Set location relative to parent
		transform.position = transform.parent.position;
		transform.localPosition = localPos;
	}
}

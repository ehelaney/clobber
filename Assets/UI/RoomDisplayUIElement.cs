using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDisplayUIElement : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		try
		{
			GetComponent<UnityEngine.UI.Text>().text = "Room: " + RoomSelector.Instance.CurrentRoom.SceneName;
		}
		catch(System.IndexOutOfRangeException ex)
		{
			GetComponent<UnityEngine.UI.Text>().text = "Scene name out of range";
		}
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}

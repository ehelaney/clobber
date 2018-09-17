using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsCanvas : MonoBehaviour 
{
	public GameScene titleScene;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void OnGoBack()
	{
		GameSceneController.Instance.ChangeScene(titleScene);
	}
}

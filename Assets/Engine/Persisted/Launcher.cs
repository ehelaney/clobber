using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : Singleton<Launcher>
{
	public GameScene launchingScene;
	
	// Update is called once per frame
	void Update ()
	{
		if (LaunchFromScene.IsSceneSet()) { launchingScene = LaunchFromScene.Scene; }

		//this is all throwaway code until we have something more properly transitioning the levels
		PlayerInfo.Instance.StartGame();
		GameSceneController.Instance.ChangeScene(launchingScene);
		Destroy(this);
	}
}

public static class LaunchFromScene
{
	private static bool setScene = false;

	private static GameScene launchFromScene;
	public static GameScene Scene
	{
		get
		{
			return launchFromScene;
		}
		set
		{
			setScene = true;
			launchFromScene = value;
		}
	}

	public static bool IsSceneSet() { return setScene; }
}

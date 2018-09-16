using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class DebugRoomLauncher : MonoBehaviour {

	// Use this for initialization
	void OnEnable ()
	{
		if (SceneManager.sceneCount >= 2) return;

		GameScene currentGameScene = null;
		string currentSceneName = SceneManager.GetActiveScene().name;
		foreach(var sceneGuid in AssetDatabase.FindAssets("t:GameScene"))
		{
			string scenePath = AssetDatabase.GUIDToAssetPath(sceneGuid);
			var sceneDef = AssetDatabase.LoadAssetAtPath<GameScene>(scenePath);
			if (sceneDef.SceneName.CompareTo(currentSceneName) == 0)
			{
				currentGameScene = sceneDef;
				break;
			}
		}

		if (currentGameScene != null)
		{
			LaunchFromScene.Scene = currentGameScene;

			var guid = AssetDatabase.FindAssets("PersistedScene t:GameScene")[0];
			string path = AssetDatabase.GUIDToAssetPath(guid);
			var persistedScene = AssetDatabase.LoadAssetAtPath<GameScene>(path);
			SceneManager.LoadScene(persistedScene.SceneName);
		}
		else
		{
			Debug.LogError("Create a GameScene for this scene in order to launch automatically through persisted scene.");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

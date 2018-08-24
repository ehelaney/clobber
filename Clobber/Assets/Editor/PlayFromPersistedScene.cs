using System.Collections;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class EditorLoadScript
{
	[MenuItem("Edit/Play from Persisted Scene")]
	public static void PlayFromPrelaunchScene()
	{
		if (EditorApplication.isPlaying == true)
		{
			EditorApplication.isPlaying = false;
			return;
		}

		EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
		EditorSceneManager.OpenScene("Assets/Engine/Persisted/PersistedScene.unity");
		EditorApplication.isPlaying = true;
	}
}
using System.Collections;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class EditorLoadScript
{
	[MenuItem("Edit/Play from Title Scene")]
	public static void PlayFromPrelaunchScene()
	{
		if (EditorApplication.isPlaying == true)
		{
			EditorApplication.isPlaying = false;
			return;
		}

		EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
		EditorSceneManager.OpenScene("Assets/Screens/Title/Title.unity");
		EditorApplication.isPlaying = true;
	}
}
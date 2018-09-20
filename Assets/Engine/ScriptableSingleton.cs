using UnityEngine;
using System.Linq;

public class ScriptableSingleton<T> : ScriptableObject where T : ScriptableObject
{
	protected static T instance;

	static bool haveLoadedPreloads = false;

	//Returns the instance of this singleton.
	public static T Instance
	{
		get
		{
			//this logic taken from this forum post:
			//https://forum.unity.com/threads/load-scriptableobject-as-singleton-from-resources-folder-tuto-questions.491234/

			if (!instance)
			{
				T[] objs = null;

				#if UNITY_EDITOR

				if (!haveLoadedPreloads)
				{
					Resources.LoadAll("Singletons");
					haveLoadedPreloads = true;
				}

				// If we're running the game in the editor, the "Preloaded Assets" array will be ignored.
				// So get all the assets of type T using AssetDatabase.
				string[] objsGUID = UnityEditor.AssetDatabase.FindAssets("t:" + typeof(T).Name);
				int count = objsGUID.Length;
				objs = new T[count];
				for (int i = 0; i < count; i++)
				{
					objs[i] = UnityEditor.AssetDatabase.LoadAssetAtPath<T>(UnityEditor.AssetDatabase.GUIDToAssetPath(objsGUID[i]));
				}
				#else
                // Get all asset of type T from Resources or loaded assets.
                objs = Resources.FindObjectsOfTypeAll<T>();
				#endif

				// If no asset of type T was found...
				if (objs.Length == 0)
				{
					Debug.LogError("No asset of type \"" + typeof(T).Name + "\" has been found in loaded resources. Please create a new one and add it to the \"Preloaded Assets\" array in Edit > Project Settings > Player > Other Settings.");
				}

				// If more than one asset of type T was found...
				else if (objs.Length > 1)
				{
					Debug.LogError("There's more than one asset of type \"" + typeof(T).Name + "\" loaded in this project. We expect it to have a Singleton behaviour. Please remove other assets of that type from this project.");
				}

				instance = (objs.Length > 0) ? objs[0] : null;
			}

			return instance;
		}
	}

	public static bool InstanceExists()
	{
		return (instance != null);
	}
}

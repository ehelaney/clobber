using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Events;

public class GameSceneController : Singleton<GameSceneController> 
{
	public GameScene CurrentScene;

	private bool transitioningScenes = false;

	public void ChangeScene(GameScene newScene)
	{
		if (CurrentScene == newScene)
		{
			Debug.LogError("This scene is already loaded: " + newScene.name);
			return;
		}
		
		if (CurrentScene != null)
		{
			SceneManager.UnloadSceneAsync(CurrentScene.SceneName);

			if (sceneUnloadingEvents.ContainsKey(CurrentScene))
			{
				sceneUnloadingEvents[CurrentScene].Invoke();
			}
			allSceneUnloadingEvent.Invoke();
		}

		SceneManager.LoadScene(newScene.SceneName, LoadSceneMode.Additive);
		CurrentScene = newScene;
		transitioningScenes = true;
	}

	//this is required because LoadScene triggers the scene to be loaded in the next cycle
	//so you can't call LoadScene and immediately call SetActiveScene
	void Update()
	{
		if (transitioningScenes)
		{
			Scene s = SceneManager.GetSceneByName(CurrentScene.SceneName);
			if (s.isLoaded)
			{
				SceneManager.SetActiveScene(s);
				transitioningScenes = false;

				if (sceneLoadingEvents.ContainsKey(CurrentScene))
				{
					sceneLoadingEvents[CurrentScene].Invoke();
				}
				allSceneLoadingEvent.Invoke();
			}
		}
	}

	private Dictionary<GameScene, UnityEvent> sceneLoadingEvents = new Dictionary<GameScene, UnityEvent>();
	private Dictionary<GameScene, UnityEvent> sceneUnloadingEvents = new Dictionary<GameScene, UnityEvent>();
	private UnityEvent allSceneLoadingEvent = new UnityEvent();
	private UnityEvent allSceneUnloadingEvent = new UnityEvent();

	public void AddSceneLoadingListener(GameScene state, UnityAction action)
	{
		if (!sceneLoadingEvents.ContainsKey(state))
		{
			sceneLoadingEvents.Add(state, new UnityEvent());
		}

		sceneLoadingEvents[state].AddListener(action);
	}

	public void RemoveSceneLoadingListener(GameScene state, UnityAction action)
	{
		if (sceneLoadingEvents.ContainsKey(state))
		{
			sceneLoadingEvents[state].RemoveListener(action);
		}
	}

	public void AddSceneUnloadingListener(GameScene state, UnityAction action)
	{
		if (!sceneUnloadingEvents.ContainsKey(state))
		{
			sceneUnloadingEvents.Add(state, new UnityEvent());
		}

		sceneUnloadingEvents[state].AddListener(action);
	}

	public void RemoveSceneUnloadingListener(GameScene state, UnityAction action)
	{
		if (sceneUnloadingEvents.ContainsKey(state))
		{
			sceneUnloadingEvents[state].RemoveListener(action);
		}
	}

	public void AddAllSceneLoadingListener(UnityAction action)
	{
		allSceneLoadingEvent.AddListener(action);
	}

	public void RemoveAllSceneLoadingListener(UnityAction action)
	{
		allSceneLoadingEvent.RemoveListener(action);
	}

	public void AddAllSceneUnloadingListener(UnityAction action)
	{
		allSceneUnloadingEvent.AddListener(action);
	}

	public void RemoveAllSceneUnloadingListener(UnityAction action)
	{
		allSceneUnloadingEvent.RemoveListener(action);
	}

}
using System;

[AttributeUsage(AttributeTargets.Field)]
public class StateSceneAttribute : Attribute
{
	public string SceneName { get; private set; }

	public StateSceneAttribute(string sceneName)
	{
		SceneName = sceneName;
	}
}
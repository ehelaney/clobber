using UnityEngine;

[System.Serializable]
public class SoundDefinition 
{
	public string name;
	public AudioClip clip;

	[Range(0f, 1f)] //clamp the volume in the inspector
	public float volume = 0.6f;
	[Range(0.5f, 2.5f)] //clamp the pitch in the inspector
	public float pitch = 1f;

	[Range(0.1f, 1f)]
	public float volumeModifier = 0.3f;
	[Range(0.1f, 1f)]
	public float pitchModifier = 0.5f;
}
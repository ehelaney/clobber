using UnityEngine;

[CreateAssetMenu(fileName = "NewSoundDefinition", menuName = "Sound Definition", order = 52)]
public class SoundDefinition : ScriptableObject
{
	[SerializeField]
	private string helpfulName;
	public string HelpfulName
	{
		get
		{
			return helpfulName;
		}
	}

	[SerializeField]
	private AudioClip clip;
	public AudioClip Clip
	{
		get
		{
			return clip;
		}
	}

	[SerializeField]
	[Range(0f, 1f)] //clamp the volume in the inspector
	private float volume = 0.6f;
	public float Volume
	{
		get
		{
			return volume;
		}
	}

	[SerializeField]
	[Range(0.5f, 2.5f)] //clamp the pitch in the inspector
	private float pitch = 1f;
	public float Pitch
	{
		get
		{
			return pitch;
		}
	}

	[SerializeField]
	[Range(0.1f, 1f)]
	private float volumeModifier = 0.3f;
	public float VolumeModifier
	{
		get
		{
			return volumeModifier;
		}
	}

	[SerializeField]
	[Range(0.1f, 1f)]
	private float pitchModifier = 0.5f;
	public float PitchModifier
	{
		get
		{
			return pitchModifier;
		}
	}
}
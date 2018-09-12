using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffect : MonoBehaviour
{
	private float timeLeftAlive = 1.0f;

	// Use this for initialization
	public void PlaySoundDefinition(SoundDefinition sound)
	{
		Debug.Log("Playing Sound: " + sound.HelpfulName);
		var soundeffectSource = GetComponent<AudioSource>();

		soundeffectSource.clip = sound.Clip;

		float globalVolumeSettingsPlaceholder = 1.0f; //TODO: once we have a settings dialog I think we'll want to replace this with the global volume setting - NOTE: may want to handle this via events instead

		//NOTE - feel free to find a better algorithm to vary volume and pitch. 
		soundeffectSource.volume = sound.Volume * (globalVolumeSettingsPlaceholder + Random.Range(1.0f - sound.VolumeModifier, 0.5f + sound.VolumeModifier));
		soundeffectSource.pitch = sound.Pitch * (globalVolumeSettingsPlaceholder + Random.Range(1.0f - sound.PitchModifier, 1.0f + sound.PitchModifier));

		timeLeftAlive = sound.Clip.length;
		soundeffectSource.Play();
	}

	// Update is called once per frame
	void Update ()
	{
		timeLeftAlive -= Time.deltaTime;
		
		if (timeLeftAlive < 0.0f)
		{
			gameObject.SetActive(false);
		}
	}
}

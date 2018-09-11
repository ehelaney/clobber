using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffect : MonoBehaviour
{
	private float timeLeftAlive = 0.0f;

	// Use this for initialization
	public void PlaySoundDefinition(SoundDefinition sound)
	{
		var soundeffectSource = GetComponent<AudioSource>();

		soundeffectSource.clip = sound.clip;

		float globalVolumeSettingsPlaceholder = 1.0f; //TODO: once we have a settings dialog I think we'll want to replace this with the global volume setting - NOTE: may want to handle this via events instead

		//NOTE - feel free to find a better algorithm to vary volume and pitch. 
		soundeffectSource.volume = sound.volume * (globalVolumeSettingsPlaceholder + Random.Range(1.0f - sound.volumeModifier, 0.5f + sound.volumeModifier));
		soundeffectSource.pitch = sound.pitch * (globalVolumeSettingsPlaceholder + Random.Range(1.0f - sound.pitchModifier, 1.0f + sound.pitchModifier));

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

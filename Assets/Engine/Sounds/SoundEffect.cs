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
		var soundeffectSource = GetComponent<AudioSource>();

		soundeffectSource.clip = sound.Clip;

		float magicNumber = 1.0f;

		//NOTE - feel free to find a better algorithm to vary volume and pitch. 
		soundeffectSource.volume = sound.Volume * (magicNumber + Random.Range(1.0f - sound.VolumeModifier, 0.5f + sound.VolumeModifier));
		soundeffectSource.pitch = sound.Pitch * (magicNumber + Random.Range(1.0f - sound.PitchModifier, 1.0f + sound.PitchModifier));

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

using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public AudioSource soundeffectSource;          //audio source which will play sound effects.
	public AudioSource musicSource;                 //audio source which will play music.
	public static SoundManager instance = null;     //Allows other scripts to call functions from SoundManager.             


	void Awake()
	{
		//Check if there is already an instance of SoundManager
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this) //if somehow an instance already exists destroy yourself, there should only be one instance of SoundManager
		{
			Debug.LogError("More than one SoundManager was found.");
			Destroy(gameObject);
		}
	}


	//Used to play sound clips with various settings
	public void PlaySound(SoundDefinition sound)
	{
		soundeffectSource.clip = sound.clip;

		float globalVolumeSettingsPlaceholder = 1.0f; //TODO: once we have a settings dialog I think we'll want to replace this with the global volume setting - NOTE: may want to handle this via events instead
		
		//NOTE - feel free to find a better algorithm to vary volume and pitch. 
		soundeffectSource.volume = sound.volume * (globalVolumeSettingsPlaceholder + Random.Range(1.0f - sound.volumeModifier, 0.5f + sound.volumeModifier));
		soundeffectSource.pitch = sound.pitch * (globalVolumeSettingsPlaceholder + Random.Range(1.0f - sound.pitchModifier, 1.0f + sound.pitchModifier));

		soundeffectSource.Play();
	}

	//both load the clip and start playing it
	public void PlayMusic(AudioClip music)
	{
		musicSource.clip = music;
		musicSource.Play();
	}

	/*
	//Not sure if we will need to separate out selecting the music and starting the music.  If we do have those public methods we should probably also call them internally in case we add addtional logic to those methods.
	public void PlayMusic(AudioClip music)
	{
		SelectMusic(music);
		StartMusic();
	}
	*/

	//didnt bother adding variance to pitch or volume for music
	public void SelectMusic(AudioClip music)
	{
		musicSource.clip = music;
	}

	public void StartMusic()
	{
		musicSource.Play();
	}

	public void StopMusic()
	{
		musicSource.Stop();
	}



}
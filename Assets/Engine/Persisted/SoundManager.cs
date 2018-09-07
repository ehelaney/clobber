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
			Destroy(gameObject);
		}

		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when changing scenes
		DontDestroyOnLoad(gameObject);
	}


	//Used to play sound clips.
	public void PlayClip(AudioClip clip)
	{
		soundeffectSource.clip = clip;
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
using System.Collections;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
	public AudioSource musicSource;                 //audio source which will play music.

	#region Sound Effects Container

	public GameObject soundContainerPrefab;

	private SoundContainer _currentSoundEffectsContainer;

	public void ClearCurrentSoundEffectsContainer()
	{
		_currentSoundEffectsContainer = null;
	}

	public void SetCurrentSoundEffectsContainer()
	{
		_currentSoundEffectsContainer = Instantiate(soundContainerPrefab).GetComponent<SoundContainer>();
	}

	#endregion Sound Effects Container

	//Used to play sound clips with various settings
	public void PlaySound(SoundDefinition sound, Vector2 pos)
	{
		if (_currentSoundEffectsContainer == null)
		{
			SetCurrentSoundEffectsContainer();
		}

		_currentSoundEffectsContainer.PlaySoundEffect(sound, pos);
	}

	//Note - currently we're not using any of the additional properties of the sound definition to change the sound of music files.  
	//So far there is no reason to but we can easily modify this method to use pitch, volume, etc. 
	public void PlayMusic(SoundDefinition song)
	{
		musicSource.clip = song.Clip;
		musicSource.Play();
	}
		
	//******* leave the methods below for now but most likely we can remove all of them. 

	/*
	/// <summary>
	/// Plays a song in the songs array if it exists, otherwise does nothing.
	/// </summary>
	/// <param name="name"></param>
	public void PlaySongByName(string name)
	{
		foreach (SoundDefinition sounddef in songs)
		{
			if (name.Equals(sounddef.name))
			{
				musicSource.clip = sounddef.Clip;
				musicSource.Play();
			}
			else
			{
				Debug.Log("Song " + name + " not found in SoundManager songs list.");
			}
		}
	}
	*/

	/*
	//Not sure if we will need to separate out selecting the music and starting the music.  If we do have those public methods we should probably also call them internally in case we add addtional logic to those methods.
	public void PlayMusic(AudioClip music)
	{
		SelectMusic(music);
		StartMusic();
	}
	*/

	//both load the clip and start playing it
	public void PlayClip(AudioClip music)
	{
		musicSource.clip = music;
		musicSource.Play();
	}

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
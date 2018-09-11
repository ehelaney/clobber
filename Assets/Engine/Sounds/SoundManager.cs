using System.Collections;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
	public AudioSource soundeffectSource;          //audio source which will play sound effects.
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
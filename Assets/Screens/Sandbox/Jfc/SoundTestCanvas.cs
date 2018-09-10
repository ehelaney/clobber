using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTestCanvas : MonoBehaviour
{
	public SoundDefinition TestSound;
	public AudioClip MusicClip;

	public void OnPlaySound()
	{
		SoundManager.instance.PlaySound(TestSound);
	}

	public void OnPlayMusic()
	{
		SoundManager.instance.PlayMusic(MusicClip);
	}

	public void OnStopMusic()
	{
		SoundManager.instance.StopMusic();
	}

}
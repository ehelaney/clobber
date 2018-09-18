using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTestCanvas : MonoBehaviour
{
	public SoundDefinition TestSound;
	public AudioClip MusicClip;

	public void OnPlaySound()
	{
		SoundManager.Instance.PlaySound(TestSound, new Vector2(Random.Range(-5, 5), Random.Range(-5, 5)));
	}

	public void OnPlayMusic()
	{
		SoundManager.Instance.PlayClip(MusicClip);
	}

	public void OnStopMusic()
	{
		SoundManager.Instance.StopMusic();
	}

}
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTestCanvas : MonoBehaviour
{
	public AudioClip TestClip;
	public AudioClip MusicClip;

	public void OnPlaySound()
	{
		SoundManager.instance.PlayClip(TestClip);
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
	public AudioMixer masterAudioMixer;
	public AudioMixerGroup musicAudioMixer;
	public AudioMixerGroup soundAudioMixer;

	private void Start()
	{
		//load volumes from player prefs
		LoadFromPlayerPrefs();
		gameObject.SetActive(false);
	}

	private void LoadFromPlayerPrefs()
	{
		//check to see these keys exist as the first time the game is launched we want to use default values instead.
		//Note setting the sliders will automatically call their corresponding setters below because of how the slider events are hooked up.
		if (PlayerPrefs.HasKey("MasterVolume"))
		{
			Slider slider = GameObject.Find("MasterVolume").GetComponent<Slider>();
			slider.value = PlayerPrefs.GetFloat("MasterVolume");
		}

		if (PlayerPrefs.HasKey("MusicVolume"))
		{
			Slider slider = GameObject.Find("MusicVolume").GetComponent<Slider>();
			slider.value = PlayerPrefs.GetFloat("MusicVolume");
		}

		if (PlayerPrefs.HasKey("SoundEffectsVolume"))
		{
			Slider slider = GameObject.Find("SoundEffectsVolume").GetComponent<Slider>();
			slider.value = PlayerPrefs.GetFloat("SoundEffectsVolume");
		}
	}

	public void SetMasterVolume(float volume)
	{
		masterAudioMixer.SetFloat("MasterVolume", volume);
		PlayerPrefs.SetFloat("MasterVolume", volume);
	}

	public void SetMusicVolume(float volume)
	{
		masterAudioMixer.SetFloat("MusicVolume", volume);
		PlayerPrefs.SetFloat("MusicVolume", volume);
	}

	public void SetSoundEffectsVolume(float volume)
	{
		masterAudioMixer.SetFloat("SoundEffectsVolume", volume);
		PlayerPrefs.SetFloat("SoundEffectsVolume", volume);
	}

	//Call this when Back is presed
	public void SaveOptions()
	{
		PlayerPrefs.Save();
	}
}

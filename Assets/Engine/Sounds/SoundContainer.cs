using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundContainer : MonoBehaviour
{
	public ObjectPool soundEffectPool;

	// Use this for initialization
	void OnEnable ()
	{
		soundEffectPool.Initialize();
	}

	void OnDestroy()
	{
		if (SoundManager.InstanceExists())
		{
			SoundManager.Instance.ClearCurrentSoundEffectsContainer();
		}
	}

	public void PlaySoundEffect(SoundDefinition sound, Vector2 pos)
	{
		var newSoundEffect = soundEffectPool.InitNewObject();
		newSoundEffect.transform.position = pos;
		newSoundEffect.GetComponent<SoundEffect>().PlaySoundDefinition(sound);
	}
}

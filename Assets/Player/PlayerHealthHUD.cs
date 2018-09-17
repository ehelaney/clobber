using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthHUD : MonoBehaviour
{
	public Sprite fullHeart;
	public Sprite emptyHeart;

	public Image[] heartImages;

	private int maxHealth;

	// Use this for initialization
	void Start ()
	{
		if (PlayerInfo.Instance == null)
		{
			Debug.LogError("Unable to find player info for the Player Health HUD!!!");
		}

		maxHealth = PlayerInfo.Instance.maxHealth;

		for (int i = maxHealth; i < heartImages.Length; i++)
		{
			heartImages[i].gameObject.SetActive(false);
		}

		PlayerInfo.Instance.OnHealthChanged += OnPlayerHealthChanged;

		//do this so there aren't timing issues between the player and HUD instantiating
		DisplayHealth(PlayerInfo.Instance.Health);
	}
	
	void OnPlayerHealthChanged(int newHealth)
	{
		DisplayHealth(newHealth);
	}

	void DisplayHealth(int health)
	{
		for (int i = 0; i < maxHealth; i++)
		{
			heartImages[i].sprite = (health > i ? fullHeart : emptyHeart);
		}
	}
}

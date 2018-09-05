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
		var thePlayer = FindObjectOfType<Player>();

		if (thePlayer == null)
		{
			Debug.LogError("Unable to find player for the Player Health HUD!!!");
		}

		maxHealth = thePlayer.maxHealth;

		for (int i = maxHealth; i < heartImages.Length; i++)
		{
			heartImages[i].gameObject.SetActive(false);
		}

		thePlayer.OnHealthChanged += OnPlayerHealthChanged;

		//do this so there aren't timing issues between the player and HUD instantiating
		DisplayHealth(thePlayer.Health);
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

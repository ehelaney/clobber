using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomDisplayUI: MonoBehaviour
{
	public Slider playerHealth;
	public Image projectileImage;
	public Image meleeImage;
	private int maxHealth;

	// Use this for initialization
	void Start () 
	{
		try
		{
			GetComponent<UnityEngine.UI.Text>().text = "Room: " + RoomSelector.Instance.CurrentRoom.SceneName;
		}
		catch(System.IndexOutOfRangeException)
		{
			GetComponent<UnityEngine.UI.Text>().text = "Room: Unknown";
		}

		InitPlayerHealth();
	}

	private void InitPlayerHealth()
	{
		if (PlayerInfo.Instance == null)
		{
			Debug.LogError("Unable to find player info for the Player Health HUD!!!");
		}

		maxHealth = PlayerInfo.Instance.maxHealth;
		playerHealth.maxValue = (float)maxHealth;
		playerHealth.value = (float)PlayerInfo.Instance.Health; //current health
		PlayerInfo.Instance.OnHealthChanged += OnPlayerHealthChanged;
	}

	void OnPlayerHealthChanged(int newHealth)
	{
		playerHealth.value = (float)newHealth;
	}

	public void OnPlayerProjectileWeaponChanged(UnityEngine.Object weapon)
	{
		ProjectileWeaponDefinition weaponDef = (ProjectileWeaponDefinition)weapon;
		projectileImage.sprite = weaponDef.ProjectileType.sprite;
	}

}

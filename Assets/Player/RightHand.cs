using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHand : MonoBehaviour 
{
	public GameObject weapon;
	private Animator animator;
	private Vector3 localPos;

	private IWeapon weaponInterface 
	{
		get
		{
			// Find a weapon script on the held object
			// TODO: only refresh this value on weapon change
			MonoBehaviour[] components = weapon.GetComponents<MonoBehaviour>();
			foreach (var component in components)
			{
				if (component is IWeapon)
				{
					return ((IWeapon)component);
				}
			}

			return null;
		}
		set { }
	}
	// Use this for initialization
	void Start () 
	{
		localPos = transform.localPosition;
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Stick to player
		transform.position = transform.parent.position;
		transform.localPosition = localPos;

		// Attack on mouse click
		if(Input.GetMouseButtonDown(0))
		{
			Swing();
		}
	}

	private void Swing()
	{
		animator.SetTrigger("Swing");
		weaponInterface.WeaponActive = true;
	}

	// Called by animation event
	private void DeactivateWeapon()
	{
		weaponInterface.WeaponActive = false;
	}
}

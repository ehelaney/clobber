using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryWeapon : MonoBehaviour 
{
	public GameObject weapon;
	private IWeapon _weaponInterface;

	private Animator animator;

	// Use this for initialization
	void Start () 
	{
		animator = this.GetComponent<Animator>();

		// Find a weapon script on the held object
		MonoBehaviour[] components = weapon.GetComponents<MonoBehaviour>();
		foreach (var component in components)
		{
			if (component is IWeapon)
			{
				_weaponInterface = ((IWeapon)component);
			}
		}
	}
	
	public void Attack()
	{
		animator.SetTrigger("Swing");
		_weaponInterface.WeaponActive = true;
	}

	// Called by animation event
	private void DeactivateWeapon()
	{
		_weaponInterface.WeaponActive = false;
	}
}

using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class MeleeWeapon : MonoBehaviour
{
	private bool weaponActive = false;

	private MeleeWeaponDefinition weaponDefinition;
	private Animator animator;

	// Use this for initialization
	void Start()
	{
		animator = GetComponent<Animator>();
	}

	public void SetWeaponDefinition(MeleeWeaponDefinition weaponDef)
	{
		weaponDefinition = weaponDef;
		GetComponent<SpriteRenderer>().sprite = weaponDef.sprite;
	}

	public void Attack()
	{
		animator.SetTrigger("Swing");
		weaponActive = true;
	}

	// Called by animation event
	private void DeactivateWeapon()
	{
		weaponActive = false;
	}

	/// <summary>
	/// Sent when another object enters a trigger collider attached to this
	/// object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		if (weaponActive && other.gameObject.CompareTag("Enemy"))
		{
			other.gameObject.GetComponent<Enemy>().Hit(weaponDefinition.Damage, (transform.position + other.transform.position) / 2f);
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour 
{
	public GameObject weapon;
	private Animator animator;
	private Vector3 localPos;
	// Use this for initialization
	void Start () 
	{
		localPos = transform.localPosition;
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = transform.parent.position;
		transform.localPosition = localPos;

		if(Input.GetMouseButtonDown(0))
		{
			Swing();
		}
	}

	private void Swing()
	{
		animator.SetTrigger("Swing");
	}
}

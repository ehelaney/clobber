using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Jet : MonoBehaviour
{
	public Sprite lowSprite;
	public Sprite highSprite;

	private SpriteRenderer spriteRenderer;

	private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void SetPower(float power)
	{
		if (power < .25f)
		{
			spriteRenderer.sprite = null;
		}
		else if (power < .75f)
		{
			spriteRenderer.sprite = lowSprite;
		}
		else //power > .75f
		{
			spriteRenderer.sprite = highSprite;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyHit : MonoBehaviour
{
	const float lifetime = 0.5f;

	float lifeTimer = 0.0f;
	private SpriteRenderer spriteRenderer;

	public void Init(Vector2 position)
	{
		transform.position = position;
		spriteRenderer = GetComponent<SpriteRenderer>();
		lifeTimer = 0.0f;
	}

	// Update is called once per frame
	void Update()
	{
		lifeTimer += Time.deltaTime;
		if (lifeTimer > lifetime)
		{
			gameObject.SetActive(false);
		}

		//lerp the alpha of the color, causing it to fade over time
		var color = spriteRenderer.color;
		color.a = Mathf.Lerp(1f, 0f, lifeTimer / lifetime);
		spriteRenderer.color = color;
	}
}

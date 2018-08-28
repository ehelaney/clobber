using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextMesh))]
[RequireComponent(typeof(Rigidbody2D))]
public class PointsNotification : MonoBehaviour
{
	const float lifetime = 1.0f;

	float lifeTimer = 0.0f;
	private TextMesh textMesh;

	public void Init(int points, Vector2 position)
	{
		transform.position = position;
		textMesh = GetComponent<TextMesh>();
		textMesh.text = points.ToString();

		lifeTimer = 0.0f;

		GetComponent<Rigidbody2D>().AddForce(new Vector2(2, 2), ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update ()
	{
		lifeTimer += Time.deltaTime;
		if (lifeTimer > lifetime)
		{
			gameObject.SetActive(false);
		}

		//lerp the alpha of the color, causing it to fade over time
		var textColor = textMesh.color;
		textColor.a = Mathf.Lerp(1f, 0f, lifeTimer / lifetime);
		textMesh.color = textColor;
	}
}

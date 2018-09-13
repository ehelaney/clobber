using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
	LootTypeDefinition lootType;

	float lifeLeft = 0.0f;
	bool isFlashing = false;

	public void Initialize(LootTypeDefinition typeDef, Vector2 pos)
	{
		lootType = typeDef;
		transform.position = new Vector2(pos.x + Random.Range(-1.5f, 1.5f), pos.y + Random.Range(-1.5f, 1.5f));
		isFlashing = false;

		GetComponent<SpriteRenderer>().sprite = lootType.Sprite;
		//GetComponent<Animator>().Play("Idle");

		lifeLeft = lootType.LifeTime;
	}
	// Update is called once per frame
	void Update ()
	{
		lifeLeft -= Time.deltaTime;
		
		if (!isFlashing && lifeLeft < 2.0f)
		{
			GetComponent<Animator>().Play("Blinking");
			isFlashing = true;
		}
		else if (lifeLeft < 0.0f)
		{
			gameObject.SetActive(false);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			EnemyFactory.Instance.LootSystem.OnLootCollected(lootType);
			gameObject.SetActive(false);
		}
	}
}

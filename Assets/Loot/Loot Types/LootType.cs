using System;
using UnityEngine;

public abstract class LootType : ScriptableObject
{
	[SerializeField]
	private string helpfulName;
	public string HelpfulName
	{
		get
		{
			return helpfulName;
		}
	}

	[SerializeField]
	private Sprite sprite;
	public Sprite Sprite
	{
		get
		{
			return sprite;
		}
	}

	[SerializeField]
	private float lifeTime;
	public float LifeTime
	{
		get
		{
			return lifeTime;
		}
	}

	public abstract void OnCollect();
}
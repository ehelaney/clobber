using System;
using UnityEngine;

public abstract class LootType : ScriptableObject
{
	[SerializeField]
	protected string helpfulName;
	public string HelpfulName
	{
		get
		{
			return helpfulName;
		}
	}

	[SerializeField]
	protected Sprite sprite;
	public Sprite Sprite
	{
		get
		{
			return sprite;
		}
	}

	[SerializeField]
	protected float lifeTime;
	public float LifeTime
	{
		get
		{
			return lifeTime;
		}
	}

	public abstract void OnCollect();
}
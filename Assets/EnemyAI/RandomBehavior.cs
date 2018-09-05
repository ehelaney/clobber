using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EnemyAI
{
	public class RandomBehavior : MonoBehaviour
	{
		public List<MonoScript> ScriptsToChooseFrom;
		// Use this for initialization
		void Start () 
		{
			if (ScriptsToChooseFrom.Count > 0)
			{
				int itemIndex = Random.Range (0,ScriptsToChooseFrom.Count);
				gameObject.AddComponent(ScriptsToChooseFrom[itemIndex].GetClass());
			}
		}
		
		// Update is called once per frame
		void Update () 
		{
			
		}
    }
}

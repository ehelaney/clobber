using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyAIType", menuName = "Clobber Misc/Enemy AI Type")]
public class EnemyAIType : ScriptableObject
{
	public TextAsset[] behaviorTree;

	public float moveSpeed = 2.0f;
	//rotation in degrees/second
	public float rotationSpeed = 90.0f;
	//distance the enemy can see
	public float visualAcuity = 3.0f;
}

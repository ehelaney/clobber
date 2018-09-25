using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyAIType", menuName = "Clobber Misc/Enemy AI Type")]
public class EnemyAIType : ScriptableObject
{
	public TextAsset[] behaviorTree;
}

using UnityEngine;
using System.Collections;

public abstract class RoomCondition : ScriptableObject
{
	public abstract bool ConditionMet();
}

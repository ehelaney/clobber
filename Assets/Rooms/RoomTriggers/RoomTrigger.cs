using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class RoomTrigger
{
	public OnConditionSuccess triggerSuccess = OnConditionSuccess.AllConditionsSuccessful;

	public RoomCondition[] roomConditions;
	public RoomAction[] roomActions;
}

public enum OnConditionSuccess
{
	AnyConditionsSuccessful,
	AllConditionsSuccessful
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTriggerEngine : MonoBehaviour
{
	public float conditionCheckInterval = 0.5f;

	private float timeSinceLastConditionCheck = 0.0f;
	private bool complete = false;

	// Update is called once per frame
	void Update ()
	{
		if (complete) return;

		timeSinceLastConditionCheck += Time.deltaTime;

		if (timeSinceLastConditionCheck > conditionCheckInterval)
		{
			CheckConditions();
			timeSinceLastConditionCheck = 0.0f;
		}
	}

	void CheckConditions()
	{
		foreach(var roomTrigger in RoomConfiguration.Instance.roomTriggers)
		{
			bool success = false;

			if (roomTrigger.triggerSuccess == OnConditionSuccess.AnyConditionsSuccessful)
			{
				foreach (var condition in roomTrigger.roomConditions)
				{
					if (condition.ConditionMet())
					{
						success = true;
						break;
					}

				}
			}
			else //if (roomTrigger.triggerSuccess == OnConditionSuccess.AllConditionsSuccessful)
			{
				success = true;
				foreach (var condition in roomTrigger.roomConditions)
				{
					if (!condition.ConditionMet())
					{
						success = false;
						break;
					}

				}
			}

			if (success)
			{
				foreach(var roomAction in roomTrigger.roomActions)
				{
					roomAction.Execute();
				}

				if (!RoomConfiguration.Instance.continueConditionChecksAfterFirstTrigger)
				{
					complete = true;
					return;
				}
			}
		}
	}
}

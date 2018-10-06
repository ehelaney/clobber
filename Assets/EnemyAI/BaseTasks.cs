using UnityEngine;
using Panda;

namespace EnemyAI
{
	public class BaseTasks : ScriptBase
	{
		#region Chase Target

		[Task]
		bool CanSeeThePlayer()
		{
			float distanceToTarget = Vector2.Distance(transform.position, thePlayer.transform.position);
			return (distanceToTarget <= typeDefinition.visualAcuity);
		}

		Transform chaseTarget;
		bool relativeChaseMode;
		Vector2 relativeTarget;

		Vector2 GetChaseTarget()
		{
			if (relativeChaseMode)
			{
				return (Vector2)chaseTarget.position + relativeTarget;
			}
			else
			{
				return chaseTarget.position;
			}
		}

		[Task]
		bool SetChaseTarget_Player()
		{
			chaseTarget = thePlayer.transform;
			relativeChaseMode = false;
			return true;
		}

		[Task]
		bool SetChaseTarget_UnitCircleAroundPlayer()
		{
			Vector2 directionToTarget = thePlayer.transform.position - transform.position;
			var perpendicular = Vector2.Perpendicular(directionToTarget).normalized;

			chaseTarget = thePlayer.transform;
			relativeChaseMode = true;
			relativeTarget = perpendicular * 1.5f;

			return true;
		}

		[Task]
		void ChaseTheTargetUntilCanSee()
		{
			ChaseTheTarget(true);
		}

		[Task]
		void ChaseTheTargetUntilNear()
		{
			ChaseTheTarget(false);
		}

		void ChaseTheTarget(bool untilCanSee)
		{
			Vector2 directionToTarget = GetChaseTarget() - (Vector2)transform.position;

			float spinRate = typeDefinition.rotationSpeed * Time.deltaTime;
			//look at player first
			if (directionToTarget != Vector2.zero)
			{
				RotateToFacePlayer();
			}

			rb2d.velocity = (GetChaseTarget() - (Vector2)transform.position).normalized * typeDefinition.moveSpeed;

			if (untilCanSee)
			{
				if (CanSeeChaseTarget()) Task.current.Succeed();
			}
			else
			{
				if (NearChaseTarget()) Task.current.Succeed();
			}
		}

		[Task]
		bool CanSeeChaseTarget()
		{
			float distanceToTarget = Vector2.Distance(transform.position, GetChaseTarget());
			return (distanceToTarget <= typeDefinition.visualAcuity);
		}

		[Task]
		bool NearChaseTarget()
		{
			return (Vector2.Distance(GetChaseTarget(), transform.position) < 0.1f);
		}

		[Task]
		void RotateAroundChaseTarget()
		{
			//TODO for Basic Fodder
		}

		#endregion Chase Target

		#region Circle Patrol

		[Task]
		public void ExecuteCirclePatrol()
		{
			float spinRate = typeDefinition.rotationSpeed * Time.deltaTime;
			rb2d.MoveRotation(rb2d.rotation + spinRate);
			rb2d.velocity = typeDefinition.moveSpeed * transform.up;
		}


		[Task]
		public void Rotate()
		{
			float spinRate = typeDefinition.rotationSpeed * Time.deltaTime;
			rb2d.MoveRotation(rb2d.rotation + spinRate);
		}

		[Task]
		public bool RotateToFacePlayer()
		{
			Vector3 lookVec = transform.position - thePlayer.transform.position;
			//lookVec.Normalize();
			var newRotation = Quaternion.LookRotation(lookVec, Vector3.forward);
			//newRotation.Normalize();
			newRotation.x = 0.0f;
			newRotation.y = 0.0f;
			transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, typeDefinition.rotationSpeed * Time.deltaTime);

			return (Quaternion.Angle(transform.rotation, newRotation) < 5.0f);
		}

		//runs forever, returns failure when the player falls out of vision
		[Task]
		public void ContinuouslyFacePlayer()
		{
			var newRotation = Quaternion.LookRotation(transform.position - thePlayer.transform.position, Vector3.forward);
			newRotation.x = 0.0f;
			newRotation.y = 0.0f;
			transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, typeDefinition.rotationSpeed * Time.deltaTime);

			if (!CanSeeThePlayer()) Task.current.Fail();
		}

		#endregion Circle Patrol

		#region Move to Destination

		Vector3 moveDestination = Vector3.zero;

		/*
	     * Move to the destination at the current speed and succeeds when the destination has been reached.
	     */
		[Task]
		void MoveToDestination()
		{
			var task = Task.current;
			var delta = moveDestination - transform.position;

			if (transform.position != moveDestination)
			{
				rb2d.velocity = delta.normalized * typeDefinition.moveSpeed;
			}

			if (NearMoveDestination()) Task.current.Succeed();
		}

		[Task]
		bool NearMoveDestination()
		{
			// Succeed when the destination is reached.
			return (Vector3.Distance(moveDestination, transform.position) < 0.1f);
		}

		#endregion Move to Destination

		#region Flee

		[Task]
		bool SetDestination_Safe()
		{
			Vector3 playerDirection = (thePlayer.transform.position - this.transform.position).normalized;
			//probably not really what we want, but it is close enough
			moveDestination = playerDirection * -1f;
			moveDestination.z = 0.0f;
			return true;
		}

		[Task]
		bool SetDestination_Player()
		{
			moveDestination = thePlayer.transform.position;
			moveDestination.z = 0.0f;
			Debug.Log(moveDestination);
			return true;
		}

		[Task]
		bool FullStop()
		{
			moveDestination = Vector3.zero;
			rb2d.velocity = Vector3.zero;
			rb2d.angularVelocity = 0.0f;
			return true;
		}

		[Task]
		bool SetDestination_DirectlyAhead(float ahead)
		{
			moveDestination = (Vector2)transform.position + ((Vector2)transform.right).normalized * ahead;
			return true;
		}

		#endregion Flee

		#region Random Patrol

		public float randomPatrolMinRange = 1.0f;
		public float randomPatrolMaxRange = 4.0f;

		/*
		* Used the a random position as destination and succeeds.
		*/
		[Task]
		bool SetDestination_Random()
		{
			moveDestination = Random.insideUnitSphere * Random.Range(randomPatrolMinRange, randomPatrolMaxRange);
			moveDestination.z = 0.0f;

			return true;
		}

		#endregion Random Patrol
	}
}
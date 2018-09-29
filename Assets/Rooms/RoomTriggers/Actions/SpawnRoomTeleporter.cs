using UnityEngine;
using System.Collections;

public class SpawnRoomTeleporter : RoomAction
{
	public GameEventInt spawnRoomTeleporter;

	public override void Execute()
	{
		if (spawnRoomTeleporter != null) spawnRoomTeleporter.Raise();
	}
}

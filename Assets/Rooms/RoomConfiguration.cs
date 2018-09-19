using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomConfiguration : Singleton<RoomConfiguration>
{
	public MapConfiguration mapConfiguration;
	public SoundDefinition roomSong1; //turn this into an array if we want to randomize songs per room or per playthrough

	// Use this for initialization
	void Start ()
	{
		//probably not the ideal place for this
		SoundManager.Instance.PlayMusic(roomSong1);
	}
}

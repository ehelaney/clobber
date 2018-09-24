using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomConfiguration : Singleton<RoomConfiguration>
{
	public MapConfiguration mapConfiguration;
	public SoundDefinition roomSong1; //turn this into an array if we want to randomize songs per room or per playthrough

	//note: this is an array so we can pepper a map with more than one type of obstacle
	//the engine independently calculates the obstacle odds
	//for simplicity, if multiple obstacles are triggered to be placed in the same tile, it'll pick the first in the array
	public ObstacleConfiguration[] obstacleConfigurations;

	// Use this for initialization
	void Start ()
	{
		//probably not the ideal place for this
		SoundManager.Instance.PlayMusic(roomSong1);
	}
}

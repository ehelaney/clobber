using System;

public enum GameStates
{
	[StateScene("")]
	NullState = 0,

	[StateScene("Title")]
	Title,

	[StateScene("Main")]
	Main,

	[StateScene("Eric")]
	Eric,

	[StateScene("Jfc")]
	Jfc,

	[StateScene("Nate")]
	Nate,

	[StateScene("Phil")]
	Phil,

	[StateScene("Ryan")]
	Ryan,

	[StateScene("GameOver")]
	GameOver,

	[StateScene("Credits")]
	Credits
}

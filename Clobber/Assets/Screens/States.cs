using System;

public enum GameStates
{
	[StateScene("")]
	NullState = 0,

	[StateScene("Title")]
	Title,

	[StateScene("Main")]
	Main,

	[StateScene("Credits")]
	Credits
}

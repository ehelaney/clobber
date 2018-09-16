using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

	public void PlayGame()
	{
		//SceneManager.LoadScene(1); //load the first scene - not 100% sure how we're doing this yet.
		Debug.Log("Play Button Pressed!");
	}

	public void QuitGame()
	{
		Debug.Log("Quit Button Pressed!");
		Application.Quit();
	}

}

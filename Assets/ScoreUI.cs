using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
	const string ScoreConstant = "Score: ";
	public void NewPlayerScore(int newScore)
	{
		GetComponent<UnityEngine.UI.Text>().text = ScoreConstant + newScore.ToString();
	}
}

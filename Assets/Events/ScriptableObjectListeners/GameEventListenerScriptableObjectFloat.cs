using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Game Event Listener", menuName = "Events/Float Listener")]
public class GameEventListenerScriptableObjectFloat : GameEventListenerScriptableObject<float>
{
	[SerializeField]
	public GameEventFloat gameEvent;

	public UnityEventFloat floatEventResponse;

	private void OnEnable()
	{
		response = floatEventResponse;
		gameEvent.RegisterListener(this);
	}

	private void OnDisable()
	{
		gameEvent.UnregisterListener(this);
	}
}

using UnityEngine;
using UnityEngine.Events;

// taken from: https://www.raywenderlich.com/6183-scriptable-objects-tutorial-getting-started

public class GameEventListener<T> : MonoBehaviour
{
	[SerializeField]
	public UnityEvent<T> response;

	public void OnEventRaised(T val)
	{
		response.Invoke(val);
	}
}
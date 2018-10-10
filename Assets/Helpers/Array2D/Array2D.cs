using UnityEngine;

public class Array2D<T> : ScriptableObject where T : UnityEngine.Object
{
	public Vector2Int size;

	public T[] values;

	public void GenerateTable()
	{
		if (size.x > 0 && size.y > 0)
		{
			values = new T[size.x * size.y];
		}
	}

	public T GetValue(int x, int y)
	{
		return values[x * size.x + y];
	}
}
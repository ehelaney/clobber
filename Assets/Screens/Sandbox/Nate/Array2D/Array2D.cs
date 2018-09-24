using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/*
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

public class Array2DEditor<T> : Editor where T : UnityEngine.Object
{
	bool showData = true;

	public override void OnInspectorGUI()
	{
		Array2D<T> theArray = (Array2D<T>)target;

		theArray.size = EditorGUILayout.Vector2IntField("Array Dimensions", theArray.size);
		if (GUILayout.Button("Generate Array"))
		{
			//serializedObject.ApplyModifiedProperties();
			theArray.GenerateTable();
			Repaint();
		}

		//var values = serializedObject.FindProperty("values");

		showData = EditorGUILayout.Foldout(showData, "Array Data");
		if (showData && theArray.values != null)
		{
			for (int i = 0; i < theArray.values.Length; i++)
			{
				if (i % theArray.size.x == 0) EditorGUILayout.BeginHorizontal();

				//EditorGUILayout.PropertyField(values.GetArrayElementAtIndex(i));

				theArray.values[i] = EditorGUILayout.ObjectField(theArray.values[i] as UnityEngine.Object, typeof(T), false) as T;

				if (i % theArray.size.x == theArray.size.x - 1) EditorGUILayout.EndHorizontal();
			}
		}


	}
}*/
/*
public class Array2D<T> : ScriptableObject where T : UnityEngine.Object
{
	public Vector2Int size;

	public Array2DRow<T>[] rows;

	public void GenerateTable()
	{
		if (size.x > 0 && size.y > 0)
		{
			rows = new Array2DRow<T>[size.x];
			for (int i = 0; i < size.x; i++)
			{
				rows[i] = new Array2DRow<T>(size.y);
			}
		}
	}
}

[Serializable]
public class Array2DRow<T> : UnityEngine.Object
{
	public T[] row;

	public Array2DRow(int size)
	{
		if (size > 0) row = new T[size];
	}
}

public class Array2DEditor<T> : Editor where T : UnityEngine.Object
{
	bool showData = true;

	public override void OnInspectorGUI()
	{
		Array2D<T> theArray = (Array2D<T>)target;

		theArray.size = EditorGUILayout.Vector2IntField("Array Dimensions", theArray.size);
		if (GUILayout.Button("Generate Array"))
		{
			serializedObject.ApplyModifiedProperties();
			theArray.GenerateTable();
			Repaint();
		}

		serializedObject.Update();

		showData = EditorGUILayout.Foldout(showData, "Array Data");
		if (showData && theArray.rows != null)
		{			
			for (int i = 0; i < theArray.rows.Length; i++)
			{
				EditorGUILayout.BeginHorizontal();

				var rowData = theArray.rows[i].row;

				for (int j = 0; j < rowData.Length; j++)
				{
					if (typeof(T).IsSubclassOf(typeof(UnityEngine.Object)))
					{
						rowData[j] = EditorGUILayout.ObjectField(rowData[j] as UnityEngine.Object, typeof(T), false) as T;
					}
				}

				EditorGUILayout.EndHorizontal();
			}
		}
		serializedObject.ApplyModifiedProperties();
	}
}*/

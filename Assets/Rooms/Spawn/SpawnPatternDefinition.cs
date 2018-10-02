﻿using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// NOTE: this whole class is comically awful coding.  This is because I couldn't find a way to reliably serialize/deserialize objects in variable-length arrays.
/// No doubt there is a way, I just spent too much time not getting it to work
/// </summary>

[CreateAssetMenu(fileName = "NewSpawnPattern", menuName = "Room/Enemy Spawn Pattern")]
public class SpawnPatternDefinition : ScriptableObject
{
	const int SpawnPatternDimensions = 5;

	public SpawnPatternRow[] rows;

	public void OnEnable()
	{
		if (rows == null)
		{
			rows = new SpawnPatternRow[SpawnPatternDimensions];
			for (int i = 0; i < rows.Length; i++)
			{
				rows[i] = new SpawnPatternRow();
			}
		}
	}

	/// <summary>
	/// 
	/// (-2,  2)   (-1,  2)   (0,  2)    (1,  2)    (2,  2)
	/// (-2,  1)   (-1,  1)	  (0,  1)	 (1,  1)	(2,  1)
	/// (-2,  0)   (-1,  0)	  (0,  0)	 (1,  0)	(2,  0)
	/// (-2, -1)   (-1, -1)	  (0, -1)	 (1, -1)	(2, -1)
	/// (-2, -2)   (-1, -2)	  (0, -2)	 (1, -2)	(2, -2)
	/// 
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <returns></returns>
	public bool GetVal(int x, int y)
	{
		bool val = false;

		int index = (y - 2) * -1;
		if (index < 5 && index >= 0)
		{
			var row = rows[index];
			switch(x)
			{
				case -2:
					return row.val0;
				case -1:
					return row.val1;
				case 0:
					return row.val2;
				case 1:
					return row.val3;
				case 2:
					return row.val4;
			}
		}

		return val;
	}

	public IEnumerable<Vector2Int> GetValues()
	{
		for (int i = 0; i < SpawnPatternDimensions; i++)
		{
			var row = rows[i];
			int y = ((i * -1) + 2);
			if (row.val0)
			{
				yield return new Vector2Int(-2, y);
			}
			if (row.val1)
			{
				yield return new Vector2Int(-1, y);
			}
			if (row.val2)
			{
				yield return new Vector2Int(0, y);
			}
			if (row.val3)
			{
				yield return new Vector2Int(1, y);
			}
			if (row.val4)
			{
				yield return new Vector2Int(2, y);
			}
		}
	}

	public int MinX()
	{
		return -1 * ((SpawnPatternDimensions - 1) / 2);
	}

	public int MaxX()
	{
		return ((SpawnPatternDimensions - 1) / 2);
	}

	public int MinY()
	{
		return MinX();
	}

	public int MaxY()
	{
		return MaxX();
	}
}

[Serializable]
public class SpawnPatternRow
{
	//LOL this is bad
	public bool val0;
	public bool val1;
	public bool val2;
	public bool val3;
	public bool val4;
}

[CustomEditor(typeof(SpawnPatternDefinition))]
public class SpawnPatternEditor : Editor
{
	SpawnPatternDefinition spawnPattern;

	void OnEnable()
	{
		spawnPattern = (SpawnPatternDefinition)target;
	}

	public override void OnInspectorGUI()
	{
		if (spawnPattern.rows == null) spawnPattern.OnEnable();

		serializedObject.Update();
		var rows = serializedObject.FindProperty("rows");
		for (int i = 0; i < rows.arraySize; i++)
		{
			EditorGUILayout.PropertyField(rows.GetArrayElementAtIndex(i), GUIContent.none);
		}

		serializedObject.ApplyModifiedProperties();
	}
}

[CustomPropertyDrawer(typeof(SpawnPatternRow))]
public class SpawnPatternRowDrawer : PropertyDrawer
{
	// Draw the property inside the given rect
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		// Using BeginProperty / EndProperty on the parent property means that
		// prefab override logic works on the entire property.
		EditorGUI.BeginProperty(position, label, property);

		// Draw label
		position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

		// Don't make child fields be indented
		var indent = EditorGUI.indentLevel;
		EditorGUI.indentLevel = 0;

		float eachWidth = position.width / 5.0f;

		EditorGUI.PropertyField(new Rect(position.x, position.y, eachWidth, position.height), property.FindPropertyRelative("val0"), GUIContent.none);
		EditorGUI.PropertyField(new Rect(position.x + eachWidth, position.y, eachWidth, position.height), property.FindPropertyRelative("val1"), GUIContent.none);
		EditorGUI.PropertyField(new Rect(position.x + eachWidth * 2.0f, position.y, eachWidth, position.height), property.FindPropertyRelative("val2"), GUIContent.none);
		EditorGUI.PropertyField(new Rect(position.x + eachWidth * 3.0f, position.y, eachWidth, position.height), property.FindPropertyRelative("val3"), GUIContent.none);
		EditorGUI.PropertyField(new Rect(position.x + eachWidth * 4.0f, position.y, eachWidth, position.height), property.FindPropertyRelative("val4"), GUIContent.none);

		// Set indent back to what it was
		EditorGUI.indentLevel = indent;

		EditorGUI.EndProperty();
	}
}
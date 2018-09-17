﻿using System;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "NewLootTable", menuName = "Loot/Loot Table", order = 1)]
public class LootTableDefinition : ScriptableObject
{
	[SerializeField]
	private string helpfulName;
	public string HelpfulName
	{
		get
		{
			return helpfulName;
		}
	}

	[SerializeField]
	private bool multiDrop;
	public bool MultiDrop
	{
		get
		{
			return multiDrop;
		}
	}

	[SerializeField]
	private LootTableEntry[] lootChances;
	public LootTableEntry[] LootChances
	{
		get
		{
			return lootChances;
		}
	}
}

[Serializable]
public class LootTableEntry
{
	public LootType LootType;

	[Range(0f, 100f)]
	public float Chance;
}

//This property drawer logic was pulled from: https://docs.unity3d.com/Manual/editor-PropertyDrawers.html

[CustomPropertyDrawer(typeof(LootTableEntry))]
public class IngredientDrawer : PropertyDrawer
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

		// Calculate rects
		var lootRect = new Rect(position.x, position.y, position.width - 50, position.height);
		var chanceRect = new Rect(position.x + position.width - 50, position.y, 50, position.height);

		// Draw fields - passs GUIContent.none to each so they are drawn without labels
		EditorGUI.PropertyField(lootRect, property.FindPropertyRelative("LootType"), GUIContent.none);
		EditorGUI.PropertyField(chanceRect, property.FindPropertyRelative("Chance"), GUIContent.none);

		// Set indent back to what it was
		EditorGUI.indentLevel = indent;

		EditorGUI.EndProperty();
	}
}
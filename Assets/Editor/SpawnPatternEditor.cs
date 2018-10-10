using UnityEngine;
using UnityEditor;


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

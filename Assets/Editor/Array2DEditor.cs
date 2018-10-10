using UnityEngine;
using UnityEditor;

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
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "Array2DEnemyType")]
public class Array2DEnemyTypeDefinition : Array2D<EnemyTypeDefinition> { }

[CustomEditor(typeof(Array2DEnemyTypeDefinition))]
public class Array2DEditorEnemyTypeDefinition : Array2DEditor<EnemyTypeDefinition> { }

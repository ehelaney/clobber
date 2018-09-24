using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "NewSpawnConfiguration", menuName = "Room/Enemy Spawn Map")]
public class Array2DEnemySpawnDefinition : Array2D<EnemyTypeDefinition> { }

[CustomEditor(typeof(Array2DEnemySpawnDefinition))]
public class Array2DEditorEnemySpawnDefinition : Array2DEditor<EnemyTypeDefinition> { }

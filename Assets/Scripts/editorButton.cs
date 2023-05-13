using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelGenerator))]

public class editorButton : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LevelGenerator generator = (LevelGenerator)target;

        if (GUILayout.Button("create labyrinth"))
        {
            generator.generateLaberints();
        }
    }
}

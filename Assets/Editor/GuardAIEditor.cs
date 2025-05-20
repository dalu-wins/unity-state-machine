using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GuardAI))]
public class GuardAIEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Draw the default inspector
        DrawDefaultInspector();

        // Extra debug display
        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Debug Info", EditorStyles.boldLabel);

        // SAFELY cast and check
        if (target == null)
        {
            EditorGUILayout.LabelField("Current State", "Target is null.");
            return;
        }

        if (!Application.isPlaying)
        {
            EditorGUILayout.LabelField("Current State", "Enter Play Mode to view");
            return;
        }

        // Safely get current state
        GuardAI guard = target as GuardAI;
        try
        {
            AbstractState currentState = guard.GetCurrentState();

            string stateName = currentState == null ? "N/A (state machine not initialized)" : currentState.GetType().Name;
            EditorGUILayout.LabelField("Current State", stateName);
        }
        catch (Exception)
        {
            EditorGUILayout.LabelField("Current State", "Guard not set");
        }
    }
}

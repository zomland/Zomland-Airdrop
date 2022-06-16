#if UNITY_EDITOR
using Base;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

[CustomEditor(typeof(ObjectSpawner))]
public class ObjectSpawnerEditor : Editor
{
    private ObjectSpawner _objectSpawner;

    public override void OnInspectorGUI()
    {
        _objectSpawner = (ObjectSpawner) serializedObject.targetObject;

        serializedObject.Update();

        GUILayout.Label("Basic Setting", EditorStyles.boldLabel);
        _objectSpawner.key = EditorGUILayout.TextField("Key Name In Object Pooler", _objectSpawner.key);
        _objectSpawner.ShowDebugMessages = EditorGUILayout.Toggle("Show Debug Log?", _objectSpawner.ShowDebugMessages);
        _objectSpawner.sceneParent = EditorGUILayout.ObjectField(new GUIContent { text = "Scene Parent" }, _objectSpawner.sceneParent, 
            typeof(Transform), true) as Transform;

        GUILayout.Space(10);
        GUILayout.Label("Spawner setting", EditorStyles.boldLabel);
        _objectSpawner.spawnMode = (SpawnMode)EditorGUILayout.EnumPopup("Spawn Mode", _objectSpawner.spawnMode);
        
        if (_objectSpawner.spawnMode == SpawnMode.Wave)
        {
            ShowWaveSetting();
        }
        else
        {
            ShowTimerSetting();
        }

        ShowAdvanceSetting();

        ShowRotationSetting();

        serializedObject.ApplyModifiedProperties();

        if (GUI.changed && !Application.isPlaying)
        {
            EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
        }
    }

    private void ShowWaveSetting()
    {
        GUILayout.Space(2);
        GUILayout.Label("Wave Setting", EditorStyles.boldLabel);

        _objectSpawner.firstSpawnTime = EditorGUILayout.FloatField("First Spawn Time", _objectSpawner.firstSpawnTime);
        _objectSpawner.timeBetweenWave = EditorGUILayout.FloatField("Time Between Wave", _objectSpawner.timeBetweenWave);
        _objectSpawner.amountOfWave = EditorGUILayout.IntField("Amount", _objectSpawner.amountOfWave, EditorStyles.miniTextField);
    }

    private void ShowTimerSetting()
    {
        GUILayout.Label("Timer Setting", EditorStyles.boldLabel);

        _objectSpawner.firstSpawnTime = EditorGUILayout.FloatField("First Spawn Time", _objectSpawner.firstSpawnTime);

        GUILayout.Space(5);

        SpawnMode mode = _objectSpawner.spawnMode;

        if (mode == SpawnMode.FixedTime || mode == SpawnMode.ManualFixedTime)
        {
            GUILayout.Label("Fixed Time Settings");
            _objectSpawner.fixedDelayBetweenSpawns = EditorGUILayout.FloatField("Seconds Between Spawns", _objectSpawner.fixedDelayBetweenSpawns);
        }
        // else if (_objectSpawner.spawnMode == SpawnMode.RandomTime)
        // {
        //     GUILayout.Label("Random Time Settings");
        //     _objectSpawner.minDelayBetweenSpawns = EditorGUILayout.FloatField("Min Time Between Spawns", _objectSpawner.minDelayBetweenSpawns);
        //     _objectSpawner.maxDelayBetweenSpawns = EditorGUILayout.FloatField("Max Time Between Spawns", _objectSpawner.maxDelayBetweenSpawns);
        // }
        // else if (_objectSpawner.spawnMode == SpawnMode.ProgressiveTime)
        // {
        //     GUILayout.Label("Progressive Time Settings");
        //     _objectSpawner.startingDelayBetweenSpawns = EditorGUILayout.FloatField("Starting Delay Between Spawns", _objectSpawner.startingDelayBetweenSpawns);
        //     _objectSpawner.delayModifier = EditorGUILayout.FloatField("Delay Modifier", _objectSpawner.delayModifier);
        //     _objectSpawner.progressiveDelayLimit = EditorGUILayout.FloatField("Delay Limit", _objectSpawner.progressiveDelayLimit);
        //
        //     if (_objectSpawner.progressiveDelayLimit <= 0) _objectSpawner.progressiveDelayLimit = 0;
        // }

        // Line Divider		
        GUILayout.Box("", new GUILayoutOption[] { GUILayout.ExpandWidth(true), GUILayout.Height(1) });
    }

    private void ShowAdvanceSetting()
    {
        GUILayout.Space(5);
        GUILayout.Label("Advance Spawner Setting", EditorStyles.boldLabel);

        _objectSpawner.spawnAt = (SpawnAt)EditorGUILayout.EnumPopup("Spawn At", _objectSpawner.spawnAt);
        _objectSpawner.isShowGizmos = EditorGUILayout.Toggle("Show Gizmos?", _objectSpawner.isShowGizmos);
        GUILayout.Space(5);
        if (_objectSpawner.spawnAt == SpawnAt.Grid || _objectSpawner.spawnAt == SpawnAt.RandomGrid)
        {
            GUILayout.Label("Grid Setting", EditorStyles.boldLabel);
            _objectSpawner.gridWidth = EditorGUILayout.IntField("Grid Width", _objectSpawner.gridWidth, EditorStyles.miniTextField);
            _objectSpawner.gridHeight = EditorGUILayout.IntField("Grid Height", _objectSpawner.gridHeight, EditorStyles.miniTextField);
            _objectSpawner.gridRoot = (Transform)EditorGUILayout.ObjectField("Grid Origin Transform", _objectSpawner.gridRoot, typeof(Transform), true);
            _objectSpawner.cellSize = EditorGUILayout.FloatField("Grid Padding", _objectSpawner.cellSize, EditorStyles.miniTextField);
            _objectSpawner.amountPreSpawn = EditorGUILayout.IntField("Pre-spawn Amount", _objectSpawner.amountPreSpawn, EditorStyles.miniTextField);
        }
        else if (_objectSpawner.spawnAt == SpawnAt.RandomTransform)
        {
            GUILayout.Label("Random Transform Setting", EditorStyles.boldLabel);
            SerializedProperty targetList = serializedObject.FindProperty("targetList");
            EditorGUILayout.PropertyField(targetList, new GUIContent { text = "Target List" });
        }
    }

    private void ShowRotationSetting()
    {
        GUILayout.Space(5);
        GUILayout.Label("Rotation Setting", EditorStyles.boldLabel);

        _objectSpawner.spawnRotation = (SpawnRotation)EditorGUILayout.EnumPopup("Spawn Rotation", _objectSpawner.spawnRotation, EditorStyles.popup);

        if (_objectSpawner.spawnRotation == SpawnRotation.Identity)
        {
            EditorGUILayout.HelpBox("The object will spawn with a rotation equals Quaternion.identity", MessageType.Info, true);
        }
        else if (_objectSpawner.spawnRotation == SpawnRotation.ObjectOwnRotation)
        {
            EditorGUILayout.HelpBox("The object will spawn with it's current rotation", MessageType.Info, true);
        }
        else if (_objectSpawner.spawnRotation == SpawnRotation.Spawner)
        {
            EditorGUILayout.HelpBox("The object will spawn with the spawner's rotation ", MessageType.Info, true);
        }
        else if (_objectSpawner.spawnRotation == SpawnRotation.Custom)
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Custom Rotation");

            EditorGUIUtility.labelWidth = 15f;
            _objectSpawner.customRotationX = EditorGUILayout.FloatField("X", _objectSpawner.customRotationX);
            _objectSpawner.customRotationY = EditorGUILayout.FloatField("Y", _objectSpawner.customRotationY);
            _objectSpawner.customRotationZ = EditorGUILayout.FloatField("Z", _objectSpawner.customRotationZ);
            EditorGUIUtility.labelWidth = 0f;

            EditorGUILayout.EndHorizontal();
        }
    }
}
#endif

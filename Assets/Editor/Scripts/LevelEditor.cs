using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LevelEditor : EditorWindow
{
    private int _index;
    private bool _isEnableEdit;
    private Transform _parent;
    private EditorData _data;
    private GameLevel _gameLevel;
    private SceneEditor _sceneEditor;

    [MenuItem("Window/Level Editor")]
    public static void Init() {
        LevelEditor levelEditor = GetWindow<LevelEditor>("Level Editor");
        levelEditor.Show();
    }

    private void OnGUI()
    {
        EditorGUILayout.Space(20);
        _parent = (Transform)EditorGUILayout.ObjectField(_parent, typeof(Transform), true);

        EditorGUILayout.Space(20);

        if (GUILayout.Button("Clear keys"))
        {
            LevelsData levelsData = new LevelsData();
            levelsData.Clear();
            LevelIndex levelIndex = new LevelIndex();
            levelIndex.Clear();
            Debug.LogWarning("Clear Keys"); 
        }
        EditorGUILayout.Space(20);

        if (_data == null) 
        {
            if (GUILayout.Button("Load data"))
            {
              _data = (EditorData)AssetDatabase.LoadAssetAtPath("Assets/Editor/Data/EditorData.asset", typeof(EditorData));
              _sceneEditor = CreateInstance<SceneEditor>();
              _sceneEditor.SetLevelEditor(this, _parent);
            }
        }
        else 
        {
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label("Block Prefab", EditorStyles.boldLabel);
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            EditorGUILayout.Space(5);
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
        
            if (GUILayout.Button("<", GUILayout.Width(50), GUILayout.Height(50)))
            {
                _index--;
                if (_index < 0)
                {
                    _index = _data.BlockDatas.Count - 1;
                }
            }

            if (_data.BlockDatas[_index].BlockData is ColoredBlock)
            {
                ColoredBlock coloredBlock = _data.BlockDatas[_index].BlockData as ColoredBlock;
                GUI.color = coloredBlock.BaseColor;
            }
            else
            {
                GUI.color = Color.white;
            }

            GUILayout.Label(_data.BlockDatas[_index].Texture2D, GUILayout.Width(90), GUILayout.Height(50));
            GUI.color = Color.white;

            if (GUILayout.Button(">", GUILayout.Width(50), GUILayout.Height(50)))
            {
                _index++;
                if (_index > _data.BlockDatas.Count -1)
                {
                    _index = 0;
                }
            }
            
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            GUILayout.Space(30);
            GUI.color = _isEnableEdit ? Color.red : Color.white;

            if (GUILayout.Button("Create Blocks"))
            {
                _isEnableEdit = !_isEnableEdit;
                if (_isEnableEdit)
                {
                    SceneView.duringSceneGui += _sceneEditor.OnSceneGUI;
                }
                else {
                    SceneView.duringSceneGui -= _sceneEditor.OnSceneGUI;
                }
            }

            GUI.color = Color.white;
            GUILayout.Space(30);

            _gameLevel = EditorGUILayout.ObjectField(_gameLevel, typeof(GameLevel), false) as GameLevel;
            GUILayout.Space(30);

            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Save Level"))
            {
                SaveLevel saveLevel = new SaveLevel();
                saveLevel.Save(_gameLevel);
                EditorUtility.SetDirty(_gameLevel);
                Debug.Log("Save");
            }

            if (GUILayout.Button("Load Level"))
            {
                FindObjectOfType<ClearLevel>().Clear();
                BlockGeneration blockGeneration = new BlockGeneration();
                blockGeneration.Generate(_gameLevel, _parent);
            }
            GUILayout.EndHorizontal();
        }
    }
    public BlockData GetBlock() {
        return _data.BlockDatas[_index].BlockData;
        
    }
}

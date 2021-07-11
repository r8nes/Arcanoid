using UnityEngine;
using UnityEngine.Events;

public class LevelGeneration : MonoBehaviour
{
    private readonly LevelIndex _levelIndex = new LevelIndex();
    private readonly BlockGeneration _blocksGenerator = new BlockGeneration();
    [SerializeField] private Transform _parentBlocks;
    [SerializeField] private ClearLevel _clearLevel;
    [SerializeField] private GameState _gameState;
    [SerializeField] private UnityEvent OnGenerated;
    private void Start()
    {
        _gameState.SetState(State.StopGame);
        Init();
    }

    private void Init() 
    {
        _clearLevel.Clear();
        GameLevel gameLevel = Resources.Load<GameLevel>($"Levels/Level{_levelIndex.GetIndex()}");
        if (gameLevel != null)
        {
        _blocksGenerator.Generate(gameLevel, _parentBlocks);
        }
        LoadingScreen.Screen.Enable(false);
        _gameState.SetState(State.Gameplay);
        OnGenerated.Invoke();
    }

    public void Generate() {
        LoadingScreen.Screen.Enable(true);
        Init();
    }

    public void GenerateNext() {
        LevelsData levelsData = new LevelsData();
        int tempIndex = _levelIndex.GetIndex();
        if (tempIndex < levelsData.GetLevelsProgress().Levels.Count - 1)
        {
            _levelIndex.SetIndex(tempIndex + 1);
            Generate();
        }
        else 
        {
            Loader loader = new Loader();
            _gameState.SetState(State.Other);
            loader.LoadingMainScene(true);
        }
    }
}

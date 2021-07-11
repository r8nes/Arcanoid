using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WindowEndGame : MonoBehaviour
{
    [SerializeField] private CalculateLevelProgress _calculateLevelProgress;
    [SerializeField] private Image _starImage;
    [SerializeField] private Sprite[] _starSprites;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _recordText;
    [SerializeField] private TextMeshProUGUI _levelIndex;
    [SerializeField] private Button _buttonNextLevel;

    private void OnEnable()
    {
        EndGameData endGameData = _calculateLevelProgress.GetEndGameData();
        if (endGameData.Life > 0)
        {
            _buttonNextLevel.interactable = true;
        }
        else
        { 
            _buttonNextLevel.interactable = false;
        }
        _levelIndex.text = (endGameData.LevelIndex + 1).ToString();
        _starImage.sprite = _starSprites[endGameData.Life];
        _scoreText.text = endGameData.Score.ToString();
        _recordText.text = endGameData.Record.ToString();
    }

    private void OnDisable()
    {
        
    }
}

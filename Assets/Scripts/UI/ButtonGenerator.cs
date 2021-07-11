using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGenerator : MonoBehaviour
{
    [SerializeField] private Button _buttonPrefab;
    [SerializeField] private GameObject _content;

    private void Start()
    {
        Generate();
    }
    private void Generate() 
    {
        LevelsData levelsData = new LevelsData();
        LevelsProgress levelsProgress = levelsData.GetLevelsProgress();

        for (int i = 0; i < levelsProgress.Levels.Count; i++)
        {
            Button button = Instantiate(_buttonPrefab, _content.transform);
            if (button.gameObject.TryGetComponent(out LevelButton buttonLevel))
            {
                buttonLevel.SetData(levelsProgress.Levels[i], i);
            }
        }
        LoadingScreen.Screen.Enable(false);
    }
}

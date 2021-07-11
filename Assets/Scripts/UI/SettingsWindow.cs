using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsWindow : MonoBehaviour
{
    [SerializeField] private AudioButton _sound;
    [SerializeField] private AudioButton _music;

    private void OnEnable() {
        _music.SetState(AudioController.Audio.GetMusicValue()); 
        _sound.SetState(AudioController.Audio.GetSoundValue());
    }

    public void ChangeSound() {
        AudioController.Audio.ChangeSound();
    }
    public void ChangeMusic()
    {
        AudioController.Audio.ChangeMusic();
    }
    public void ClearProgress() {
        LevelIndex levelIndex = new LevelIndex();
        levelIndex.Clear();
        LevelsData levelData = new LevelsData();
        levelData.Clear();
        Loader loader = new Loader();
        loader.LoadingMainScene(true);
    }
} 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [Space]
    [SerializeField] private AudioClip _awake;
    [SerializeField] private AudioClip _collision;

    public void PlaySoundAwake() {
        if (AudioController.Audio.GetMusicValue())
        {
            _audioSource.PlayOneShot(_awake);
        }
    }

    public void PlaySoundCollision() {
        if (AudioController.Audio.GetSoundValue())
        {
            _audioSource.PlayOneShot(_collision);
        }
    }
}

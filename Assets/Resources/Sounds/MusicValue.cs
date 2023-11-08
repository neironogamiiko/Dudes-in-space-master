using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicValue : MonoBehaviour
{
    private AudioSource _audioSrc;

    private float _musicVolume = .055f;

    void Start()
    {
        _audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        _audioSrc.volume = _musicVolume;
    }

    public void SetVolume(float vol)
    {
        _musicVolume = vol;
    }
}

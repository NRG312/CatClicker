using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVolumeSystem : AudioManager
{
    private float _soundVolume;
    private float _musicVolume;

    private Sound[] soundclips;

    public ChangeVolumeSystem(Sound[] source)
    {
        soundclips = source;
    }
    public override void ChangeVolumeSound(float volume)
    {
        _soundVolume = volume;
        PlayerPrefs.SetFloat("SoundVolume",_soundVolume);
        foreach (Sound s in soundclips)
        {
            s.source.volume = volume;
        }
    }
    
    public override void ChangeVolumeMusic(float volume)
    {
        _musicVolume = volume;
        PlayerPrefs.SetFloat("MusicVolume",_musicVolume);
        foreach (Sound s in soundclips)
        {
            s.source.volume = volume;
        }
    }
}

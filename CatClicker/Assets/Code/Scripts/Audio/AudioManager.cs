using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField]private Slider soundSlider;
    [SerializeField]private Slider musicSlider;

    [Header("Sounds")] [SerializeField]protected Sound[] soundClips;
    [Header("Music")] [SerializeField]protected Sound[] MusicClips;

    
    //cos z punktami za klikanie jest zbagowane zobacz
    //jak jest settings odpalone to moge wszystko klikac napraw to i skonczone
    void Start()
    {
        EventManager.onSoundPlay.AddListener(PlaySound);
        
        foreach (Sound s in soundClips)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.volume = PlayerPrefs.GetFloat("SoundVolume");
            s.source.clip = s.clip;
        }

        foreach (Sound s in MusicClips)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.volume = PlayerPrefs.GetFloat("MusicVolume");
            s.source.clip = s.clip;
        }
        
        //On start play random music
        PlayMusic();
        //refresh UI
        RefreshUI();
    }

    private void RefreshUI()
    {
        soundSlider.value = PlayerPrefs.GetFloat("SoundVolume");
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    }

    public virtual void ChangeVolumeSound(float volume)
    {
        ChangeVolumeSystem Volume = new ChangeVolumeSystem(soundClips);
        Volume.ChangeVolumeSound(volume);
    }

    public virtual void ChangeVolumeMusic(float volume)
    {
        ChangeVolumeSystem Volume = new ChangeVolumeSystem(MusicClips);
        Volume.ChangeVolumeMusic(volume);
    }
    public void PlaySound(string name)
    {
        Sound s = Array.Find(soundClips,sound => sound.nameClip == name);
        s.source.Play();
    }

    private void PlayMusic()
    {
        int random = Random.Range(0, MusicClips.Length);
        Sound music = MusicClips[random];
        music.source.Play();
    }
}

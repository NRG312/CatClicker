using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Sound
{
    public AudioClip clip;
    public string nameClip;

    [HideInInspector] public AudioSource source;
}

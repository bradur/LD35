// Date   : 17.04.2016 01:49
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{

    public static SoundManager main;

    [SerializeField]
    private List<string> soundNames = new List<string>();

    [SerializeField]
    private List<AudioSource> soundSources = new List<AudioSource>();

    void Awake()
    {
        main = this;
    }

    public void Play(string soundName)
    {
        if (soundNames.Contains(soundName))
        {
            soundSources[soundNames.IndexOf(soundName)].Play();
        }
    }

}

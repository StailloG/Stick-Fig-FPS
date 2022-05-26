using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlOneAudio : MonoBehaviour
{
    public AudioSource lvlOneAudio;
    public MusicVolume musicVolScript;

    // Start is called before the first frame update
    void Start()
    {
        lvlOneAudio.volume = musicVolScript.audioSource.volume;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVolume : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip firstLvlAudio;
    /*
    public AudioClip secondLvlAudio;
    public AudioClip thirdLvlAudio;
    public AudioClip fourthLvlAudio;
    public AudioClip fifthLvlAudio;
    */
    private float musicVolume;

    // Start is called before the first frame update
    void Start()
    {

        audioSource.Play(); //play audio source
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = musicVolume;

    }

    public void UpdateVolume(float volume)
    {
        musicVolume = volume;
    }
}

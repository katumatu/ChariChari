using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct AudioDataSet
{
    public AudioSource audio;
    public AudioClip[] audioClips;
}

public class AudioManager : MonoBehaviour
{
    public AudioDataSet audioData = new AudioDataSet();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        audioData.audio.volume = 0.10f;
        audioData.audio.PlayOneShot(audioData.audioClips[0]);

    }
}

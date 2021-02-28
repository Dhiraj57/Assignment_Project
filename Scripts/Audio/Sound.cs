using UnityEngine;
using UnityEngine.Audio;

// To find the source of given name 
[System.Serializable]
public class Sound 
{
    public string name;

    //Reference to the clip to be played
    public AudioClip clip;

    // To change various parameters of audio clip
    [Range(0f, 3f)]
    public float volume;

    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;

}

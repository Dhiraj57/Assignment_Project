using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public static Settings instance;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void Back()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene("Start");
        gameObject.SetActive(false) ;
    }

    // To apply change in volume made in settings menu
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }
}

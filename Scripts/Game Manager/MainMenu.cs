using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // To load different scenes using various UI buttons

    public void OnStart()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Settings()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene("Settings");
    }

    public void Exit()
    {
        Application.Quit(); // To quit the application
        FindObjectOfType<AudioManager>().Play("Click");
    }

    public void Credits()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene("Credits");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{

    public void Quit()
    {
        Application.Quit();
        FindObjectOfType<AudioManager>().Play("Click");
    }

    public void Home()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene("Start");
    }
}

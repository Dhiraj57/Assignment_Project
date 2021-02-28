using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float restartDelay = 5; // Timer to add delay for restart of level 
    public GameObject completeLevelUI;
    public int coins = 0; // Number of coins collected
    public Text coin; // Text UI to display coin count

    // To restart the level after player death
    public void EndGame()
    {
        Invoke("Restart", restartDelay);
    }

    // To restart level using restart UI inside the level
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // To activate level complete UI 
    public void LevelWon()
    {
        FindObjectOfType<AudioManager>().Play("Win");
        completeLevelUI.SetActive(true);
    }

    // To load previous scene using back UI inside the level
    public void Back()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    // To increase the coin count after collection
    public void CoinCount()
    {
        coins++;
        coin.text = coins.ToString(); // To display coin count
    }
}

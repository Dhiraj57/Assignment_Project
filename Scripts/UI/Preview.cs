using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preview : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Next", 11);
    }

    void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}

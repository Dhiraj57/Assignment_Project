using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager manager;

    // To load next level after completion of level
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            manager.LevelWon();
            GameObject.FindWithTag("Player").GetComponent<Player_Movement>().enabled = false;
            GameObject.FindWithTag("Player").GetComponent<Animator>().SetTrigger("Won");
        }
    }
}

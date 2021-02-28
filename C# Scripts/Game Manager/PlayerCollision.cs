using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameManager manager;

    private void OnTriggerEnter(Collider other)
    {
        // To end the level after death and play death animation

        if(other.tag == "Obstacle")
        {
            FindObjectOfType<AudioManager>().Play("PlayerDeath");    

            GameObject.FindWithTag("Player").GetComponent<Player_Movement>().enabled = false;
            GameObject.FindWithTag("Player").GetComponent<Animator>().SetTrigger("Death");
            manager.EndGame();
        }

        else if (other.tag == "Obstacle2")
        {
            FindObjectOfType<AudioManager>().Play("PlayerDeath");

            GameObject.FindWithTag("Player").GetComponent<Player_Movement>().enabled = false;
            GameObject.FindWithTag("Player").GetComponent<Animator>().SetTrigger("Death2");
            manager.EndGame();
        }

    }
}

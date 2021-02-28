using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Controller : MonoBehaviour
{

    public Animator anim;
    private GameObject player;
    private float timer = 2.7f;
    private bool gameStart = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if(player)
        {
            player.GetComponent<Player_Movement>().enabled = false;
            anim.SetFloat("Walk", 1);
        }

    }

    // Update is called once per frame
    void Update()
    {
        // To add delay to start of movement
        if(timer > 0)
        {
            timer -= 1f * Time.deltaTime;
        }

        else
        {
            if(gameStart)
            {
                GameStart();
            }
        }
    }

    private void GameStart()
    {
        gameStart = false;

        if(player)
        {
            player.GetComponent<Player_Movement>().enabled = true;

            if(anim)
            {
                anim.SetFloat("Walk", 1) ;
                anim.SetBool("bRun", true);
            }
        }
    }
}

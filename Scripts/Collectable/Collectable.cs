using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    // To increase coin count
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("CoinCollection");
            Destroy(gameObject);
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().CoinCount() ;
        }
    }
}

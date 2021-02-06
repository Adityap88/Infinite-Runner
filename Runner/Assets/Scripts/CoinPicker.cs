using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPicker : MonoBehaviour
{
    private AudioSource coinPicked;
    private float coinPoints = 15f;
    public ScoreManager manager;
    // Start is called before the first frame update
    void Start()
    {
        coinPicked = GameObject.Find("CoinPickSound").GetComponent<AudioSource>();
        manager = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player_0")
        {

            
            gameObject.SetActive(false);
            manager.score += coinPoints;
            if (coinPicked.isPlaying)
            {
                coinPicked.Stop();
            }
            coinPicked.Play();

        }
        
    }
}

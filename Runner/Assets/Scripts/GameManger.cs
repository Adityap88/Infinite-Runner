using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    public Player player;
  
    public ScoreManager scoreManager;

    public AudioSource deathsound;
    public AudioSource backGroundAudio;

    public Vector3 playerStart;
    public Vector3 groundGenStart;

    public GroundGenerator groundGen;

    public GameObject largeGround;
    public GameObject mediumGround;

    public GameObject gameOverScreen;
    private float highScore = 0f;
    public Text HighScore;


    void Start()
    {
        playerStart = player.transform.position;
        groundGenStart = groundGen.transform.position;
        gameOverScreen.SetActive(false);

        
    }

   public void GameOver()
    {
        player.gameObject.SetActive(false);

        deathsound.Play();
        backGroundAudio.Stop();
        gameOverScreen.SetActive(true);
        scoreManager.isScoreInc = false;
       
    }

    public void Quit()
    {
        Application.Quit();

    }
    public void Restart()

    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetFloat("HighScore");
            HighScore.text = math.round(highScore).ToString();
        }
        Destroyer[] destroyer = FindObjectsOfType<Destroyer>();
        for( int i = 0; i < destroyer.Length; i++)
        {
            destroyer[i].gameObject.SetActive(false);
        }

        mediumGround.SetActive(true);
        largeGround.SetActive(true);
        player.transform.position = playerStart;
       
        groundGen.transform.position = groundGenStart;
        gameOverScreen.SetActive(false);
        player.gameObject.SetActive(true);
        backGroundAudio.Play();
        deathsound.Stop();
        scoreManager.score = 0;
        scoreManager.isScoreInc = true;
     
    }
}

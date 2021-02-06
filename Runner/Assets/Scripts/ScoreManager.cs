using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text Score;
    public Text HighScore;

    public bool isScoreInc;

    public float score;
    private float highScore;

    public int pointsPerSecond;
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
           highScore = PlayerPrefs.GetFloat("HighScore");
           

        }
        else
        {
            highScore = 0f;
        }
        isScoreInc = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isScoreInc)
        {
            score += pointsPerSecond * Time.deltaTime;
        
        }
        
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("HighScore", highScore);
        }
        Score.text = math.round(score).ToString();
        HighScore.text = math.round(highScore).ToString();

    }
}

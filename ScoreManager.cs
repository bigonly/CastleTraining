using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    //public Text earnedScoreText;

    int score = 0;
    int earnedScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        earnedScore = PlayerPrefs.GetInt("",0);
        scoreText.text = "Score: " + score.ToString();
        //earnedScoreText.text = earnedScore.ToString();
    }

    public void AddPoint(int enemyScore)
    {
        score += enemyScore;
        scoreText.text = "Score: " + score.ToString();
        if (earnedScore < score)
            PlayerPrefs.SetInt("",score);
    }
}

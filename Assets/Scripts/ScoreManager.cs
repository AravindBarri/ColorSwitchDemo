using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    Text scoreText;
    public int score = 0;
    public static ScoreManager instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        scoreText = this.GetComponent<Text>();
    }
    public void updateScore()
    {
        score++;
        scoreText.text = "Score : " + score;
        print("Score" + score);
    }

}

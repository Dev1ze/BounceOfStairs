using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text scoreText;
    int score;
    void Start()
    {
        scoreText = GetComponent<Text>();
    }
    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}

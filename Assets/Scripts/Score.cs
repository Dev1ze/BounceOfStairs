using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text scoreText;
    double score;
    void Start()
    {
        scoreText = GetComponent<Text>();
    }
    public void IncrementScore(float transform)
    {

        score = Math.Round(transform / 0.878f);
        scoreText.text = score.ToString();
        
    }
}

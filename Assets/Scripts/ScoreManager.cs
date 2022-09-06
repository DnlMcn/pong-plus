using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    Ball ball;

    void Start()
    {
        ball = FindObjectOfType<Ball>();
        ball.OnScore += HandleScore;
    }

    void Update()
    {
        
    }

    void HandleScore()
    {
        if (ball.lastGoalSide == 1)
        {
            Debug.Log("Point for Player 1");
        }

        if (ball.lastGoalSide == -1)
        {
            Debug.Log("Point for Player 2");
        }
    }
}

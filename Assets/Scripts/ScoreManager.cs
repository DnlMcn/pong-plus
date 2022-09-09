using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Vector2 score;
    [SerializeField] GameObject player1ScoreText;
    [SerializeField] GameObject player2ScoreText;

    string player1ScoreString;
    string player2ScoreString;

    Ball ball;
    
    void Start()
    {
        ball = FindObjectOfType<Ball>();
        ball.OnScore += HandleScore;
    }

    void HandleScore()
    {
        if (ball.lastGoalSide == 1)
        {
            Debug.Log("Point for Player 1");
            score.x += 1;
            Debug.Log("Player 1's score: " + score.x);

            // player1ScoreText.GetComponent<Text>().text = score.x.ToString();
        }

        if (ball.lastGoalSide == -1)
        {
            Debug.Log("Point for Player 2");
            score.y += 1;
            Debug.Log("Player 2's score: " + score.y);

            // player2ScoreText.GetComponent<Text>().text = score.y.ToString();
        }
    }
}

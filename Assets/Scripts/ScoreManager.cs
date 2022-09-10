using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int player1Score;
    public int player2Score;

    [SerializeField] GameObject player1Display;
    [SerializeField] GameObject player2Display;

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
            player1Score += 1;
            Debug.Log("Player 1's score: " + player1Score);

            player1Display.GetComponent<TMPro.TextMeshProUGUI>().text = player1Score.ToString();
        }

        if (ball.lastGoalSide == -1)
        {
            Debug.Log("Point for Player 2");
            player2Score += 1;
            Debug.Log("Player 2's score: " + player2Score);

            player2Display.GetComponent<TMPro.TextMeshProUGUI>().text = player2Score.ToString();
        }
    }
}

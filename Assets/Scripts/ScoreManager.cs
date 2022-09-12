using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreManager : MonoBehaviour
{
    public int player1Score;
    public int player2Score;

    [SerializeField] private int pointsToWin;
    public static bool hasWon;

    [SerializeField] GameObject player1Display;
    [SerializeField] GameObject player2Display;
    [SerializeField] GameObject winDisplay;

    BallManager ballManager;

    void Start()
    {
        ballManager = FindObjectOfType<BallManager>();

        Ball.OnScore += HandleScore;
    }

    void HandleScore()
    {

        if (BallManager.lastGoalSide == 1)
        {
            Debug.Log("Point for Player 1");
            player1Score += 1;
            Debug.Log("Player 1's score: " + player1Score);

            player1Display.GetComponent<TMPro.TextMeshProUGUI>().text = player1Score.ToString();
        }

        if (BallManager.lastGoalSide == -1)
        {
            Debug.Log("Point for Player 2");
            player2Score += 1;
            Debug.Log("Player 2's score: " + player2Score);

            player2Display.GetComponent<TMPro.TextMeshProUGUI>().text = player2Score.ToString();
        }

        // Checks if either player has won. If not, calls StartSpawnNewBall.
        if (player1Score >= pointsToWin) { DeclareWin(1); }
        else if (player2Score >= pointsToWin) { DeclareWin(2); }
        else { ballManager.StartSpawnNewBall(); } 
    }

    void DeclareWin(int player)
    {
        winDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "Jogador " + player + " venceu!";
    }
}

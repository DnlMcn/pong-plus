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
    AudioManager audioManager;

    void Start()
    {
        ballManager = FindObjectOfType<BallManager>();
        audioManager = FindObjectOfType<AudioManager>();

        Ball.OnScore += HandleScore;
    }

    void HandleScore()
    {

        if (BallManager.lastGoalSide == 1)
        {
            player1Score += 1;
            player1Display.GetComponent<TMPro.TextMeshProUGUI>().text = player1Score.ToString();
        }

        if (BallManager.lastGoalSide == -1)
        {
            player2Score += 1;
            player2Display.GetComponent<TMPro.TextMeshProUGUI>().text = player2Score.ToString();
        }

        // Checks if either player has won. If not, calls StartSpawnNewBall.
        if (player1Score >= pointsToWin) DeclareWin(1); 
        else if (player2Score >= pointsToWin) DeclareWin(2); 
        else ballManager.StartSpawnNewBall(); audioManager.Play("Score");
    }

    void DeclareWin(int player)
    {
        winDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "Jogador " + player + " venceu!";
        audioManager.Play("Win");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    Ball ball;
    Text text;
    ScoreManager scoreManager;
    [SerializeField] private int assignedPlayer;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();

        ball = FindObjectOfType<Ball>();
        ball.OnScore += HandleScoreDisplay;
        
        text = gameObject.GetComponent<Text>();
    }

    private void HandleScoreDisplay()
    {
        // Debug.Log("Handling score display.");
        // text.text = scoreManager.score.x.ToString();

    }
}

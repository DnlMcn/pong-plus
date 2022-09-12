using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;

    [SerializeField] float respawnWaitTime;
    private float timer;

    private Vector2 ballVelocity;

    public static int startingSide;
    public static int lastGoalSide;
    public static bool isFirstServe = true;

    Ball ball;


    private void Start() 
    {
        ball = FindObjectOfType<Ball>();
        
        Ball.OnScore += StartRespawnBall;

        StartCoroutine(SpawnNewBall());
    }

    IEnumerator SpawnNewBall()
    {
        yield return new WaitForSeconds(respawnWaitTime);
        Instantiate(ballPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    void StartRespawnBall()
    {
        StartCoroutine(SpawnNewBall());
    }
}

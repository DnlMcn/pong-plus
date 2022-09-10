using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;

    [SerializeField] float respawnWaitTime;
    private float timer;

    private Vector2 ballVelocity;

    private int lastGoalSide;
    private bool isFirstServe = true;


    void Start()
    {
        Instantiate(ballPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    private void CalculateStartingBallVelocity()
    {
        // Randomize the direction of the first serve. Otherwise, serve to whoever got the last point.
        if (isFirstServe) { startingSide = UnityEngine.Random.Range(0, 2) * 2 - 1; }
        else { startingSide = lastGoalSide * -1; }

        ballVelocity.x = startingSide;
        ballVelocity.y = UnityEngine.Random.Range(0, 2) * 2 - 1;
    }

    IEnumerator RespawnBall()
    {
        yield return new WaitForSeconds(respawnWaitTime);
        Instantiate(ballPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    void StartRespawnBall()
    {
        ball.OnScore += StartRespawnBall;
        StartCoroutine(RespawnBall());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    [SerializeField] float respawnWaitTime;
    private float timer;

    private bool isInPlay;

    Ball ball;

    void Start()
    {
        Instantiate(ballPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        ball = FindObjectOfType<Ball>();
        ball.OnScore += StartRespawnBall;
    }

    IEnumerator RespawnBall()
    {
        yield return new WaitForSeconds(respawnWaitTime);
        Instantiate(ballPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    void StartRespawnBall()
    {
        StartCoroutine(RespawnBall());
    }
}

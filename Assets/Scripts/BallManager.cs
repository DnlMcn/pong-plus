using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    [SerializeField] float respawnWaitTime;
    private bool isInPlay;

    void Start()
    {
        Instantiate(ballPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector2 velocity;

    private bool hasInitialized;

    public static event Action OnScore;

    BallManager ballManager;

    void Start() 
    {
        ballManager = FindObjectOfType<BallManager>();

        velocity = CalculateStartingVelocity();
    }

    void Update()
    {
        transform.Translate(velocity * speed * Time.deltaTime); 
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Detect collisions with walls
        if (collider.gameObject.tag == "TopWall") { velocity.y *= -1; }
        if (collider.gameObject.tag == "BottomWall") { velocity.y *= -1; }

        // Detect collisions with players
        if (collider.gameObject.tag == "Player") { velocity.x *= -1; }

        // Detect collisions with goals
        if (collider.gameObject.tag == "GoalRight") 
        { 
            BallManager.lastGoalSide = 1; 
            if (OnScore != null) { OnScore(); } 
            Destroy(gameObject); 
        }

        if (collider.gameObject.tag == "GoalLeft") 
        { 
            BallManager.lastGoalSide = -1; 
            if (OnScore != null) { OnScore(); }
            Destroy(gameObject); 
        }
    }

    private Vector2 CalculateStartingVelocity()
    {
        // Randomize the direction of the first serve. Otherwise, serve to whoever got the last point.
        if (BallManager.isFirstServe) { BallManager.startingSide = UnityEngine.Random.Range(0, 2) * 2 - 1; }
        else { BallManager.startingSide = BallManager.lastGoalSide; }

        velocity.x = BallManager.startingSide;
        velocity.y = UnityEngine.Random.Range(0, 2) * 2 - 1;

        return velocity;
    }
}

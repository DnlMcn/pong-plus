using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool speedsUp;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float speedUpScale;
    [SerializeField] private bool changesSize;
    [SerializeField] private float changeSizeScale;
    private Vector2 velocity;

    private bool hasInitialized;
    
    [SerializeField] private float maxScale;
    [SerializeField] private float minScale;

    public static event Action OnScore;

    BallManager ballManager;
    AudioManager audioManager;


    void Start() 
    {
        ballManager = FindObjectOfType<BallManager>();
        audioManager = FindObjectOfType<AudioManager>();

        velocity = CalculateStartingVelocity();
    }

    void Update()
    {
        transform.Translate(velocity * speed * Time.deltaTime);
        if (changesSize && transform.localScale.x <= maxScale && transform.localScale.x >= minScale) 
            transform.localScale *= ((speedUpScale * Time.deltaTime)/5 + 1);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Detect collisions with walls
        if (collider.gameObject.tag == "TopWall") velocity.y *= -1; audioManager.Play("Bounce");
        if (collider.gameObject.tag == "BottomWall") velocity.y *= -1; audioManager.Play("Bounce");

        // Detect collisions with players
        if (collider.gameObject.tag == "Player") 
        { 
            // If speed-up is active, slightly increase ball speed upon contact with a player
            if (speedsUp || speed < maxSpeed) speed *= speedUpScale;
            VectorBounce(collider);
            audioManager.Play("Bounce");
        }

        // Detect collisions with goals
        if (collider.gameObject.tag == "GoalRight") 
        { 
            BallManager.lastGoalSide = 1; 
            if (OnScore != null) OnScore();  
            Destroy(gameObject); 
        }

        if (collider.gameObject.tag == "GoalLeft") 
        { 
            BallManager.lastGoalSide = -1; 
            if (OnScore != null) OnScore(); 
            Destroy(gameObject); 
        }
    }

    private Vector2 CalculateStartingVelocity()
    {
        // Randomize the direction of the first serve. Otherwise, serve to whoever got the last point.
        if (BallManager.isFirstServe) BallManager.startingSide = UnityEngine.Random.Range(0, 2) * 2 - 1; 
        else BallManager.startingSide = -BallManager.lastGoalSide; 

        velocity.x = BallManager.startingSide;
        velocity.y = UnityEngine.Random.Range(0, 2) * 2 - 1;

        return velocity;
    }

    private void VectorBounce(Collider2D collider)
    {
        float dotOfvn = Vector2.Dot(velocity, (Vector2)collider.transform.right);
        Vector2 r = new Vector2();
        r += -2 * dotOfvn * (Vector2)collider.transform.right + velocity;
        velocity = r;
    }
}

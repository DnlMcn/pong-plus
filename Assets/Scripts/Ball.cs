using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed;
    private int startingSide;
    private Vector2 velocity;
    public int lastGoalSide;
    private bool isFirstServe = true;

    public event Action OnScore;


    void Start()
    {
        CalculateStartingVelocity();     
        velocity = new Vector2(startingSide, velocity.y);
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
            lastGoalSide = 1; 

            if (OnScore == null)
            {
                Debug.Log("Event is null");
            }
            else
            {
                OnScore();
            }

            Destroy(gameObject); 
        }
        
        if (collider.gameObject.tag == "GoalLeft") 
        { 
            lastGoalSide = -1; 

            if (OnScore == null)
            {
                Debug.Log("Event is null");
            }
            else
            {
                OnScore();
            } 

            Destroy(gameObject); 
        }
    }

    private void CalculateStartingVelocity()
    {
        // Randomize the direction of the first serve. Otherwise, serve to whoever got the last point.
        if (isFirstServe)
        {
            startingSide = UnityEngine.Random.Range(-1, 2);
            while (startingSide == 0) {startingSide = UnityEngine.Random.Range(-1, 2);}
        }
        else 
        { 
            startingSide = lastGoalSide * -1; 
        }

        velocity.y = UnityEngine.Random.Range(-1, 2);
        while (velocity.y == 0) {velocity.y = UnityEngine.Random.Range(-1, 2);}
    }
}

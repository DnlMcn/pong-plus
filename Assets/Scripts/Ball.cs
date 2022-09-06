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
        // Detects collisions with walls
        if (collider.gameObject.tag == "TopWall") { Debug.Log("Collision with top wall"); velocity.y *= -1; }
        if (collider.gameObject.tag == "BottomWall") { Debug.Log("Collision with top wall"); velocity.y *= -1; }

        // Detects collisions with players
        if (collider.gameObject.tag == "Player") { Debug.Log("Collision with player"); velocity.x *= -1; }

        // Detects collisions with goals
        if (collider.gameObject.tag == "GoalRight") { lastGoalSide = 1; if (OnScore != null) { OnScore(); Destroy(gameObject); } }
        if (collider.gameObject.tag == "GoalLeft") { lastGoalSide = -1; if (OnScore != null) { OnScore(); Destroy(gameObject); } }
    }

    private void CalculateStartingVelocity()
    {
        startingSide = UnityEngine.Random.Range(-1, 2);
        while (startingSide == 0) {startingSide = UnityEngine.Random.Range(-1, 2);}

        velocity.y = UnityEngine.Random.Range(-1, 2);
        while (velocity.y == 0) {velocity.y = UnityEngine.Random.Range(-1, 2);}
        
        Debug.Log(startingSide == 1 ? "Ball will start to the right" : "Ball will start to the left");  
    }
}

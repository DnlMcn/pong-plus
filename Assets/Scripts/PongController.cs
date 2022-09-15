using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private int player;
    [SerializeField] private bool canRotate;

    private float speedBackup;
    private Vector3 initialPosition;
    private int moveDirection;
    private int wallCollided;


    private void Start() 
    {
        speedBackup = speed;
        initialPosition = transform.position;

        Ball.OnScore += ResetPlayerPositions;
    }

    private void Update() 
    {
        if (player == 1)
        {
            if (Input.GetKey("w")) HandleMovement(1); 
            if (Input.GetKey("s")) HandleMovement(-1); 
        }

        else if (player == 2)
        {
            if (Input.GetKey("up")) HandleMovement(1); 
            if (Input.GetKey("down")) HandleMovement(-1); 
        }

        if (canRotate) HandleRotation();
    }

    private void HandleMovement(int direction)
    {
        // Check if the player is currently touching a wall. If so, and they move in the opposite direction, return their speed.
        if (speed == 0 && direction == -wallCollided) speed = speedBackup;   

    	// Translate player
        transform.Translate(new Vector2(0, direction) * speed * Time.deltaTime);
    }

    private void HandleRotation()
    {
        if (player == 1)
        {
            if (Input.GetKey("a")) transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
            if (Input.GetKey("d")) transform.Rotate(new Vector3(0, 0, -rotationSpeed * Time.deltaTime));
        }

        else if (player == 2)
        {
            if (Input.GetKey("left")) transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
            if (Input.GetKey("right")) transform.Rotate(new Vector3(0, 0, -rotationSpeed * Time.deltaTime));
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)    
    {
        // Set player speed to 0 upon collision with walls.
        if (collider.gameObject.tag == "TopWall")
        {
            speed = 0; 
            wallCollided = 1;
        }    

        else if (collider.gameObject.tag == "BottomWall")
        {
            speed = 0;
            wallCollided = -1;
        } 
    }

    void ResetPlayerPositions()
    {
        Ball.OnScore += ResetPlayerPositions;
        transform.position = initialPosition;
        transform.eulerAngles = Vector3.zero;
    }
}

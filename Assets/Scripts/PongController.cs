using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int player;

    private float speedBackup;
    private int moveDirection;
    private int wallCollided;


    private void Start() 
    {
        speedBackup = speed;
    }

    private void Update() 
    {
        if (player == 1)
        {
            if (Input.GetKey("w")) { HandleMovement(1); }
            if (Input.GetKey("s")) { HandleMovement(-1); }
        }

        else if (player == 2)
        {
            if (Input.GetKey("up")) { HandleMovement(1); }
            if (Input.GetKey("down")) { HandleMovement(-1); }
        }
    }

    private void HandleMovement(int direction)
    {
        if (direction == -wallCollided) { speed = speedBackup; }  
        transform.Translate(new Vector2(0, direction) * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)    
    {
        if (collider.gameObject.tag == "TopWall")
        {
            Debug.Log("Player collision with top wall");
            speed = 0; 
            wallCollided = 1;
        }    

        else if (collider.gameObject.tag == "BottomWall")
        {
            Debug.Log("Player collision with bottom wall");
            speed = 0;
            wallCollided = -1;
        } 
    }

}

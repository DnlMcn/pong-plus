using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private int player;
    private Vector2 movementInput;
    
    private void Update() 
    {
        if (player == 1)
        {
            if (Input.GetKey("w"))
            {
                Debug.Log("W");
                transform.Translate(new Vector2(0, 1) * speed * Time.deltaTime);
            }

            if (Input.GetKey("s"))
            {
                Debug.Log("S");
                transform.Translate(new Vector2(0, -1) * speed * Time.deltaTime);
            }
        }

        else if (player == 2)
        {
            if (Input.GetKey("up"))
            {
                Debug.Log("up");
                transform.Translate(new Vector2(0, 1) * speed * Time.deltaTime);
            }

            if (Input.GetKey("down"))
            {
                Debug.Log("down");
                transform.Translate(new Vector2(0, -1) * speed * Time.deltaTime);
            }
        }
    }

    private void FixedUpdate()
    {
    }

}

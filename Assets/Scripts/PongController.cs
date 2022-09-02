using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private int player;
    
    private void Update() 
    {
        if (player == 1)
        {
            if (Input.GetKey("w")) { transform.Translate(new Vector2(0, 1) * speed * Time.deltaTime); }
            if (Input.GetKey("s")) { transform.Translate(new Vector2(0, -1) * speed * Time.deltaTime); }
        }

        else if (player == 2)
        {
            if (Input.GetKey("up")) { transform.Translate(new Vector2(0, 1) * speed * Time.deltaTime); }
            if (Input.GetKey("down")) { transform.Translate(new Vector2(0, -1) * speed * Time.deltaTime); }
        }
    }

    private void FixedUpdate()
    {
    }

}

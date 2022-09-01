using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    [SerializeField] private float speed;
    private int startingSide;
    private Vector2 velocity;

    void Start()
    {
        CalculateStartingVelocity();     
    }

    
    void Update()
    {
        velocity = new Vector2(startingSide, velocity.y);
        transform.Translate(velocity * speed * Time.deltaTime); 
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Wall") { velocity.y *= -1; }
        if (collider.gameObject.tag == "Player") { velocity.x *= -1; }
    }

    private void CalculateStartingVelocity()
    {
        startingSide = Random.Range(-1, 2);
        while (startingSide == 0) {startingSide = Random.Range(-1, 2);}
        velocity.y = Random.Range(-1, 2);
        Debug.Log(startingSide);  
    }
}

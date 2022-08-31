using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    [SerializeField] private float speed = 12f;
    private int startingSide;
    private Vector2 startingVector;

    void Start()
    {
        startingSide = Random.Range(-1, 2);
        while (startingSide == 0) {startingSide = Random.Range(-1, 2);}
        startingVector.y = Random.Range(-1, 2);
        Debug.Log(startingSide);    
    }

    
    void Update()
    {
        startingVector = new Vector2(startingSide, startingVector.y);
        transform.Translate(startingVector * speed * Time.deltaTime); 
    }

    private void OnCollisionEnter2D(Collision2D collider) 
    {
        
    }
}

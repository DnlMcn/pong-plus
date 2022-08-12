using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PongController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    public InputAction playerControls;

    Vector2 movementInput = new Vector2().zero;
    

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Enable();
    }

    void Update()
    {
        movementInput = playerControls.ReadValue<Vector2>()
    }

    private void FixedUpdate()
    {
        
    }

    private void MoveUp()
    {
        Debug.Log("Move Up");
    }

    private void MoveDown()
    {
        Debug.Log("Move Down");
    }
}

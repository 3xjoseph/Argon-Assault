using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] InputAction movement;

    void Start()
    {
        
    }

    private void OnEnable() 
    {
        movement.Enable();
    }

    private void OnDisable() 
    {
        movement.Disable();
    }

    void Update()
    {
        // float horizontalThrow = Input.GetAxis("Horizontal");
        // float verticalThrow = Input.GetAxis("Vertical");

        float horizontalThrow = movement.ReadValue<Vector2>().x;
        float verticalThrow = movement.ReadValue<Vector2>().y;

        Debug.Log(horizontalThrow);
        Debug.Log(verticalThrow);
    }
}

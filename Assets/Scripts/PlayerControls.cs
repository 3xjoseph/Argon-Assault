using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        float horizontalThrow = Input.GetAxis("Horizontal");
        float verticalThrow = Input.GetAxis("Vertical");

        Debug.Log(horizontalThrow);
        Debug.Log(verticalThrow);
    }
}

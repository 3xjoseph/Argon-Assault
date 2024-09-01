using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    float xOffset;
    float yOffset;
    [SerializeField] float movementSpeed;
    void Update()
    {
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        xOffset = (xThrow * Time.deltaTime) * movementSpeed;
        float newXPos = transform.localPosition.x + xOffset;

        yOffset = (yThrow* Time.deltaTime) * movementSpeed;
        float newYPos = transform.localPosition.y + yOffset;
        transform.localPosition = new Vector3 (newXPos, newYPos, transform.localPosition.z);
        
          
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    float xOffset;
    float yOffset;
    [SerializeField] float movementSpeed;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 5f;

    void Update()
    {
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        xOffset = (xThrow * Time.deltaTime) * movementSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        yOffset = (yThrow* Time.deltaTime) * movementSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3 (clampXPos, clampYPos, transform.localPosition.z);
        
          
    }
}

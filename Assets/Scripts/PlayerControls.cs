using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerControls : MonoBehaviour
{
    float xOffset, yOffset;
    float xThrow, yThrow; 
    [SerializeField] float movementSpeed;
    [SerializeField] float xRange;
    [SerializeField] float yRange;
    [SerializeField] float positionPitchFactor;
    [SerializeField] float controlPitchFactor;
    [SerializeField] float positionYawFactor;
    [SerializeField] float controlRollFactor;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();

    }

    private void ProcessRotation()
    {

        // Pitch Position On Screen
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        // Pitch Control Throw
        float pitchDueToControlthrow = yThrow * controlPitchFactor;

        
        //Pitch
        float pitch = pitchDueToPosition + pitchDueToControlthrow;
        //Yaw
        float yaw = transform.localPosition.x * positionYawFactor;
        //Roll
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        xOffset = (xThrow * Time.deltaTime) * movementSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        yOffset = (yThrow * Time.deltaTime) * movementSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampXPos, clampYPos, transform.localPosition.z);
    }
}

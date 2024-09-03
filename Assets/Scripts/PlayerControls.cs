using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms;

public class PlayerControls : MonoBehaviour
{
    float xOffset, yOffset;
    float xThrow, yThrow; 

    [SerializeField] InputAction movement, fire;

    [SerializeField] float movementSpeed;
    [SerializeField] float xRange, yRange;
    [SerializeField] float positionPitchFactor, controlPitchFactor, positionYawFactor, controlRollFactor;

    [SerializeField] GameObject[] lasers;

    void OnEnable() 
    {
        movement.Enable();
        fire.Enable();
    }

    void OnDisable() 
    {
        movement.Enable();
        fire.Disable();
    }


    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();

    }

    void ProcessTranslation()
    {
        //xThrow = movement.ReadValue<Vector2>().x;
        //yThrow = movement.ReadValue<Vector2>().y;

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

    void ProcessRotation()
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

    void ProcessFiring()
    {
        // Old input system - Input.GetButton("Fire1")
        if (fire.ReadValue<float>() > 0.5)
        {
            ActivateLasers();
        }
        else 
        {
            DeactivateLasers();
        }



    }

    void ActivateLasers()
    {
        foreach (GameObject lasers in lasers)
        {
            lasers.SetActive(true);
        }
    }

    void DeactivateLasers()
    {
        foreach (GameObject lasers in lasers)
        {
            lasers.SetActive(false);
        }
    }
}

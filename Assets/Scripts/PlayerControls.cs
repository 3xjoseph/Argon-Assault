using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms;

public class PlayerControls : MonoBehaviour
{
    //Key Bind Setings
    [Header("Key Bind Settings")]
    [Tooltip("Player Movements and action")]
    [SerializeField] InputAction movement; 
    [SerializeField] InputAction fire;
    
    //General Settings
    [Header("General Settings")]
    [Tooltip("How fast ship moves up and down based upon player input")]
    [SerializeField] float movementSpeed;
    [Tooltip("How far can the player move")] [SerializeField] float xRange, yRange;

    // Screen Position Based Tuning
    [Header("Screen Position Based Tuning")]
    [SerializeField] float positionPitchFactor; 
    [SerializeField] float positionYawFactor;

    //Player Input Based Tuning
    [Header("Player Input Based Tuning")]
    [SerializeField] float controlPitchFactor; 
    [SerializeField] float controlRollFactor;
    
    //Laser Array Settings
    [Header("Laser Array Settings")]
    [Tooltip("Add player laser")] [SerializeField] GameObject[] lasers;

    float xOffset, yOffset;
    float xThrow, yThrow; 

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
            SetLasersActive(true);
        }
        else 
        {
            SetLasersActive(false);
        }
    }

    void SetLasersActive(bool activator)
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission; 
            emissionModule.enabled = activator;
        }
    }

    
}

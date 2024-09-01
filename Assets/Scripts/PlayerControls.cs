using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float xOffset = .1f;
    void Update()
    {
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        float newXPos = transform.localPosition.x + xOffset;

        transform.localPosition = new Vector3 (newXPos, transform.localPosition.y, transform.localPosition.z);
        
          
    }
}

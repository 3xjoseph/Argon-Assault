using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
     [Header("General Settings")]
     [Tooltip("How many seconds of delay before the game reloads")]
     [SerializeField] float loadLevelDelay;
   void OnTriggerEnter(Collider other) 
   {
          StartCrashSequence();
   }

    void StartCrashSequence()
    {
          var playerControls = GetComponent<PlayerControls>();
          playerControls.enabled = false;
          Invoke("ReloadLevel", loadLevelDelay);
    }

    void ReloadLevel() 
    {
          int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
          SceneManager.LoadScene(currentSceneIndex);
    }
}


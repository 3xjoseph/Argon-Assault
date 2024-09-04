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

     [SerializeField] ParticleSystem explosionFX;
   void OnTriggerEnter(Collider other) 
   {
          StartCrashSequence();
   }

    void StartCrashSequence()
    {
          explosionFX.Play();
          var playerControls = GetComponent<PlayerControls>();
          playerControls.enabled = false;
          GetComponent<MeshRenderer>().enabled = false;
          GetComponent<BoxCollider>().enabled = false;
          Invoke("ReloadLevel", loadLevelDelay);
    }

    void ReloadLevel() 
    {
          int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
          SceneManager.LoadScene(currentSceneIndex);
    }
}


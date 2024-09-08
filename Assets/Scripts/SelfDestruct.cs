using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [Header("Time Settings")]
    [Tooltip("How many seconds tp destroy")][SerializeField] float timeToDestroy = 3f; 
    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }
}

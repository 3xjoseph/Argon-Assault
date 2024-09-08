using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.VFX;

public class Enemy : MonoBehaviour
{
    [Header("Particle for Enemies")]
    [Tooltip("Add a death explosion particle VFX")][SerializeField] GameObject deathFX;
    [Tooltip("Add a hit particle VFX")][SerializeField] GameObject hitVFX;
    [SerializeField] int scorePerHit = 5;
    [SerializeField] int hitPoints = 3;

     ScoreBoard scoreBoard;
     GameObject parentGameObject;
     

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidBody();
    }

    void AddRigidBody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }


    void OnParticleCollision(GameObject other)
    {
        if (hitPoints == 0) 
        {
            KillEnemy();
        }
        ProcessHit();
        
    }

    void KillEnemy()
    {
        InstantiateVFX(deathFX);
        scoreBoard.IncreaseScore(scorePerHit);
        Destroy(gameObject);
    }

    void ProcessHit()
    {
        InstantiateVFX(hitVFX);
        hitPoints -= 1;
    }

    void InstantiateVFX(GameObject fxParameter)
    {
        GameObject fx = Instantiate(fxParameter, transform.position, Quaternion.identity);
        fx.transform.parent = parentGameObject.transform;
    }
}

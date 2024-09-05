using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.VFX;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] Transform  parent;
    [SerializeField] int scorePerHit = 5;
    [SerializeField] int hitPoints = 3;

     ScoreBoard scoreBoard;

    void Start() 
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
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
        InstantiateVFX(deathVFX);
        Destroy(gameObject);
    }

    void ProcessHit()
    {
        InstantiateVFX(hitVFX);
        hitPoints -= 1;
        scoreBoard.IncreaseScore(scorePerHit);
    }

    void InstantiateVFX(GameObject vfxParameter)
    {
        GameObject vfx = Instantiate(vfxParameter, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
    }
}

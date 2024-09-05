using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.VFX;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform  parent;

    ScoreBoard scoreBoard;

    [SerializeField] int scorePerHit = 5;

    void Start() 
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessScore();
        KillEnemy();
    }

    void KillEnemy()
    {
        GameObject explosionVFX = Instantiate(deathVFX, transform.position, Quaternion.identity);
        explosionVFX.transform.parent = parent;
        Destroy(gameObject);
    }

    void ProcessScore()
    {
        scoreBoard.IncreaseScore(scorePerHit);
    }
}

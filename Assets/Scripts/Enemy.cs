using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform  parent;
    private void OnParticleCollision(GameObject other) 
    {
        GameObject explosionVFX = Instantiate(deathVFX, transform.position, Quaternion.identity);
        explosionVFX.transform.parent = parent;
        Destroy(gameObject);
    }
}

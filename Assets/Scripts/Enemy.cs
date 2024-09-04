using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnParticleCollision(GameObject other) 
    {
        Debug.Log($"{this.name} Got hit by spaceship {other}");
        Destroy(gameObject);
    }
}

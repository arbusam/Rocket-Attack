using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private void OnParticleCollision(GameObject other)
    {
        print("Destroy");
        Destroy(gameObject);
    }

}

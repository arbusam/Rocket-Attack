using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    private void OnCollisionEnter(Collision other)
    {
        print($" {this.name} collided with {other.gameObject.name}");
    }

    private void OnTriggerEnter(Collider other)
    {
        print($" {other.gameObject.name} triggered {this.name}");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObject : MonoBehaviour
{
    [SerializeField] private Rigidbody2D wallRb;
    [SerializeField] private int flyForce;

    void FixedUpdate()
    {
        wallRb.velocity = new Vector2(-flyForce, wallRb.velocity.y);
    }
}

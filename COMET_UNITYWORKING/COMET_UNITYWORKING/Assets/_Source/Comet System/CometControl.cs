 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometControl : MonoBehaviour
{
    [SerializeField] private Rigidbody2D cometRb;
    [SerializeField] private int flyForce;
    bool isFlying = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFlying = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isFlying = false;
        }
    }

    void FixedUpdate()
    {
        if (isFlying)
        {
            Fly();
        }
    }

    public void Fly()
    {
        cometRb.velocity = new Vector2(cometRb.velocity.x, flyForce);
    }
}

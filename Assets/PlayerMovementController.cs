using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovementController : MonoBehaviour
{
    public float maxSpeed = 15f;

    public float speed = 15f;
    public float stoppingForce = 1.5f;

    private Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(horizontal, 0);

        Vector2 velocity = movement * speed;

        velocity.y = rigidbody2D.velocity.y;
        
        if (velocity.x < -maxSpeed)
        {
            velocity.x = -maxSpeed;
        }
        
        if (velocity.x > maxSpeed)
        {
            velocity.x = maxSpeed;
        }

        if (-0.2 <= horizontal && horizontal <= 0.2)
        {
            velocity.x /= stoppingForce;
        }
        
        rigidbody2D.velocity = velocity;
    }
}
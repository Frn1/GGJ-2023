using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerMovementController : MonoBehaviour
{
    public float maxSpeed = 15f;
    public float speedMul = 1f;

    public float accelTime = 0.01f;

    private Rigidbody2D _rigidbody2D;

    private float _runningTime = 0f;
    
    private Vector2 _moveAmount = new Vector2();

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = _moveAmount.x;
        Vector2 velocity = new Vector2(0f, _rigidbody2D.velocity.y);
  
        // Debug.Log(_runningTime);
        if (0.1 < horizontal || horizontal < -0.1)
        {
            _runningTime = Math.Min(_runningTime + Time.deltaTime, accelTime);
            velocity.x = Math.Clamp((_runningTime / accelTime) * maxSpeed, 0f, maxSpeed * speedMul) * horizontal;
        } else {
			_runningTime = Math.Max(_runningTime - Time.deltaTime, 0);
		}
  
        _rigidbody2D.velocity = velocity;
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        _moveAmount = context.ReadValue<Vector2>();
    }
}
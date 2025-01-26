using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float JumpHeight;
    public float DistanceToMaxHeight;
    public float SpeedHorizontal;
    public float PressTimeToMaxJump;
    public ContactFilter2D filter;

    private Rigidbody2D _rigidbody;
    private CollisionDetection _collisionDetection;
    private float _lastVelocityY;
    private float _jumpStartedTime;
    private int _jumpCount = 0;
    private Animator _animator;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collisionDetection = GetComponent<CollisionDetection>();
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (IsPeakReached()) TweakGravity();


    }

    // NOTE: InputSystem: "JumpStarted" action becomes "OnJumpStarted" method
    public void OnJumpStarted()
    {
        if (_jumpCount < 2)
        {
            SetGravity();
            var vel = new Vector2(_rigidbody.linearVelocity.x, GetJumpForce());
            _rigidbody.linearVelocity = vel;
            _jumpStartedTime = Time.time;
            _animator.SetFloat("Impulse", _rigidbody.linearVelocity.y);
            _jumpCount++;
        }
    }

    // NOTE: InputSystem: "JumpFinished" action becomes "OnJumpFinished" method
    public void OnJumpFinished()
    {
        float fractionOfTimePressed = 1 / Mathf.Clamp01((Time.time - _jumpStartedTime) / PressTimeToMaxJump);
        _rigidbody.gravityScale *= fractionOfTimePressed;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        float h = -GetDistanceToGround() + JumpHeight;
        Vector3 start = transform.position + new Vector3(-1, h, 0);
        Vector3 end = transform.position + new Vector3(1, h, 0);
        Gizmos.DrawLine(start, end);
        Gizmos.color = Color.white;
    }

    private bool IsPeakReached()
    {
        _rigidbody.gravityScale = 3f;
        bool reached = ((_lastVelocityY * _rigidbody.linearVelocity.y) < 0);
        _lastVelocityY = _rigidbody.linearVelocity.y;

        return reached;
    }


    private void SetGravity()
    {
        var grav = 2 * JumpHeight * (SpeedHorizontal * SpeedHorizontal) / (DistanceToMaxHeight * DistanceToMaxHeight);
        _rigidbody.gravityScale = grav / 9.81f;
    }

    private void TweakGravity()
    {
        _rigidbody.gravityScale *= 1.2f;
    }

    private float GetJumpForce()
    {
        return 2 * JumpHeight * SpeedHorizontal / DistanceToMaxHeight;
    }

    private float GetDistanceToGround()
    {
        RaycastHit2D[] hit = new RaycastHit2D[3];

        Physics2D.Raycast(transform.position, Vector2.down, filter, hit, 10);

        return hit[0].distance;
    }

    public void ResetJump()
    {
        _rigidbody.gravityScale = 1f;
        _jumpCount = 0;
        _animator.SetFloat("Impulse", 0);
    }
}
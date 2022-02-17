using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Movement Data")]
public class MovementData : ScriptableObject
{
    [Header("Physics")]
    public float gravityScale;
    public float fallGravityMultiplier;
    public float quickFallGravityMultiplier;

    public float dragAmount;
    public float frictionAmount;

    //grace time to jump after falling off platform
    [Range(0, 0.5f)] public float coyoteTime;

    [Header("Run")]
    public float runMaxSpeed;
    public float runAccel;
    public float runDecel;
    [Range(0, 1)] public float accelAir;
    [Range(0, 1)] public float decelAir;
    [Space(4)]
    [Range(0.5f, 2f)] public float accelPower;
    [Range(0.5f, 2f)] public float stopPower;
    [Range(0.5f, 2f)] public float turnPower;

    [Header("Jump")]
    public float jumpForce;
    [Range(0, 1)] public float jumpCutMultiplier;
    [Space(5)]
    [Range(0, 0.5f)] public float jumpBufferTime;

    [Header("Wall Jump")]
    public Vector2 wallJumpForce;
    [Space(5)]
    [Range(0f, 1f)] public float wallJumpRunLerp;
    [Range(0f, 1.5f)] public float wallJumpTime;

    [Header("Slide")]
    public float slideAccel;
    [Range(0.5f, 2f)] public float slidePower;

    [Header("Other")]
    public bool keepMomentum;
    public bool turnOnWallJump;
}

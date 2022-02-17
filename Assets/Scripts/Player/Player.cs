using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private MovementData data;

    private Rigidbody2D rb;

    private bool _isFacingRight;
    private bool _isJumping;
    private bool _isWallJumping;

    private int _lastWallJumpDir;

    private float _lastOnGroundTime;
    private float _lastOnWallTime;
    private float _lastOnWallRightTime;
    private float _lastOnWallLeftTime;

    private Vector2 _moveInput;
    private float _lastPressedJumpTime;

    [Header("Checks")]
    [SerializeField]
    private Transform _groundCheckPoint;
    [SerializeField]
    private Vector2 _groundCheckSize;
    [Space(5)]
    [SerializeField]
    private Transform _frontWallCheckPoint;
    [SerializeField]
    private Transform _backWallCheckPoint;
    [SerializeField]
    private Vector2 _wallCheckSize;

    [Header("Layers/Tags")]
    [SerializeField]
    private LayerMask _groundLayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetGravityScale(data.gravityScale);
    }

    private void Update()
    {
        _moveInput.x = Input.GetAxisRaw("Horizontal");
        _moveInput.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _lastPressedJumpTime = data.jumpBufferTime;
        }

        _lastOnGroundTime -= Time.deltaTime;
        _lastOnWallTime -= Time.deltaTime;
        _lastOnWallRightTime -= Time.deltaTime;
        _lastOnWallLeftTime -= Time.deltaTime;

        _lastPressedJumpTime -= Time.deltaTime;

        if (_moveInput.x != 0)
            CheckDirectionToFace(_moveInput.x > 0);

        if (Physics2D.OverlapBox(_groundCheckPoint.position, _groundCheckSize, 0, _groundLayer))
            _lastOnGroundTime = data.coyoteTime;

        if ((Physics2D.OverlapBox(_frontWallCheckPoint.position, _wallCheckSize, 0, _groundLayer) && _isFacingRight) || (Physics2D.OverlapBox(_backWallCheckPoint.position, _wallCheckSize, 0, _groundLayer) && !_isFacingRight)) 
        {
            _lastOnWallRightTime = data.coyoteTime;
        }

        if ((Physics2D.OverlapBox(_frontWallCheckPoint.position, _wallCheckSize, 0, _groundLayer) && !_isFacingRight) || (Physics2D.OverlapBox(_backWallCheckPoint.position, _wallCheckSize, 0, _groundLayer) && _isFacingRight))
        {
            _lastOnWallLeftTime = data.coyoteTime;
        }

        _lastOnWallTime = Mathf.Max(_lastOnWallLeftTime, _lastOnWallRightTime);

        if (_isJumping && rb.velocity.y < 0)
            _isJumping = false;

        if (_isWallJumping && rb.velocity.y < 0)
            _isWallJumping = false;

        if (_lastPressedJumpTime > 0)
        {
            if (_lastOnGroundTime > 0)
            {
                _isJumping = true;
                _isWallJumping = false;
                Jump();
            }
            else if (_lastOnWallTime > 0)
            {
                _isJumping = false;
                _isWallJumping = true;
                WallJump((_lastOnWallRightTime > 0) ? -1 : 1);
            }
        }
    }

    private void FixedUpdate()
    {
        if (_isWallJumping)
            Run(0);
        else
            Run(1);
    }

    private void Run(float lerpAmount)
    {
        float speedX = data.runMaxSpeed * _moveInput.x;

        if (lerpAmount < 1)
            lerpAmount *= 0.2f;

        speedX = Mathf.Lerp(rb.velocity.x, speedX, lerpAmount);

        rb.velocity = new Vector2(speedX, rb.velocity.y);
    }

    public void SetGravityScale(float scale)
    {
        rb.gravityScale = scale;
    }

    private void Turn()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        _isFacingRight = !_isFacingRight;
    }

    private void Jump()
    {
        _lastPressedJumpTime = 0;
        _lastOnGroundTime = 0;

        rb.velocity = new Vector2(rb.velocity.x, data.jumpForce);
    }

    private void WallJump(int dir)
    {
        _lastPressedJumpTime = 0;
        _lastOnGroundTime = 0;
        _lastOnWallRightTime = 0;
        _lastOnWallLeftTime = 0;

        Vector2 force = new Vector2(data.wallJumpForce.x, data.wallJumpForce.y);
        force.x *= -dir;
        rb.velocity = force;
    }

    private void JumpCut()
    {
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * data.jumpCutMultiplier);
    }

    private void CheckDirectionToFace(bool isMovingRight)
    {
        if (isMovingRight != _isFacingRight)
            Turn();
    }
}

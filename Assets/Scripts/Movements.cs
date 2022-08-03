using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movements : MonoBehaviour
{
    [SerializeField] private float _accelerate;

    private float _speed;
    private float _targetSpeed;
    private float _directionX;
    public float DirectionsY;
    private Rigidbody2D _rigidbody2D;
    public readonly RaycastHit2D[] Result = new RaycastHit2D[1];

    public bool IsGroun { get { return CheckGround() != 0; } private set { } }
    public float Speed { get { return _speed; } private set { } }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        DirectionsY = _rigidbody2D.velocity.y;
        Move();

        if (_directionX > 0 && transform.localScale.x < 0)
            Flip();

        if (_directionX < 0 && transform.localScale.x > 0)
            Flip();
    }

    public void StartMoveComand(float targetSpeed, float directionsX)
    {
        _targetSpeed = targetSpeed;
        _directionX = directionsX;
    }

    public void EndMoveComand()
    {
        _targetSpeed = 0;
    }

    public void Jump(float powerJump)
    {
        if (CheckGround() != 0)
        {
            _rigidbody2D.AddForce(Vector2.up * powerJump, ForceMode2D.Impulse);
        }
    }

    private void Move()
    {
        _speed = Mathf.Lerp(_speed, _targetSpeed, _accelerate * Time.deltaTime);
        _rigidbody2D.velocity = new Vector2(_speed * _directionX, _rigidbody2D.velocity.y);
    }

    private int CheckGround()
    {
        return _rigidbody2D.Cast(transform.up, Result, -0.2f);
    }

    private void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y);
    }
}

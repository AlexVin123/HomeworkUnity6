using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(DefintionCollision))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _acceleration;

    private float _speed;
    private float _targetSpeed;
    private float _directionMoveX;
    private float _directionsMoveY;
    private Rigidbody2D _rigidbody2D;
    private DefintionCollision _defintionCollision;

    public float DirectionMoveY { get { return _directionsMoveY; } private set { } }

    public float Speed { get { return _speed; } private set { } }

    private void Start()
    {
        _defintionCollision = GetComponent<DefintionCollision>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _directionsMoveY = _rigidbody2D.velocity.y;
        Move();

        if (_directionMoveX > 0 && transform.localScale.x < 0)
            Flip();

        if (_directionMoveX < 0 && transform.localScale.x > 0)
            Flip();
    }

    public void StartMove(float targetSpeed, float directionsX)
    {
        _targetSpeed = targetSpeed;
        _directionMoveX = directionsX;
    }

    public void EndMove()
    {
        _targetSpeed = 0;
    }

    public void Jump(float powerJump)
    {
        if (_defintionCollision.IsGroun)
        {
            _rigidbody2D.AddForce(Vector2.up * powerJump, ForceMode2D.Impulse);
        }
    }

    private void Move()
    {
        _speed = Mathf.Lerp(_speed, _targetSpeed, _acceleration * Time.deltaTime);
        _rigidbody2D.velocity = new Vector2(_speed * _directionMoveX, _rigidbody2D.velocity.y);
    }

    private void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y);
    }
}

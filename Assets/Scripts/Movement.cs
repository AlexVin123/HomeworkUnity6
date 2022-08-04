using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _acceleration;
    [SerializeField] private float _distansCheckObjectsHorizontal;
    [SerializeField] private float _distansCheckObjectsDown;

    private ContactFilter2D _filter;
    private float _speed;
    private float _targetSpeed;
    private float _directionMoveX;
    private float _directionsMoveY;
    private Rigidbody2D _rigidbody2D;
    private RaycastHit2D[] CollisionObject = new RaycastHit2D[1];

    public float DirectionMoveY { get { return _directionsMoveY; } private set { } }
    public bool IsGroun { get { return CheckAvailabilityGround(); } private set { } }
    public float Speed { get { return _speed; } private set { } }

    private void Start()
    {
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

    public Collider2D TransferCollaiderCollision()
    {
        if(CollisionObject[0] == true)
        {
            return CollisionObject[0].collider;
        }
        else
        {
            return null;
        }
    }

    public bool TryCollisionObjectHorizontal(float directionsX)
    {
        var hit = new RaycastHit2D[1];
        var countCollision = _rigidbody2D.Cast(transform.right, hit, _distansCheckObjectsHorizontal * directionsX);
        return countCollision == 0;
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
        if (CheckAvailabilityGround())
        {
            _rigidbody2D.AddForce(Vector2.up * powerJump, ForceMode2D.Impulse);
        }
    }

    private void Move()
    {
        _speed = Mathf.Lerp(_speed, _targetSpeed, _acceleration * Time.deltaTime);
        _rigidbody2D.velocity = new Vector2(_speed * _directionMoveX, _rigidbody2D.velocity.y);
    }

    private bool CheckAvailabilityGround()
    {
        return Physics2D.Raycast(transform.position,-Vector2.up,_filter,CollisionObject,_distansCheckObjectsDown) > 0;
    }

    private void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y);
    }
}

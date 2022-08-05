using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DefintionCollision : MonoBehaviour
{
    [SerializeField] private float _distansCheckObjectsHorizontal;
    [SerializeField] private float _distansCheckObjectsDown;

    private ContactFilter2D _filter;
    private Rigidbody2D _rigidbody2D;
    private RaycastHit2D[] CollisionObject = new RaycastHit2D[1];

    public bool IsGroun { get { return CheckAvailabilityGround(); } private set { } }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public bool TryCollisionObjectHorizontal(float directionsX)
    {
        var hit = new RaycastHit2D[1];
        var countCollision = _rigidbody2D.Cast(transform.right, hit, _distansCheckObjectsHorizontal * directionsX);
        return countCollision == 0;
    }

    public Collider2D TransferCollaiderCollision()
    {
        if (CollisionObject[0] == true)
        {
            return CollisionObject[0].collider;
        }
        else
        {
            return null;
        }
    }

    private bool CheckAvailabilityGround()
    {
        return Physics2D.Raycast(transform.position, -Vector2.up, _filter, CollisionObject, _distansCheckObjectsDown) > 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speedWalk;

    private Movement _movement;
    private float _directionMoveX = 1;

    private void Start()
    {
        _movement = GetComponent<Movement>();
    }

    private void Update()
    {
        if(_movement.TryCollisionObjectHorizontal(_directionMoveX))
        {
            _movement.StartMove(_speedWalk, _directionMoveX);

        }
        else
        {
            _movement.EndMove();
            _directionMoveX *= -1;
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}

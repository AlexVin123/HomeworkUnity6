using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speedWalk;

    private Movements _movements;
    private float DirectionX = 1;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _movements = GetComponent<Movements>();
    }
    private void Update()
    {
        Debug.Log(CheckWay());
        if(CheckWay())
        {
            _movements.StartMoveComand(_speedWalk, DirectionX);
        }
        else
        {
            _movements.EndMoveComand();
            DirectionX *= -1;
        }
    }

    private bool CheckWay()
    {
        var hit = new RaycastHit2D[1];
        var countCollision = _rigidbody2D.Cast(transform.right, hit, 0.2f * DirectionX);

        if(countCollision == 0)
            return true;
        else
            return false;
    }

    public void Died()
    {
        Destroy(gameObject);
    }
}

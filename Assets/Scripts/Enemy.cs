using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movements))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speedWalk;

    private Movements _movements;
    private float _directionMoveX = 1;

    private void Start()
    {
        _movements = GetComponent<Movements>();
    }

    private void Update()
    {
        if(_movements.TryCollisionObjectHorizontal(_directionMoveX))
        {
            _movements.StartMove(_speedWalk, _directionMoveX);

        }
        else
        {
            _movements.EndMove();
            _directionMoveX *= -1;
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}

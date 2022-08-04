using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movements))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speedWalk;
    [SerializeField] private float _speedRun;
    [SerializeField] private float _powerJump;

    private Movements _movements;
    private float _directionMoveX;

    private void Start()
    {
        _movements = GetComponent<Movements>();
    }

    void Update()
    {
        _directionMoveX = Input.GetAxisRaw("Horizontal");

        if (_movements.SetCollider() != null && _movements.SetCollider().TryGetComponent<Enemy>(out Enemy enemy))
        {
            _movements.Jump(_powerJump);
            enemy.Die();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _movements.Jump(_powerJump);
        }

        if(_directionMoveX != 0)
        {
            if(Input.GetKey(KeyCode.LeftShift) && _movements.IsGroun == true)
            {
                _movements.StartMove(_speedRun, _directionMoveX);
                return;
            }
            _movements.StartMove(_speedWalk, _directionMoveX);
        }
        else
        {
            _movements.EndMove();
        }
    }
}

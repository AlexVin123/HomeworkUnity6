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
    private float _directionX;

    private void Awake()
    {
        _movements = GetComponent<Movements>();
    }
    void Update()
    {

        Debug.Log(_movements.Result[0].collider);
        _directionX = Input.GetAxisRaw("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space))
        {
            _movements.Jump(_powerJump);
        }

        if(_directionX != 0)
        {
            if(Input.GetKey(KeyCode.LeftShift) && _movements.IsGroun == true)
            {
                _movements.StartMoveComand(_speedRun, _directionX);
                return;
            }
            _movements.StartMoveComand(_speedWalk, _directionX);
        }
        else
        {
            _movements.EndMoveComand();
        }
    }
}

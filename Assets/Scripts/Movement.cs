using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speedWalk;
    [SerializeField] private float _speedRun;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _acceleraite;

    private float _targetSpeed;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _vectorMove;
    private float _targetSpeedWithDirections;

    private void Start()
    {

        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _vectorMove.x = Input.GetAxisRaw("Horizontal");
        
        if(_vectorMove.x != 0)
        {
            
            if(Input.GetKey(KeyCode.LeftShift))
            {
                _targetSpeed = Mathf.MoveTowards(_targetSpeed,_speedRun, _acceleraite * Time.deltaTime);
                _targetSpeedWithDirections = _targetSpeed * _vectorMove.x;
            }
            else
            {
                if (_targetSpeed > _speedWalk)
                {
                    _targetSpeed = Mathf.MoveTowardsAngle(_targetSpeed, _speedWalk, _acceleraite * Time.deltaTime);
                    _targetSpeedWithDirections = _targetSpeed * _vectorMove.x;
                }
                else
                {
                    _targetSpeed = Mathf.MoveTowards(_targetSpeed, _speedWalk, _acceleraite * Time.deltaTime);
                    _targetSpeedWithDirections = _targetSpeed * _vectorMove.x;
                }
            }
        }
        else
        {
            _targetSpeed = Mathf.MoveTowardsAngle(_targetSpeed, 0, _acceleraite * Time.deltaTime);

            if(_targetSpeedWithDirections < 0)
            {
                _targetSpeedWithDirections = -_targetSpeed;
            }
            else
            {
                _targetSpeedWithDirections = _targetSpeed;
            }
            
        }
        _rigidbody2D.velocity = new Vector2(_targetSpeedWithDirections, _rigidbody2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && _rigidbody2D.velocity.y == 0)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        }
    }
}

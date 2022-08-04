using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movements))]
public class ControllerAnimationsPlayer : MonoBehaviour
{
    private Movements _movements;
    private Animator _animator;

    private void Start()
    {
        _movements = GetComponent<Movements>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetFloat("Speed", _movements.Speed);

        if (_movements.IsGroun == false)
        {
            _animator.SetFloat("Speed", 0);
            _animator.SetBool("Ground", false);
            _animator.SetFloat("VelosityY", _movements.DirectionMoveY);
        }
        else
        {
            _animator.SetBool("Ground", true);
            _animator.SetFloat("VelosityY", 0);
        }
    }
}

using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(DefintionCollision))]
public class ControllerAnimationsPlayer : MonoBehaviour
{
    private Movement _movements;
    private Animator _animator;
    private DefintionCollision _defintionCollision;
    private int ParameterSpeedHash = Animator.StringToHash("Speed");
    private int ParameterVelosityYHash = Animator.StringToHash("VelosityY");
    private int ParameterGroundHash = Animator.StringToHash("Ground");

    private void Start()
    {
        _defintionCollision = GetComponent<DefintionCollision>();
        _movements = GetComponent<Movement>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetFloat(ParameterSpeedHash, _movements.Speed);

        if (_defintionCollision.IsGroun == false)
        {
            _animator.SetFloat(ParameterSpeedHash, 0);
            _animator.SetBool(ParameterGroundHash, false);
            _animator.SetFloat(ParameterVelosityYHash, _movements.DirectionMoveY);
        }
        else
        {
            _animator.SetBool(ParameterGroundHash, true);
            _animator.SetFloat(ParameterVelosityYHash, 0);
        }
    }
}

using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent (typeof(DefintionCollision))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speedWalk;
    [SerializeField] private float _speedRun;
    [SerializeField] private float _powerJump;

    private Movement _movement;
    private DefintionCollision _defintionCollision;
    private float _directionMoveX;

    private void Start()
    {
        _defintionCollision = GetComponent<DefintionCollision>();
        _movement = GetComponent<Movement>();
    }

    private void Update()
    {
        _directionMoveX = Input.GetAxisRaw("Horizontal");

        if (_defintionCollision.TransferCollaiderCollision() != null && _defintionCollision.TransferCollaiderCollision().TryGetComponent<Enemy>(out Enemy enemy))
        {
            _movement.Jump(_powerJump);
            enemy.Die();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _movement.Jump(_powerJump);
        }

        if(_directionMoveX != 0)
        {
            if(Input.GetKey(KeyCode.LeftShift) && _defintionCollision.IsGroun == true)
            {
                _movement.StartMove(_speedRun, _directionMoveX);
                return;
            }
            _movement.StartMove(_speedWalk, _directionMoveX);
        }
        else
        {
            _movement.EndMove();
        }
    }
}

using UnityEngine;
using System.Collections;
using Assets.Scripts.Input;
using Assets.Scripts.Movement;
using Assets.Scripts.Player;
using Assets.Scripts.Player.Swords.Abstract.Movement;

public class PlayerMovement : MonoBehaviour
{
    public bool CanMove = true;
    public float Speed;

    private Rigidbody _rigidbody;
    private MovementRotater _movementRotater;
    private MovementAnimator _movementAnimator;
    private InputAxis XAxis;
    private InputAxis ZAxis;
    private bool _haveTriedToMovePlayer;

    private Vector3 _moveDirection;
    private Vector3 _inputDirection;

    // Use this for initialization
    void Start()
    {
        CanMove = true;
        XAxis = transform.FindComponentInChildWithTag<InputAxis>("XAxis");
        ZAxis = transform.FindComponentInChildWithTag<InputAxis>("ZAxis");
        XAxis.AxisMoving += SetXAxis;
        ZAxis.AxisMoving += SetZAxis;
        _rigidbody = GetComponent<Rigidbody>();
        _movementRotater = GetComponent<MovementRotater>();
        _movementAnimator = GetComponentInChildren<MovementAnimator>();
        _rigidbody.freezeRotation = true;
    }


    void SetXAxis(float x)
    {
        _inputDirection.x = x;
    }

    void SetZAxis(float z)
    {
        _inputDirection.z = z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CanMove)
        {
            Move();
        }
    }

    private void Move()
    {
        _moveDirection = Vector3.zero;

        if (_inputDirection.magnitude > 0.5f)
        {
            _moveDirection = -transform.forward * Speed;
            _movementRotater.SetRotation(_inputDirection);
        }

        _moveDirection.y = _rigidbody.velocity.y;

        _rigidbody.velocity = (_moveDirection);

        _movementAnimator.SetAnimatorSpeed(_inputDirection);

        _inputDirection = Vector3.zero;
    }
}

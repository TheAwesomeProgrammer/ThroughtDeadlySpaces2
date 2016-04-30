﻿using UnityEngine;
using System.Collections;
using Assets.Scripts.Input;
using Assets.Scripts.Movement;
using Assets.Scripts.Player;
using Assets.Scripts.Player.Swords.Abstract.Movement;

public class PlayerMovement : MonoBehaviour
{
    public bool CanMove = true;

    private CharacterController _mover;
    private MovementRotater _movementRotater;
    private MovementAnimator _movementAnimator;
    private PlayerProperties _playerProperties;
    private InputAxis XAxis;
    private InputAxis ZAxis;

    private Vector3 _moveDirection;
    private Vector3 _rotationDirection;


    // Use this for initialization
    void Start()
    {
        CanMove = true;
        XAxis = transform.FindComponentInChildWithTag<InputAxis>("XAxis");
        ZAxis = transform.FindComponentInChildWithTag<InputAxis>("ZAxis");
        XAxis.AxisMoving += SetXAxis;
        ZAxis.AxisMoving += SetZAxis;
        _mover = GetComponent<CharacterController>();
        _movementRotater = GetComponent<MovementRotater>();
        _movementAnimator = GetComponentInChildren<MovementAnimator>();
        _playerProperties = GetComponentInParent<PlayerProperties>();
    }


    void SetXAxis(float x)
    {
        if (CanMove)
        {
            _rotationDirection.x = x;
        }

    }

    void SetZAxis(float z)
    {
        if (CanMove)
        {
            _rotationDirection.z = z;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        _moveDirection = Vector3.zero;

        if (_rotationDirection.magnitude > 0.5f){
            
            _moveDirection = -transform.forward *_playerProperties.Speed;
            _movementRotater.SetRotation(_rotationDirection);
        }

        _moveDirection.y = -_playerProperties.Gravity;

        _mover.Move(_moveDirection * Time.deltaTime);

        _movementAnimator.SetAnimatorSpeed(_rotationDirection);

        _moveDirection = Vector3.zero;
    }
}

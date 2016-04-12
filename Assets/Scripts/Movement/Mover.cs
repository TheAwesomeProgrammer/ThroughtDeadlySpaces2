﻿using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public float Speed = 10;

    private Vector3 _moveDirection = Vector3.right;

    private Rigidbody _rigidbody;

    public Vector3 MoveDirection
    {
        get { return _moveDirection; }
        set { _moveDirection = value; }
    }

	// Use this for initialization
	void Start ()
	{
	    _rigidbody = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update ()
	{
	    Move();
	}

    void Move()
    {
        _rigidbody.velocity = _moveDirection * Time.deltaTime * Speed;
    }
}

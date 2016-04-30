using System;
using UnityEngine;
using System.Collections;
using Assets.Scripts.Player.Swords.Abstract.Movement;

public class Mover : MonoBehaviour
{
    public float Speed { get; set; }
    public event Action<Vector3> MoveDirectionChanged;

    private Vector3 _moveDirection = Vector3.right;

    private Rigidbody _rigidbody;

    public Vector3 MoveDirection
    {
        get { return _moveDirection; }
        set
        {
            if (_moveDirection != value)
            {
                if (MoveDirectionChanged != null)
                {
                    MoveDirectionChanged(value);
                }
                _moveDirection = value;
            }
        }
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

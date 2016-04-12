using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    private Mover _mover;
    private MovementInputPc _movementInputPc;
    private MovementInputXbox _movementInputXbox;

    private Vector3 _moveDirection;

	// Use this for initialization
	void Start ()
	{
	    _movementInputPc = GetComponent<MovementInputPc>();
	    _movementInputXbox = GetComponent<MovementInputXbox>();
        _mover = GetComponent<Mover>();

        _movementInputPc.InputPressed += (direction) => _moveDirection = direction;
	    _movementInputXbox.InputPressed += (direction) => _moveDirection = direction;

	}
	
	// Update is called once per frame
	void Update ()
	{
	    _mover.MoveDirection = _moveDirection;
	    _moveDirection = Vector3.zero;
	}
}

using UnityEngine;
using System.Collections;
using Assets.Scripts.Input;

public class PlayerMovement : MonoBehaviour
{
    public bool CanMove = true;

    private Mover _mover;
    private InputAxis XAxis;
    private InputAxis ZAxis;

    private Vector3 _moveDirection;

    // Use this for initialization
    void Start()
    {
        CanMove = true;
        XAxis = transform.FindComponentInChildWithTag<InputAxis>("XAxis");
        ZAxis = transform.FindComponentInChildWithTag<InputAxis>("ZAxis");
        XAxis.AxisMoving += SetXAxis;
        ZAxis.AxisMoving += SetZAxis;
        _mover = GetComponent<Mover>();
    }

    void SetXAxis(float x)
    {
        if (CanMove)
        {
            _moveDirection.x = x;
        }

    }

    void SetZAxis(float z)
    {
        if (CanMove)
        {
            _moveDirection.z = z;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        _mover.MoveDirection = _moveDirection;
        _moveDirection = Vector3.zero;
    }
}

using UnityEngine;
using System.Collections;
using Assets.Scripts.Input;
using Assets.Scripts.Movement;
using Assets.Scripts.Player;
using Assets.Scripts.Player.Movement;
using Assets.Scripts.Player.Swords.Abstract.Movement;

public class PlayerMovementController : MonoBehaviour
{
    public bool CanMove
    {
        get { return _canMove; }
        set
        {
            if (_canMove != value)
            {
                _canMove = value;
                if (_canMove)
                {
                    _moveable.Resume();
                }
                else
                {
                    _moveable.Stop();
                }
            }
        }
    }

    private bool _canMove;

    private Moveable _moveable;

    private void Start()
    {
        _moveable = GetComponent<Moveable>();
    }
}

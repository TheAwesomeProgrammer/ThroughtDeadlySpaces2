using System.Collections.Generic;
using Assets.Scripts.Enviroment.Collisions.Abstract;
using UnityEngine;
public interface Collisionable
{
    List<string> Tags { get; set; }
    CollisionType CollisionType { get; set; }

    void OnEnterWithTag();
    void OnStayWithTag();
    void OnExitWithTag();
}

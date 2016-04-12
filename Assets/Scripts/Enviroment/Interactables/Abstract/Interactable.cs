using System.Collections.Generic;
using UnityEngine;
public interface Interactable
{
    List<string> Tags { get; set; }

    void OnEnter(object otherCollisionObject);
    void OnStay(object otherCollisionObject);
    void OnExit(object otherCollisionObject);
}

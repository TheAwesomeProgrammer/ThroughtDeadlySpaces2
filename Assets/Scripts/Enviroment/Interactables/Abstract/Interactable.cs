using System.Collections.Generic;
using UnityEngine;
public interface Interactable
{
    List<string> Tags { get; set; }

    void OnEnter();
    void OnStay();
    void OnExit();
}

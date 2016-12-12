using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour 
{
	void Update () 
    {
        gameObject.transform.Rotate(0.0f, 180.0f * Time.deltaTime, 0.0f);
        DebugLogging.Log("Transform : " + gameObject.name + " : " + gameObject.transform.localToWorldMatrix.ToString());
	}
}

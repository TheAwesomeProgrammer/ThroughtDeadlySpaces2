using UnityEngine;
using System.Collections;

public class TestLightBounce : MonoBehaviour
{
	public float speed = 2.0f;
	public float range = 4.0f;

	private Transform trans;
	private Vector3 pos;
	private float inc;

	void Start()
	{
		trans = GetComponent<Transform>();
		pos = trans.position;
		inc = 1.0f;
	}

	void Update()
	{
		pos.x +=  inc * speed * Time.deltaTime;
		if ((inc > 0.0f && pos.x > range) || (inc < 0.0f && pos.x < -range))
			inc = -inc;
		trans.position = pos;
	}
}

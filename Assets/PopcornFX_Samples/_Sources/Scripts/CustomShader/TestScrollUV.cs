using UnityEngine;
using System.Collections;

public class TestScrollUV : MonoBehaviour
{
	public float speed = 0.1f;
	public PkFxCustomShader customShader;
	public string constantName;

	private float val = 0.0f;

	void OnEnable()
	{
		if (customShader.ApiInUse() == false)
		{
			this.enabled = false;
			return;
		}

		PKFxRenderingPlugin renderingPlugin = GameObject.FindObjectOfType<PKFxRenderingPlugin>();
		if (renderingPlugin != null)
		{
			if (!renderingPlugin.m_BoundShaders.Contains(customShader))
				renderingPlugin.m_BoundShaders.Add(customShader);
		}
	}

	void Update ()
	{
		val += speed * Time.deltaTime;
		if (val >= 0.5f)
			val = -0.5f;
		customShader.SetConstant(new PKFxManager.ShaderConstant(constantName, new Vector2(val, 0)));
	}
}

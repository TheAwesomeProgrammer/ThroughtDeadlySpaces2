using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Light))]
public class CustomShaderPointLight : MonoBehaviour
{
	public string posConstantName;
	public string colorConstantName;
	public string cameraConstantName;
	public PkFxCustomShader customShader;
	private Light lightComp;
	private Transform lightTransform;

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

	void Start()
	{
		this.lightComp = GetComponent<Light>();
		this.lightTransform = lightComp.transform;
	}
	
	// Update is called once per frame
	void Update()
	{
		Vector4	value = new Vector4(lightTransform.position.x, lightTransform.position.y, lightTransform.position.z);
		value.w = lightComp.range;
		this.customShader.SetConstant(new PKFxManager.ShaderConstant(this.posConstantName, value));
		Vector4 color = new Vector4(lightComp.color.r, lightComp.color.g, lightComp.color.b, lightComp.color.a);
		this.customShader.SetConstant(new PKFxManager.ShaderConstant(this.colorConstantName, color));
		this.customShader.SetConstant(new PKFxManager.ShaderConstant(this.cameraConstantName, Camera.main.transform.position));
	}
}

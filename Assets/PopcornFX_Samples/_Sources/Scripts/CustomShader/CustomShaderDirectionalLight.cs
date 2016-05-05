using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Light))]
public class CustomShaderDirectionalLight : MonoBehaviour
{
	public string colorConstantName;
	public string dirConstantName;
	public string cameraConstantName;
	public PkFxCustomShader customShader;
	private Light lightComp;
	private Transform lightTransform;

	void OnEnable()
	{
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
		Vector4 color = new Vector4(lightComp.color.r, lightComp.color.g, lightComp.color.b, lightComp.color.a);
		this.customShader.SetConstant(new PKFxManager.ShaderConstant(this.colorConstantName, color));
		this.customShader.SetConstant(new PKFxManager.ShaderConstant(this.dirConstantName, lightTransform.forward));
		this.customShader.SetConstant(new PKFxManager.ShaderConstant(this.cameraConstantName, Camera.main.transform.position));
	}
}

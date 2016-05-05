#if defined(PK_VERTEX_SHADER)

float4x4	matWVP : register(c0);

struct		VS_IN
{
	float4	ObjPos	: POSITION;
	float2	UV		: TEXCOORD0;
	float4	Color	: COLOR;
	float3	Normal	: TEXCOORD1;
};

struct		VS_OUT
{
	float4	Position	: SV_POSITION;
	float2	UV			: TEXCOORD0;
	float4	ProjPos		: TEXCOORD1;
	float4	Color		: COLOR;
	float3	Normal		: TEXCOORD2;
	float4	Pos			: TEXCOORD3;
};

VS_OUT		main(VS_IN In)
{
	VS_OUT	Out;
	Out.Position = mul(matWVP, In.ObjPos);
	Out.ProjPos = Out.Position;
	Out.UV = In.UV;
	Out.Color = In.Color;
	Out.Normal = In.Normal;
	Out.Normal.z = -Out.Normal.z;
	Out.Pos = In.ObjPos;
	return Out;
}

#endif



#if defined(PK_PIXEL_SHADER)

float4			ZBufferParams	: register(c0);
float			SoftnessDistance : register(c1);
Texture2D		ColorTexture	: register(t0);
Texture2D		DepthTexture	: register(t1);
Texture2D		NormalTexture	: register(t2);
SamplerState	ColorSampler	: register(s0);
SamplerState	DepthSampler	: register(s1);
SamplerState	NormalSampler	: register(s2);

cbuffer		PK_PS : register(b1)
{
	float4		PointLightPos; // pos.x pos.y pos.z range
	float4		PointLightColor;
	float3		CameraPos;
	float4		DIFFUSE;
	float4		SPECULAR;
	float2		SHININESS;
}

struct		PS_IN
{
	float4	Position	: SV_POSITION;
	float2	UV			: TEXCOORD0;
	float4	ProjPos		: TEXCOORD1;	
	float4	Color		: COLOR;
	float3	Normal		: TEXCOORD2;
	float4	Pos			: TEXCOORD3;
};

float	clipToLinearDepth(float depth)
{
	float zNear = ZBufferParams.x;
	float zFar = ZBufferParams.y;
	return (-zNear * zFar) / (depth * (zFar - zNear) - zFar);
}

float4	main(PS_IN In) : SV_TARGET
{
	float3 normMap = NormalTexture.Sample(NormalSampler, In.UV).xyz;
	normMap.z = - normMap.z;
	float3 norm = normalize(In.Normal + normMap);
	float3 lightVec = PointLightPos.xyz - In.Pos.xyz;
	float dist = length(lightVec);
	lightVec = normalize(lightVec);
	float attenuation = max(0.0, 1.0 - (dist / PointLightPos.w));
	float nxDir = max(0.0, dot(norm, lightVec));
	//float nxDir = 1.0;
	float4 diffuse = DIFFUSE * PointLightColor * attenuation * nxDir;
	
	float4 specular = float4(0.0, 0.0, 0.0, 0.0);
	if (SHININESS.y > 0 && nxDir != 0.0)
	{
		float3 camVec = normalize(CameraPos - In.Pos.xyz);
		float specularPow = pow(max(0.0, dot(camVec, reflect(-lightVec, norm))), SHININESS.x);
		specular = SPECULAR * PointLightColor * specularPow * attenuation;
	}

	float rcpw = 1.0 / In.ProjPos.w;
	float2 screenUV = In.ProjPos.xy * rcpw * float2(0.5, -0.5) + 0.5;
	float sceneDepth_cs = DepthTexture.Sample(DepthSampler, screenUV).x;
	float sceneDepth = clipToLinearDepth(sceneDepth_cs);
	float fragDepth = clipToLinearDepth(In.ProjPos.z * rcpw);
	float fade = saturate(SoftnessDistance * (sceneDepth - fragDepth));
	
	float4 texColor = ColorTexture.Sample(ColorSampler, In.UV);
	float4 outCol = In.Color * texColor;
	outCol = outCol + diffuse * texColor.a + specular * texColor.a;
	outCol *= fade;
	outCol.a = min(1.0, outCol.a);
	return outCol;
}

#endif
#if defined(PK_VERTEX_SHADER)

float4x4	matWVP : register(c0);						
														
struct		VS_IN										
{														
	float4	ObjPos			: POSITION;						
	float2	UV0				: TEXCOORD0;					
	float2	UV1				: TEXCOORD1;					
	float	AtlasID			: TEXCOORD2;					
	float4	Color			: COLOR;
	float	PK_LifeRatio	: TEXCOORD3;
};														
														
struct		VS_OUT										
{														
	float4	Position	: SV_POSITION;					
	float4	UV			: TEXCOORD0;					
	float	FrameLerp	: TEXCOORD1;					
	float4	ProjPos		: TEXCOORD2;					
	float4	Color		: COLOR;
	float	LifeRatio	: TEXCOORD3;
};														
														
VS_OUT		main(VS_IN In)								
{														
	VS_OUT	Out;										
	Out.Position = mul(matWVP, In.ObjPos);				
	Out.ProjPos = Out.Position;							
	Out.UV = float4(In.UV0, In.UV1);					
	Out.FrameLerp = frac(In.AtlasID);					
	Out.Color = In.Color;
	Out.LifeRatio = In.PK_LifeRatio;
	return Out;											
}														

#endif

//------------------------------------------------

#if defined(PK_PIXEL_SHADER)

float4			ZBufferParams	: register(c0);								
float			SoftnessDistance : register(c1);							
Texture2D		ColorTexture	: register(t0);								
Texture2D		DepthTexture	: register(t1);								
SamplerState	ColorSampler	: register(s0);								
SamplerState	DepthSampler	: register(s1);								
																			
float	clipToLinearDepth(float depth)											
{																				
	float zNear = ZBufferParams.x;												
	float zFar = ZBufferParams.y;												
	return (-zNear * zFar) / (depth * (zFar - zNear) - zFar);					
}																				
																			
struct		PS_IN															
{																			
	float4	Position	: SV_POSITION;										
	float4	UV			: TEXCOORD0;										
	float	FrameLerp	: TEXCOORD1;										
	float4	ProjPos		: TEXCOORD2;										
	float4	Color		: COLOR;
	float	LifeRatio	: TEXCOORD3;
};																			
																			
float4	main(PS_IN In) : SV_TARGET											
{																			
	float rcpw = 1.0 / In.ProjPos.w;										
	float2 screenUV = In.ProjPos.xy * rcpw * float2(0.5, -0.5) + 0.5;		
	float sceneDepth_cs = DepthTexture.Sample(DepthSampler, screenUV).x;	
	float sceneDepth = clipToLinearDepth(sceneDepth_cs);					
	float fragDepth = clipToLinearDepth(In.ProjPos.z * rcpw);				
	float fade = saturate(SoftnessDistance * (sceneDepth - fragDepth));		
																			
																			
	float4	diffuseA = ColorTexture.Sample(ColorSampler, In.UV.xy);			
	float4	diffuseB = ColorTexture.Sample(ColorSampler, In.UV.zw);			
	float4	outCol = In.Color * lerp(diffuseA, diffuseB, In.FrameLerp);		
	
	if (In.LifeRatio > 0.5f)
	{
		float tmp = outCol.g;
		outCol.g = outCol.r;
		outCol.r = tmp;
	}
	
	outCol *= fade;															
#if defined(MAT_ADDITIVE_ALPHA)											
	outCol *= outCol.w;														
	outCol.w = 0.0f;														
#endif																		
#if defined(MAT_ADDITIVE_NOALPHA)											
	outCol.w = 0.0f;														
#endif	
	return outCol;															
}																			

#endif


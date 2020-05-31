Shader "Custom/shadermask"
{
	Properties
	{

		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Mask("Mask Texture", 2D) = "white" {}
	}
		SubShader
	{
		Tags {"Queue"= "Transparent"}
	 Lighting On
	 ZWrite Off
	 Blend SrcAlpha OneMinusSrcAlpha

		Pass{
		SetTexture[_mask] {combine texture}
		SetTexture[_MainTex] {combine texture, previous}
		
		}
	}
}

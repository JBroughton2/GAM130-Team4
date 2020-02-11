Shader "Custom/Transparent" {
	Properties{
	  _Color("Color", Color) = (1.0, 1.0, 1.0, 1.0)
	  _MainTex("Base (RGB)", 2D) = "white" {}
	}
	SubShader{
			Tags{ "RenderType" = "Fade" "ForceNoShadowCasting" = "True" "Queue" = "Transparent" }


			Pass{
				Blend Zero One

				SetTexture[_MainTex] { combine texture }
			}
	}
	
	FallBack "Diffuse"
}
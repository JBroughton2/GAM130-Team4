Shader "Custom/MaskShader"
{    
	Properties {
		_Color("Main Color", Color) = (1,1,1,1)
		_MainTex("Base (RGB)", 2D) = "white" {}
	}
	Category{
		Lighting Off
		ZWrite On
		Cull Back

		SubShader{
			Tags{ "RenderType" = "Opaque" "ForceNoShadowCasting" = "True" "Queue" = "Geometry" }

			Stencil
			{
				Ref 1
				Comp Never
				Fail Replace
			}

			Pass{
				SetTexture[_MainTex]{
					constantColor[_Color]
					Combine texture * constant, texture * constant
				}
			}
		}
	}
}

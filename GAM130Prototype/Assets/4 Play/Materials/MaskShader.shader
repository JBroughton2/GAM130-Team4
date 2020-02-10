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
			Tags{ "RenderType" = "Transparent" "ForceNoShadowCasting" = "True" "Queue" = "Geometry" }
			

			Pass{
				Stencil
				{
					Ref 1
					Comp Never
					Fail Replace
					ZFail Zero
				}			
			}
		}
	}
}

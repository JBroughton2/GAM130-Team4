Shader "Custom/MaskShader"
{    
	Properties {
		_MainTex("Base (RGB)", 2D) = "white" {}
	}
	Category{
		Lighting Off
		ZWrite On
		Cull Back

		SubShader{
			Tags{ "RenderType" = "Opaque" "ForceNoShadowCasting" = "True" "Queue" = "Transparent" }
			

			Pass{
				Stencil
				{
					Ref 1
					Comp Always
					Pass Replace
					ZFail Zero
				}	
				
				Blend Zero One
				
				SetTexture[_MainTex] { combine texture }				
			}
		}
	}
}

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
					Comp Always
					Pass Replace
					ZFail Zero
				}	

				 CGPROGRAM
				#pragma vertex vert_img
				#pragma fragment frag
				#pragma fragmentoption ARB_precision_hint_fastest 
				#include "UnityCG.cginc"
				
				float4 frag() : COLOR
				{
					clip(-1.0);

					return 1.0;
				}	
				ENDCG
			}
		}
	}
}

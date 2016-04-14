Shader "RBase/StartLocationPreview"
{
	SubShader
	{
		Tags { "RenderType"="Opaque" }

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				float3 local_position : TEXCOORD1;
			};
			
			v2f vert (appdata v)
			{
				v2f o;

				float pi = 3.141592;
				float angle = fmod(_Time.z, pi * 2.0);
				float cosa = cos(angle);
				float sina = sin(angle);
				float2x2 rmat = float2x2(cosa, -sina, sina, cosa);
				float2 rotation = mul(rmat, v.vertex.xz);
				float4 nexPos = float4(rotation.x, v.vertex.y, rotation.y, v.vertex.w);
				o.vertex = mul(UNITY_MATRIX_MVP, nexPos);
				o.local_position = nexPos.xyz;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				float3 pos = float3(i.local_position.x, i.local_position.y, i.local_position.z);

				float r = pos.x + 0.5;
				float g = pos.y + 0.5;
				float b = pos.z + 0.5;

				float4 col = float4(r, g, b, 1);

				return col;
			}
			ENDCG
		}
	}
}

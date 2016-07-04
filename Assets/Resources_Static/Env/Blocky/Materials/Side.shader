// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:0,lgpr:1,limd:2,spmd:1,trmd:0,grmd:0,uamb:False,mssp:False,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:7184,x:32587,y:32815,varname:node_7184,prsc:2|diff-7438-OUT,spec-2832-OUT;n:type:ShaderForge.SFN_Color,id:4811,x:31933,y:32736,ptovrint:False,ptlb:MainColor,ptin:_MainColor,varname:node_4811,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Vector1,id:2832,x:32362,y:33255,varname:node_2832,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Slider,id:6233,x:31388,y:33212,ptovrint:False,ptlb:FadeStart,ptin:_FadeStart,varname:node_6233,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.01,cur:0.01,max:5;n:type:ShaderForge.SFN_Color,id:7962,x:31933,y:32911,ptovrint:False,ptlb:FadeColor,ptin:_FadeColor,varname:node_7962,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Lerp,id:7438,x:32262,y:32925,varname:node_7438,prsc:2|A-4811-RGB,B-7962-RGB,T-8438-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:4028,x:31545,y:33059,varname:node_4028,prsc:2;n:type:ShaderForge.SFN_Code,id:8438,x:31749,y:33114,varname:node_8438,prsc:2,code:aQBmACAAKABwAG8AcwBZACAAPgAgAC0AIABmAGEAZABlAFkAKQAKAHsACgAgACAAIAByAGUAdAB1AHIAbgAgADAALgAwADsACgB9AAoACgBmAGwAbwBhAHQAIAByAGUAcwB1AGwAdAA7AAoACgByAGUAcwB1AGwAdAAgAD0AIAAtACAAZgBhAGQAZQBZACAALQAgAHAAbwBzAFkAOwAKAAoAcgBlAHQAdQByAG4AIABmAGEAZABlAFAAIAAqACAAcgBlAHMAdQBsAHQAOwA=,output:0,fname:Function_node_8438,width:394,height:254,input:0,input:0,input:0,input_1_label:posY,input_2_label:fadeY,input_3_label:fadeP|A-4028-Y,B-6233-OUT,C-4416-OUT;n:type:ShaderForge.SFN_Slider,id:4416,x:31388,y:33314,ptovrint:False,ptlb:FadePower,ptin:_FadePower,varname:_FadeStart_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:1,cur:1,max:10;proporder:4811-6233-7962-4416;pass:END;sub:END;*/

Shader "SIX/Tile_Side" {
    Properties {
        _MainColor ("MainColor", Color) = (0.5,0.5,0.5,1)
        _FadeStart ("FadeStart", Range(0.01, 5)) = 0.01
        _FadeColor ("FadeColor", Color) = (0.5,0.5,0.5,1)
        _FadePower ("FadePower", Range(1, 10)) = 1
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _MainColor;
            uniform float _FadeStart;
            uniform float4 _FadeColor;
            float Function_node_8438( float posY , float fadeY , float fadeP ){
            if (posY > - fadeY)
            {
               return 0.0;
            }
            
            float result;
            
            result = - fadeY - posY;
            
            return fadeP * result;
            }
            
            uniform float _FadePower;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float node_2832 = 0.1;
                float3 specularColor = float3(node_2832,node_2832,node_2832);
                float3 directSpecular = attenColor * pow(max(0,dot(reflect(-lightDirection, normalDirection),viewDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 diffuseColor = lerp(_MainColor.rgb,_FadeColor.rgb,Function_node_8438( i.posWorld.g , _FadeStart , _FadePower ));
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}

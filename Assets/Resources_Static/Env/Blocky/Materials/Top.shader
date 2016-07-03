// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:0,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:False,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:9305,x:32949,y:32724,varname:node_9305,prsc:2|diff-7012-OUT,spec-6173-OUT,gloss-5446-OUT,normal-8399-RGB;n:type:ShaderForge.SFN_Tex2d,id:48,x:32070,y:32435,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_48,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:7700,x:32070,y:32627,ptovrint:False,ptlb:AddColor,ptin:_AddColor,varname:node_7700,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Add,id:9885,x:32321,y:32521,varname:node_9885,prsc:2|A-48-RGB,B-7700-RGB;n:type:ShaderForge.SFN_Color,id:9241,x:32070,y:32803,ptovrint:False,ptlb:MulColor,ptin:_MulColor,varname:node_9241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:961,x:32321,y:32691,varname:node_961,prsc:2|A-9885-OUT,B-9241-RGB;n:type:ShaderForge.SFN_Slider,id:1054,x:31910,y:33358,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_1054,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2d,id:7411,x:32067,y:33165,ptovrint:False,ptlb:M_G,ptin:_M_G,varname:node_7411,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:6173,x:32294,y:33220,varname:node_6173,prsc:2|A-7411-R,B-1054-OUT;n:type:ShaderForge.SFN_Slider,id:6102,x:31910,y:33446,ptovrint:False,ptlb:Glossy,ptin:_Glossy,varname:node_6102,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:5446,x:32304,y:33384,varname:node_5446,prsc:2|A-7411-B,B-6102-OUT;n:type:ShaderForge.SFN_Tex2d,id:8399,x:32067,y:32975,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_8399,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Color,id:3388,x:32012,y:32217,ptovrint:False,ptlb:BorderColor,ptin:_BorderColor,varname:node_3388,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:7012,x:32630,y:32494,varname:node_7012,prsc:2|A-5922-OUT,B-961-OUT;n:type:ShaderForge.SFN_TexCoord,id:2143,x:32012,y:32044,varname:node_2143,prsc:2,uv:0;n:type:ShaderForge.SFN_Slider,id:897,x:31869,y:31960,ptovrint:False,ptlb:BorderWidth,ptin:_BorderWidth,varname:node_897,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:0.5;n:type:ShaderForge.SFN_Code,id:5922,x:32272,y:31996,varname:node_5922,prsc:2,code:YgBvAG8AbAAgAHIAZQBzAHUAbAB0ACAAPQAgAGYAYQBsAHMAZQA7AAoAaQBmACAAKAB1AHYALgB4ACAAPAAgADAALgA1ACkACgB7AAoAIAAgACAAaQBmACAAKAB1AHYALgB4ACAAPAAgAGIAbwByAGQAZQByAFMAZQB0ACkACgAgACAAIAB7AAoAIAAgACAAIAAgACAAcgBlAHQAdQByAG4AIABiAG8AcgBkAGUAcgBDAG8AbABvAHIAOwAKACAAIAAgAH0ACgB9ACAAZQBsAHMAZQAgAGkAZgAgACgAdQB2AC4AeAAgAD4AIAAwAC4ANQApAAoAewAKACAAIAAgAGkAZgAgACgAdQB2AC4AeAAgAD4AIAAxACAALQAgAGIAbwByAGQAZQByAFMAZQB0ACkACgAgACAAIAB7AAoAIAAgACAAIAAgACAAcgBlAHQAdQByAG4AIABiAG8AcgBkAGUAcgBDAG8AbABvAHIAOwAKACAAIAAgAH0ACgB9AAoACgBpAGYAIAAoAHUAdgAuAHkAIAA8ACAAMAAuADUAKQAKAHsACgAgACAAIABpAGYAIAAoAHUAdgAuAHkAIAA8ACAAYgBvAHIAZABlAHIAUwBlAHQAKQAKACAAIAAgAHsACgAgACAAIAAgACAAIAByAGUAdAB1AHIAbgAgAGIAbwByAGQAZQByAEMAbwBsAG8AcgA7AAoAIAAgACAAfQAKAH0AIABlAGwAcwBlACAAaQBmACAAKAB1AHYALgB5ACAAPgAgADAALgA1ACkACgB7AAoAIAAgACAAaQBmACAAKAB1AHYALgB5ACAAPgAgADEAIAAtACAAYgBvAHIAZABlAHIAUwBlAHQAKQAKACAAIAAgAHsACgAgACAAIAAgACAAIAByAGUAdAB1AHIAbgAgAGIAbwByAGQAZQByAEMAbwBsAG8AcgA7AAoAIAAgACAAfQAKAH0ACgAKAHIAZQB0AHUAcgBuACAAZgBsAG8AYQB0ADMAKAAxACwAIAAxACwAIAAxACkAOwA=,output:2,fname:IsBorder,width:356,height:451,input:1,input:0,input:2,input_1_label:uv,input_2_label:borderSet,input_3_label:borderColor|A-2143-UVOUT,B-897-OUT,C-3388-RGB;proporder:48-7700-9241-8399-7411-1054-6102-3388-897;pass:END;sub:END;*/

Shader "SIX/Tile_Top" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _AddColor ("AddColor", Color) = (0.5,0.5,0.5,1)
        _MulColor ("MulColor", Color) = (0.5,0.5,0.5,1)
        _Normal ("Normal", 2D) = "bump" {}
        _M_G ("M_G", 2D) = "white" {}
        _Metallic ("Metallic", Range(0, 1)) = 0
        _Glossy ("Glossy", Range(0, 1)) = 0
        _BorderColor ("BorderColor", Color) = (0.5,0.5,0.5,1)
        _BorderWidth ("BorderWidth", Range(0, 0.5)) = 0
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
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _AddColor;
            uniform float4 _MulColor;
            uniform float _Metallic;
            uniform sampler2D _M_G; uniform float4 _M_G_ST;
            uniform float _Glossy;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform float4 _BorderColor;
            uniform float _BorderWidth;
            float3 IsBorder( float2 uv , float borderSet , float3 borderColor ){
            bool result = false;
            if (uv.x < 0.5)
            {
               if (uv.x < borderSet)
               {
                  return borderColor;
               }
            } else if (uv.x > 0.5)
            {
               if (uv.x > 1 - borderSet)
               {
                  return borderColor;
               }
            }
            
            if (uv.y < 0.5)
            {
               if (uv.y < borderSet)
               {
                  return borderColor;
               }
            } else if (uv.y > 0.5)
            {
               if (uv.y > 1 - borderSet)
               {
                  return borderColor;
               }
            }
            
            return float3(1, 1, 1);
            }
            
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float4 _M_G_var = tex2D(_M_G,TRANSFORM_TEX(i.uv0, _M_G));
                float gloss = (_M_G_var.b*_Glossy);
                float specPow = exp2( gloss * 10.0+1.0);
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 diffuseColor = (IsBorder( i.uv0 , _BorderWidth , _BorderColor.rgb )*((_MainTex_var.rgb+_AddColor.rgb)*_MulColor.rgb)); // Need this for specular when using metallic
                float specularMonochrome;
                float3 specularColor;
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, (_M_G_var.r*_Metallic), specularColor, specularMonochrome );
                specularMonochrome = 1-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float NdotH = max(0.0,dot( normalDirection, halfDirection ));
                float VdotH = max(0.0,dot( viewDirection, halfDirection ));
                float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
                float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
                float specularPBL = max(0, (NdotL*visTerm*normTerm) * (UNITY_PI / 4) );
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
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

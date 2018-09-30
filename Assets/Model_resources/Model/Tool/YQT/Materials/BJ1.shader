// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.32 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.32;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:1492,x:32719,y:32712,varname:node_1492,prsc:2|diff-7964-OUT,spec-102-OUT,gloss-102-OUT,clip-8316-OUT;n:type:ShaderForge.SFN_Color,id:3653,x:32014,y:32441,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_3653,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Vector1,id:102,x:32394,y:32763,varname:node_102,prsc:2,v1:1;n:type:ShaderForge.SFN_TexCoord,id:9725,x:31120,y:32855,varname:node_9725,prsc:2,uv:0;n:type:ShaderForge.SFN_ArcTan2,id:8674,x:31898,y:32835,varname:node_8674,prsc:2,attp:0|A-7716-R,B-7716-G;n:type:ShaderForge.SFN_RemapRange,id:1297,x:31542,y:32840,varname:node_1297,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-9538-UVOUT;n:type:ShaderForge.SFN_ComponentMask,id:7716,x:31717,y:32840,varname:node_7716,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-1297-OUT;n:type:ShaderForge.SFN_Rotator,id:9538,x:31347,y:32926,varname:node_9538,prsc:2|UVIN-9725-UVOUT,ANG-2531-OUT;n:type:ShaderForge.SFN_Blend,id:2749,x:32105,y:33024,varname:node_2749,prsc:2,blmd:16,clmp:True|SRC-211-OUT,DST-5094-OUT;n:type:ShaderForge.SFN_Slider,id:5094,x:31741,y:33048,ptovrint:False,ptlb:Cut,ptin:_Cut,varname:node_5094,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1.01;n:type:ShaderForge.SFN_RemapRange,id:211,x:32105,y:32835,varname:node_211,prsc:2,frmn:-3.14,frmx:3.14,tomn:0,tomx:1|IN-8674-OUT;n:type:ShaderForge.SFN_Vector1,id:2531,x:31158,y:33163,varname:node_2531,prsc:2,v1:3.14;n:type:ShaderForge.SFN_Tex2d,id:1935,x:32014,y:32615,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_1935,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:7964,x:32244,y:32537,varname:node_7964,prsc:2|A-3653-RGB,B-1935-RGB;n:type:ShaderForge.SFN_Multiply,id:8316,x:32476,y:32884,varname:node_8316,prsc:2|A-1935-A,B-5585-OUT;n:type:ShaderForge.SFN_OneMinus,id:5585,x:32291,y:33004,varname:node_5585,prsc:2|IN-2749-OUT;proporder:3653-5094-1935;pass:END;sub:END;*/

Shader "DSYZ/BJ1" {
    Properties {
        _Color ("Color", Color) = (0.5,0.5,0.5,1)
        _Cut ("Cut", Range(0, 1.01)) = 0
        _Texture ("Texture", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
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
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _Color;
            uniform float _Cut;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                float node_9538_ang = 3.14;
                float node_9538_spd = 1.0;
                float node_9538_cos = cos(node_9538_spd*node_9538_ang);
                float node_9538_sin = sin(node_9538_spd*node_9538_ang);
                float2 node_9538_piv = float2(0.5,0.5);
                float2 node_9538 = (mul(i.uv0-node_9538_piv,float2x2( node_9538_cos, -node_9538_sin, node_9538_sin, node_9538_cos))+node_9538_piv);
                float2 node_7716 = (node_9538*2.0+-1.0).rg;
                clip((_Texture_var.a*(1.0 - saturate(round( 0.5*((atan2(node_7716.r,node_7716.g)*0.1592357+0.5) + _Cut))))) - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float node_102 = 1.0;
                float gloss = node_102;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float3 specularColor = float3(node_102,node_102,node_102);
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 diffuseColor = (_Color.rgb*_Texture_var.rgb);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _Color;
            uniform float _Cut;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                float node_9538_ang = 3.14;
                float node_9538_spd = 1.0;
                float node_9538_cos = cos(node_9538_spd*node_9538_ang);
                float node_9538_sin = sin(node_9538_spd*node_9538_ang);
                float2 node_9538_piv = float2(0.5,0.5);
                float2 node_9538 = (mul(i.uv0-node_9538_piv,float2x2( node_9538_cos, -node_9538_sin, node_9538_sin, node_9538_cos))+node_9538_piv);
                float2 node_7716 = (node_9538*2.0+-1.0).rg;
                clip((_Texture_var.a*(1.0 - saturate(round( 0.5*((atan2(node_7716.r,node_7716.g)*0.1592357+0.5) + _Cut))))) - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float node_102 = 1.0;
                float gloss = node_102;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float3 specularColor = float3(node_102,node_102,node_102);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 diffuseColor = (_Color.rgb*_Texture_var.rgb);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _Cut;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                float node_9538_ang = 3.14;
                float node_9538_spd = 1.0;
                float node_9538_cos = cos(node_9538_spd*node_9538_ang);
                float node_9538_sin = sin(node_9538_spd*node_9538_ang);
                float2 node_9538_piv = float2(0.5,0.5);
                float2 node_9538 = (mul(i.uv0-node_9538_piv,float2x2( node_9538_cos, -node_9538_sin, node_9538_sin, node_9538_cos))+node_9538_piv);
                float2 node_7716 = (node_9538*2.0+-1.0).rg;
                clip((_Texture_var.a*(1.0 - saturate(round( 0.5*((atan2(node_7716.r,node_7716.g)*0.1592357+0.5) + _Cut))))) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}

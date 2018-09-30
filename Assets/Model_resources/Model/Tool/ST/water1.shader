// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.32 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.32;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:9480,x:32719,y:32712,varname:node_9480,prsc:2|diff-6358-RGB,spec-3534-RGB,gloss-4507-OUT,amdfl-3552-RGB,amspl-3552-RGB,alpha-4066-OUT,refract-202-OUT;n:type:ShaderForge.SFN_Panner,id:2720,x:31025,y:33015,varname:node_2720,prsc:2,spu:1,spv:0|UVIN-5531-UVOUT,DIST-4307-OUT;n:type:ShaderForge.SFN_TexCoord,id:5531,x:30586,y:33016,varname:node_5531,prsc:2,uv:0;n:type:ShaderForge.SFN_Slider,id:1533,x:30429,y:33244,ptovrint:False,ptlb:Speed,ptin:_Speed,varname:node_1533,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:4307,x:30820,y:33145,varname:node_4307,prsc:2|A-1533-OUT,B-799-T;n:type:ShaderForge.SFN_Time,id:799,x:30953,y:33292,varname:node_799,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:3534,x:31270,y:33015,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_3534,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-2720-UVOUT;n:type:ShaderForge.SFN_Color,id:6358,x:31599,y:32473,ptovrint:False,ptlb:Color(Alpha),ptin:_ColorAlpha,varname:node_6358,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_AmbientLight,id:3552,x:32355,y:32875,varname:node_3552,prsc:2;n:type:ShaderForge.SFN_Slider,id:4507,x:32127,y:32575,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:node_4507,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_ComponentMask,id:5582,x:31627,y:33056,varname:node_5582,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-3534-RGB;n:type:ShaderForge.SFN_Multiply,id:2884,x:31885,y:33066,varname:node_2884,prsc:2|A-5582-OUT,B-3569-OUT;n:type:ShaderForge.SFN_Slider,id:3569,x:31450,y:33289,ptovrint:False,ptlb:Refraction,ptin:_Refraction,varname:node_3569,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Blend,id:8833,x:31617,y:32660,varname:node_8833,prsc:2,blmd:16,clmp:True|SRC-5531-U,DST-5076-OUT;n:type:ShaderForge.SFN_Slider,id:5076,x:31069,y:32769,ptovrint:False,ptlb:Cut,ptin:_Cut,varname:node_5076,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:4066,x:32017,y:32698,varname:node_4066,prsc:2|A-6358-A,B-4461-OUT;n:type:ShaderForge.SFN_Multiply,id:202,x:32279,y:32988,varname:node_202,prsc:2|A-4066-OUT,B-2884-OUT;n:type:ShaderForge.SFN_OneMinus,id:4461,x:31844,y:32773,varname:node_4461,prsc:2|IN-8833-OUT;proporder:1533-3534-6358-4507-3569-5076;pass:END;sub:END;*/

Shader "DSYZ/water1" {
    Properties {
        _Speed ("Speed", Range(-1, 1)) = 0
        _Noise ("Noise", 2D) = "white" {}
        _ColorAlpha ("Color(Alpha)", Color) = (0.5,0.5,0.5,1)
        _Gloss ("Gloss", Range(0, 1)) = 0
        _Refraction ("Refraction", Range(0, 1)) = 0
        _Cut ("Cut", Range(0, 1)) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        LOD 200
        GrabPass{ }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _GrabTexture;
            uniform float4 _TimeEditor;
            uniform float _Speed;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float4 _ColorAlpha;
            uniform float _Gloss;
            uniform float _Refraction;
            uniform float _Cut;
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
                float4 screenPos : TEXCOORD3;
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.screenPos = o.pos;
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.normalDir = normalize(i.normalDir);
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float node_4066 = (_ColorAlpha.a*(1.0 - saturate(round( 0.5*(i.uv0.r + _Cut)))));
                float4 node_799 = _Time + _TimeEditor;
                float2 node_2720 = (i.uv0+(_Speed*node_799.g)*float2(1,0));
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(node_2720, _Noise));
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + (node_4066*(_Noise_var.rgb.rg*_Refraction));
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = _Gloss;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float3 specularColor = _Noise_var.rgb;
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 indirectSpecular = (0 + UNITY_LIGHTMODEL_AMBIENT.rgb)*specularColor;
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Diffuse Ambient Light
                float3 diffuseColor = _ColorAlpha.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(lerp(sceneColor.rgb, finalColor,node_4066),1);
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
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _GrabTexture;
            uniform float4 _TimeEditor;
            uniform float _Speed;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float4 _ColorAlpha;
            uniform float _Gloss;
            uniform float _Refraction;
            uniform float _Cut;
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
                float4 screenPos : TEXCOORD3;
                LIGHTING_COORDS(4,5)
                UNITY_FOG_COORDS(6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.screenPos = o.pos;
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.normalDir = normalize(i.normalDir);
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float node_4066 = (_ColorAlpha.a*(1.0 - saturate(round( 0.5*(i.uv0.r + _Cut)))));
                float4 node_799 = _Time + _TimeEditor;
                float2 node_2720 = (i.uv0+(_Speed*node_799.g)*float2(1,0));
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(node_2720, _Noise));
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + (node_4066*(_Noise_var.rgb.rg*_Refraction));
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = _Gloss;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float3 specularColor = _Noise_var.rgb;
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 diffuseColor = _ColorAlpha.rgb;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * node_4066,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}

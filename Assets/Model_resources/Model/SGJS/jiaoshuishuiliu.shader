// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.32 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.32;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:False,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:663,x:33018,y:32712,varname:node_663,prsc:2|diff-3028-OUT,spec-9595-R,amdfl-2076-RGB,amspl-2076-RGB,alpha-4153-OUT,voffset-8381-OUT;n:type:ShaderForge.SFN_Color,id:7746,x:32029,y:32627,ptovrint:False,ptlb:Color(Alpha),ptin:_ColorAlpha,varname:node_7746,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Panner,id:436,x:31984,y:32979,varname:node_436,prsc:2,spu:1,spv:0|UVIN-3932-UVOUT,DIST-8138-OUT;n:type:ShaderForge.SFN_TexCoord,id:3932,x:31718,y:32959,varname:node_3932,prsc:2,uv:0;n:type:ShaderForge.SFN_Tex2d,id:9595,x:32176,y:33015,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_9595,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:cf596f92aa7f92842864f4989805a98e,ntxv:0,isnm:False|UVIN-436-UVOUT;n:type:ShaderForge.SFN_Slider,id:4876,x:31487,y:33243,ptovrint:False,ptlb:Speed,ptin:_Speed,varname:node_4876,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0.2104769,max:1;n:type:ShaderForge.SFN_Multiply,id:8138,x:31827,y:33158,varname:node_8138,prsc:2|A-4010-T,B-4876-OUT;n:type:ShaderForge.SFN_Time,id:4010,x:31560,y:33081,varname:node_4010,prsc:2;n:type:ShaderForge.SFN_Add,id:5831,x:32384,y:33032,varname:node_5831,prsc:2|A-9595-R,B-9595-G;n:type:ShaderForge.SFN_Multiply,id:7963,x:32543,y:33125,varname:node_7963,prsc:2|A-5831-OUT,B-9115-OUT;n:type:ShaderForge.SFN_NormalVector,id:9115,x:32284,y:33215,prsc:2,pt:False;n:type:ShaderForge.SFN_Multiply,id:8381,x:32724,y:33245,varname:node_8381,prsc:2|A-7963-OUT,B-8452-OUT;n:type:ShaderForge.SFN_Slider,id:8452,x:32333,y:33405,ptovrint:False,ptlb:Power,ptin:_Power,varname:node_8452,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1048135,max:1;n:type:ShaderForge.SFN_Cubemap,id:2076,x:32658,y:32907,ptovrint:False,ptlb:node_2076,ptin:_node_2076,varname:node_2076,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,cube:1acba49c153511a46ae5ace8f5e44ee9,pvfc:0;n:type:ShaderForge.SFN_Multiply,id:3028,x:32458,y:32714,varname:node_3028,prsc:2|A-7746-RGB,B-9595-R;n:type:ShaderForge.SFN_Blend,id:7560,x:31761,y:32786,varname:node_7560,prsc:2,blmd:16,clmp:True|SRC-3932-U,DST-5950-OUT;n:type:ShaderForge.SFN_Slider,id:5950,x:31318,y:32808,ptovrint:False,ptlb:node_5950,ptin:_node_5950,varname:node_5950,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:4153,x:32240,y:32772,varname:node_4153,prsc:2|A-7746-A,B-511-OUT;n:type:ShaderForge.SFN_OneMinus,id:511,x:31993,y:32780,varname:node_511,prsc:2|IN-7560-OUT;proporder:7746-9595-4876-8452-2076-5950;pass:END;sub:END;*/

Shader "DSYZ/jiaoshuishuiliu" {
    Properties {
        _ColorAlpha ("Color(Alpha)", Color) = (0.5,0.5,0.5,1)
        _Texture ("Texture", 2D) = "white" {}
        _Speed ("Speed", Range(-1, 1)) = 0.2104769
        _Power ("Power", Range(0, 1)) = 0.1048135
        _node_2076 ("node_2076", Cube) = "_Skybox" {}
        _node_5950 ("node_5950", Range(0, 1)) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            
            
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
            uniform float4 _TimeEditor;
            uniform float4 _ColorAlpha;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float _Speed;
            uniform float _Power;
            uniform samplerCUBE _node_2076;
            uniform float _node_5950;
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
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_4010 = _Time + _TimeEditor;
                float2 node_436 = (o.uv0+(node_4010.g*_Speed)*float2(1,0));
                float4 _Texture_var = tex2Dlod(_Texture,float4(TRANSFORM_TEX(node_436, _Texture),0.0,0));
                v.vertex.xyz += (((_Texture_var.r+_Texture_var.g)*v.normal)*_Power);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float4 _node_2076_var = texCUBE(_node_2076,viewReflectDirection);
                float4 node_4010 = _Time + _TimeEditor;
                float2 node_436 = (i.uv0+(node_4010.g*_Speed)*float2(1,0));
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(node_436, _Texture));
                float3 specularColor = float3(_Texture_var.r,_Texture_var.r,_Texture_var.r);
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 indirectSpecular = (0 + _node_2076_var.rgb)*specularColor;
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                indirectDiffuse += _node_2076_var.rgb; // Diffuse Ambient Light
                float3 diffuseColor = (_ColorAlpha.rgb*_Texture_var.r);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor,(_ColorAlpha.a*(1.0 - saturate(round( 0.5*(i.uv0.r + _node_5950))))));
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
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float4 _ColorAlpha;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float _Speed;
            uniform float _Power;
            uniform float _node_5950;
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
                float4 node_4010 = _Time + _TimeEditor;
                float2 node_436 = (o.uv0+(node_4010.g*_Speed)*float2(1,0));
                float4 _Texture_var = tex2Dlod(_Texture,float4(TRANSFORM_TEX(node_436, _Texture),0.0,0));
                v.vertex.xyz += (((_Texture_var.r+_Texture_var.g)*v.normal)*_Power);
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
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float4 node_4010 = _Time + _TimeEditor;
                float2 node_436 = (i.uv0+(node_4010.g*_Speed)*float2(1,0));
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(node_436, _Texture));
                float3 specularColor = float3(_Texture_var.r,_Texture_var.r,_Texture_var.r);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 diffuseColor = (_ColorAlpha.rgb*_Texture_var.r);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * (_ColorAlpha.a*(1.0 - saturate(round( 0.5*(i.uv0.r + _node_5950))))),0);
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
            uniform float4 _TimeEditor;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float _Speed;
            uniform float _Power;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_4010 = _Time + _TimeEditor;
                float2 node_436 = (o.uv0+(node_4010.g*_Speed)*float2(1,0));
                float4 _Texture_var = tex2Dlod(_Texture,float4(TRANSFORM_TEX(node_436, _Texture),0.0,0));
                v.vertex.xyz += (((_Texture_var.r+_Texture_var.g)*v.normal)*_Power);
                o.pos = UnityObjectToClipPos(v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}

// Compiled shader for PC, Mac & Linux Standalone

//////////////////////////////////////////////////////////////////////////
// 
// NOTE: This is *not* a valid shader file, the contents are provided just
// for information and for debugging purposes only.
// 
//////////////////////////////////////////////////////////////////////////
// Skipping shader variants that would not be included into build of current scene.

Shader "GUI/ReverseFont" {
Properties {
 _MainTex ("Font Texture", 2D) = "white" { }
 _Color ("Text Color", Color) = (1.000000,1.000000,1.000000,1.000000)
}
SubShader { 
 Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
 Pass {
  Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
  ZWrite Off
  Cull Off
  Blend SrcColor DstColor
 BlendOp Sub
  //////////////////////////////////
  //                              //
  //      Compiled programs       //
  //                              //
  //////////////////////////////////
//////////////////////////////////////////////////////
No keywords set in this variant.
-- Vertex shader for "metal":
Uses vertex data channel "Vertex"
Uses vertex data channel "TexCoord"

Constant Buffer "Globals" (96 bytes) on slot 0 {
  Matrix4x4 glstate_matrix_mvp at 0
  VectorHalf4 _Color at 64
  Vector4 _MainTex_ST at 80
}

Shader Disassembly:
#include <metal_stdlib>
#include <metal_texture>
using namespace metal;
struct Globals_Type
{
    float4 hlslcc_mtx4x4glstate_matrix_mvp[4];
    half4 _Color;
    float4 _MainTex_ST;
};

struct Mtl_VertexIn
{
    float3 POSITION0 [[ attribute(0) ]] ;
    float3 TEXCOORD0 [[ attribute(1) ]] ;
};

struct Mtl_VertexOut
{
    half4 COLOR0 [[ user(COLOR0) ]];
    float2 TEXCOORD0 [[ user(TEXCOORD0) ]];
    float4 mtl_Position [[ position ]];
};

vertex Mtl_VertexOut xlatMtlMain(
    constant Globals_Type& Globals [[ buffer(0) ]],
    Mtl_VertexIn input [[ stage_in ]])
{
    Mtl_VertexOut output;
    float4 u_xlat0;
    half4 u_xlat16_0;
    u_xlat16_0 = Globals._Color;
    u_xlat16_0 = clamp(u_xlat16_0, 0.0h, 1.0h);
    output.COLOR0 = u_xlat16_0;
    output.TEXCOORD0.xy = input.TEXCOORD0.xy * Globals._MainTex_ST.xy + Globals._MainTex_ST.zw;
    u_xlat0 = input.POSITION0.yyyy * Globals.hlslcc_mtx4x4glstate_matrix_mvp[1];
    u_xlat0 = Globals.hlslcc_mtx4x4glstate_matrix_mvp[0] * input.POSITION0.xxxx + u_xlat0;
    u_xlat0 = Globals.hlslcc_mtx4x4glstate_matrix_mvp[2] * input.POSITION0.zzzz + u_xlat0;
    output.mtl_Position = u_xlat0 + Globals.hlslcc_mtx4x4glstate_matrix_mvp[3];
    return output;
}


-- Fragment shader for "metal":
Set 2D Texture "_MainTex" to slot 0

Shader Disassembly:
#include <metal_stdlib>
#include <metal_texture>
using namespace metal;
struct Mtl_FragmentIn
{
    half4 COLOR0 [[ user(COLOR0) ]] ;
    float2 TEXCOORD0 [[ user(TEXCOORD0) ]] ;
};

struct Mtl_FragmentOut
{
    half4 SV_Target0 [[ color(0) ]];
};

fragment Mtl_FragmentOut xlatMtlMain(
    texture2d<half, access::sample > _MainTex [[ texture (0) ]] ,
    sampler sampler_MainTex [[ sampler (0) ]] ,
    Mtl_FragmentIn input [[ stage_in ]])
{
    Mtl_FragmentOut output;
    half u_xlat16_0;
    bool u_xlatb0;
    half u_xlat16_1;
    u_xlat16_0 = _MainTex.sample(sampler_MainTex, input.TEXCOORD0.xy).w;
    u_xlat16_1 = half(u_xlat16_0 * input.COLOR0.w);
    u_xlatb0 = 0.5>=float(u_xlat16_1);
    output.SV_Target0.w = u_xlat16_1;
    if((int(u_xlatb0) * int(0xffffffffu))!=0){discard_fragment();}
    output.SV_Target0.xyz = input.COLOR0.xyz;
    return output;
}


-- Vertex shader for "glcore":
Shader Disassembly:
#ifdef VERTEX
#version 150
#extension GL_ARB_explicit_attrib_location : require
#extension GL_ARB_shader_bit_encoding : enable

uniform 	vec4 hlslcc_mtx4x4glstate_matrix_mvp[4];
uniform 	vec4 _Color;
uniform 	vec4 _MainTex_ST;
in  vec3 in_POSITION0;
in  vec3 in_TEXCOORD0;
out vec4 vs_COLOR0;
out vec2 vs_TEXCOORD0;
vec4 u_xlat0;
void main()
{
    vs_COLOR0 = _Color;
    vs_COLOR0 = clamp(vs_COLOR0, 0.0, 1.0);
    vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4glstate_matrix_mvp[1];
    u_xlat0 = hlslcc_mtx4x4glstate_matrix_mvp[0] * in_POSITION0.xxxx + u_xlat0;
    u_xlat0 = hlslcc_mtx4x4glstate_matrix_mvp[2] * in_POSITION0.zzzz + u_xlat0;
    gl_Position = u_xlat0 + hlslcc_mtx4x4glstate_matrix_mvp[3];
    return;
}

#endif
#ifdef FRAGMENT
#version 150
#extension GL_ARB_explicit_attrib_location : require
#extension GL_ARB_shader_bit_encoding : enable

uniform  sampler2D _MainTex;
in  vec4 vs_COLOR0;
in  vec2 vs_TEXCOORD0;
layout(location = 0) out vec4 SV_Target0;
float u_xlat0;
lowp vec4 u_xlat10_0;
bool u_xlatb1;
void main()
{
    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
    u_xlat0 = u_xlat10_0.w * vs_COLOR0.w;
    u_xlatb1 = 0.5>=u_xlat0;
    SV_Target0.w = u_xlat0;
    if((int(u_xlatb1) * int(0xffffffffu))!=0){discard;}
    SV_Target0.xyz = vs_COLOR0.xyz;
    return;
}

#endif


-- Fragment shader for "glcore":
Shader Disassembly:
// All GLSL source is contained within the vertex program

 }
}
}
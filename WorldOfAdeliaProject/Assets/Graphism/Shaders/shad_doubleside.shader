  Shader "Adelia/Basique_DoubleSidded"
  {
    Properties
    {
      _MainTex ("Diffuse Map", 2D) = "white" {}
      _BumpMap ("Normal Map", 2D) = "bump" {}
      _EmissionMap ("Emission Map", 2D) = "white" {}
      _EmitPower ("Emit Power", Range(0.0,1.0)) = 0
      _Transparency ("Emit Power", Range(0.0,1.0)) = 0
      _RimColor ("Rim Color", Color) = (0.10,0.26,0.35,0.0)
      _RimPower ("Rim Power", Range(0.5,8.0)) = 3.0
      _Color ("Color (RGBA)", Color) = (1, 1, 1, 1) // add _Color property
    }
    SubShader
    {
      Cull off
      //Pass
      //{
      //  ColorMaterial AmbientAndDiffuse
      //}



      Tags { "RenderType" = "Opaque" "Queue" = "Geometry" }
      
      CGPROGRAM
      #pragma surface surf Lambert


      struct Input
      {
        float2 uv_MainTex;
        float2 uv_BumpMap;
        float3 viewDir;
      };
      fixed3 _Color;
      sampler2D _MainTex;
      sampler2D _BumpMap;
      sampler2D _EmissionMap;
      float4 _RimColor;
      float _RimPower;
      float _EmitPower;


      void surf (Input IN, inout SurfaceOutput o)
      {
        half4 c = tex2D(_MainTex, IN.uv_MainTex);
        o.Albedo = c.rgb * _Color;

        o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap));
        half rim = 1.0 - saturate(dot (normalize(IN.viewDir), o.Normal));
        o.Emission = (_RimColor.rgb * pow (rim, _RimPower)) + ((tex2D (_EmissionMap, IN.uv_MainTex).rgb) * _EmitPower);
        //o.Alpha = c.a;

      }
      ENDCG
    } 
    Fallback "Diffuse"
    
  }
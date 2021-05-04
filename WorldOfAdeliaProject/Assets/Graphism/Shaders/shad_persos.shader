  Shader "Adelia/Persos" {
    Properties {
      _MainTex ("Diffuse Map", 2D) = "white" {}
      _Color ("Couleur du joueur", Color) = (1, 1, 1, 1)
      _ColoMap ("Mask Colo", 2D) = "white" {}
      _RimColor ("Rim Color", Color) = (0.10,0.26,0.35,0.0)
      _RimPower ("Rim Power", Range(0.5,8.0)) = 3.0



    }
    SubShader {
      Blend SrcAlpha OneMinusSrcAlpha
      Cull off
      Pass {
             ColorMaterial AmbientAndDiffuse
      }



      Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
      CGPROGRAM
      #pragma surface surf Lambert
      struct Input {
        float2 uv_MainTex;
        float2 uv_ColoMap;
        float3 viewDir;
      };
      sampler2D _MainTex;
      sampler2D _ColoMap;
      float4 _RimColor;
      float _RimPower;
      float3 _Color;









      void surf (Input IN, inout SurfaceOutput o) {
        o.Alpha = tex2D (_MainTex, IN.uv_MainTex).a;
        o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb * ( (1-tex2D (_ColoMap, IN.uv_ColoMap).rgb) + (tex2D (_ColoMap, IN.uv_ColoMap).rgb * _Color));
        half rim = 1.0 - saturate(dot (normalize(IN.viewDir), o.Normal));
        o.Emission = _RimColor.rgb * pow (rim, _RimPower);
	
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }
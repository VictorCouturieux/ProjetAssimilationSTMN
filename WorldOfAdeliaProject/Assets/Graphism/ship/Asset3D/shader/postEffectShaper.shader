Shader "Custom/postEffectShape"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
        _TintColor("Tint Color", Color) = (1,1,1,1)
        _Transparency("Transparency", Range(0.0, 1.0)) = 0.5
    }
    SubShader
    {
        // No culling or depth
//        Cull Off ZWrite Off ZTest Always
        Tags{"Queue"="Transparent" "RenderType"="Transparent"}
        LOD 100
        
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

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
            };

            sampler2D _MainTex;
            float4 _MainTex_SI;
            float4 TintColor;
            float _Transparency;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f IN) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, IN.uv + float2(0, sin(IN.vertex.x/50 + _Time[1])/10) );
                  fixed4 col = tex2D(_MainTex, IN.uv);
                
                // just invert the colors
//                col.rgb = 1 - col.rgb;
//                col.r = 1;
//                col.a = _Transparency;
                
                return col;
            }
            ENDCG
        }
    }
}

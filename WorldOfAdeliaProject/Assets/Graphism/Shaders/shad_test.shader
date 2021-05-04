 Shader "Adelia/Test"
 {
     Properties
     {
         _MainTex("Base (RGB)", 2D) = "white" {}
         _RimValue("Rim value", Range(0, 1)) = 0.5
         _Color("Color", Color) = (1, 1, 1, 1)
     }
    SubShader {
            Pass
            {
                Tags
                {
                    "Queue" = "Transparent"
                    "IgnoreProjector" = "True"
                    "RenderType" = "Transparent"
                    "PreviewType" = "Plane"
                    "CanUseSpriteAtlas" = "True"
                }
     
                Cull Off
                Lighting Off
                ZWrite Off
                Blend One OneMinusSrcAlpha
                ColorMask A
     
                CGPROGRAM
                #pragma vertex SpriteVert
                #pragma fragment frag
                #pragma target 2.0
                #include "UnitySprites.cginc"
     
                fixed4 frag(v2f IN) : SV_Target
                {
                    fixed4 c = SampleSpriteTexture(IN.texcoord);
                    return c;
                }
                ENDCG
               
            }
           
            Tags {
                "RenderType"="Transparent"
                "Queue" = "Transparent"
            }
            LOD 200
           
            Blend One OneMinusSrcAlpha
            ZWrite Off
            Cull Off
            ColorMask RGB
     
            CGPROGRAM
            // Physically based Standard lighting model, and enable shadows on all light types
            #pragma surface surf Standard fullforwardshadows alpha:fade alpha:auto  //vertex:vert
    }
 }
     

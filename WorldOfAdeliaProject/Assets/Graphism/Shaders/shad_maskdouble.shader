        Shader "Adelia/maskdouble" {
    Properties {
        _Color ("Diffuse Map", Color) = (1,1,1,1)
        _MainTex ("Base color", 2D) = "white" {}
        _Illumi ("Base color", Color) = (1,1,1,1)
    }
     
    SubShader {
        Tags {"RenderType"="Opaque" "Queue"="Transparent"}
        LOD 100
        // Render into depth buffer only
        Pass {
            ZWrite On
            Blend SrcAlpha OneMinusSrcAlpha
            ColorMask RGB
            Cull off
            Material {
                Diffuse [_Color]
                Ambient [_Color]
                Emission [_Illumi]
            }
            Lighting On
            SetTexture [_MainTex] {
                Combine texture * primary DOUBLE, texture * primary
            }
            
        }
     
    }
    }


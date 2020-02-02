Shader "Unlit/FlatUnlitShader"
{
    Properties
    {
        //_MainTex ("Texture", 2D) = "white" {}
        _DiffuseColor("Diffuse Color", Color) =  (1.0, 1.0, 1.0, 1.0)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 worldPos : TEXCOORD0;
            };

            //sampler2D _MainTex;
            //float4 _MainTex_ST;
            uniform float4 _DiffuseColor;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                // Directly passing model vertex pos
                //o.worldPos = v.vertex.xyz;
                
                // Passing transformed vertex
                o.worldPos =mul(unity_ObjectToWorld, v.vertex).xyz;


                return o;
            }

            float4 frag (v2f i) : SV_Target
            {
                static const float3 pointLight = float3(10, 10, -10);
                const float3 lightDir = normalize(pointLight - i.vertex);
                const float3 flatNormal = -normalize(cross(ddx(i.worldPos), -ddy(i.worldPos)));
                const float lightIntensity = pow((1.5 + 0.5 * dot(flatNormal, lightDir)) * 0.5, 2.0);
                
                float4 col = float4(lightIntensity.xxx * _DiffuseColor.xyz, 1.0);
                
                return col;
            }
            ENDCG
        }
    }
}

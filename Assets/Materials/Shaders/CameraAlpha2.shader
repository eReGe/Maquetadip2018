Shader "Custom/AlphaBlendText"
{
    Properties
    {
        _MainTex("Main Texture", 2D) = "white" {}
        _Alpha("Mask", 2D) = "white" {}
 
    }
   
    SubShader
    {
        Tags{ "RenderType" = "Transparent" "Queue" = "Transparent" }
 
        ZWrite Off
        Cull Off
 
        //Blend SrcAlpha OneMinusSrcAlpha
        Blend SrcColor OneMinusSrcColor
       
        ColorMask RGB
 
        Pass
        {
            SetTexture[_MainTex]
            {
                Combine texture
            }
           
            SetTexture[_Alpha]
            {
                Combine previous * texture
            }
        }
    }
}
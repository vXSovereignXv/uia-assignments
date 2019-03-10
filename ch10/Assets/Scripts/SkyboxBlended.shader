Shader "Skybox/Blended" {
	Properties{
		_Tint("Tint Color", Color) = (.5, .5, .5, .5)
		_Blend("Blend", Range(0.0,1.0)) = 0.5
		_CubeTex("Cubemap", CUBE) = "white" {}
		_CubeTex2("Cubemap", CUBE) = "white" {}
	}

		SubShader{
			Tags { "Queue" = "Background" }
			Cull Off
			Fog { Mode Off }
			Lighting Off
			Color[_Tint]
			Pass {
				SetTexture[_CubeTex] { combine texture }
				SetTexture[_CubeTex2] { constantColor(0,0,0,[_Blend]) combine texture lerp(constant) previous }
			}
	}

	Fallback "Skybox/Cubemap", 1
}
Shader "OpenGL/MineCraft"{
	Properties{
	_Color("Ambient Color", Color) = (1.0,1.0,1.0,1.0)
	_MainTex("Diffuse Texture", 2D) = "white" {}
	}
	SubShader{
		Tags{"Quene" = "Geometry"}
	
		Pass{
			GLSLPROGRAM
			
			uniform vec4 _Color;
			uniform sampler2D _MainTex;
			uniform vec4 _MainTex_ST;
			uniform vec4 _Time;
			uniform vec4 _SinTime;
			uniform vec4 _CosTime;
			uniform mat4 _World2Object;
			uniform mat4 _Object2World;
			
			varying vec3 vertexPostion;
			varying vec4 vertexColor;
			varying vec4 vertexData;
			varying vec2 uv;
			
			
			#ifdef VERTEX
			
			void main(){
				vertexColor = _Color;
				uv = gl_MultiTexCoord0;
				
				vertexData = gl_Vertex;
				
				vertexData.y += (_SinTime.z / ((-vertexData.z * -vertexData.x) * 60.0)) * clamp(vertexData.y, 0.0, 1.0);
				vertexData.x += (_SinTime.y / 4.0) * clamp(vertexData.y, 0.0, 1.0);
				vertexData.z += (_SinTime.x / 4.0) * clamp(vertexData.y, 0.0, 1.0);
				
				gl_Position = gl_ModelViewProjectionMatrix * vertexData;
			}
			
			#endif
			
			#ifdef FRAGMENT
			
			void main(){
				gl_FragColor = texture2D(_MainTex, uv);
			}
			
			#endif
			
			ENDGLSL
		}
	}
	
}
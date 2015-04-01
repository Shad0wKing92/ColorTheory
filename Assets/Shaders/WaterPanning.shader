Shader "OpenGL/Panning"{
	Properties{
	_Color("Smbient Color", Color) = (1.0,1.0,1.0,1.0)
	_MainTex("Diffuse Texture", 2D) = "white" {}
	}
	SubShader{
		Pass{
			GLSLPROGRAM
			
			uniform vec4 _Time;
			uniform vec4 _Color;
			uniform sampler2D _MainTex;
			uniform vec4 _MainTex_ST;
			
			varying vec4 texCoords;
			
			
			#ifdef VERTEX
			
			void main(){
				texCoords = gl_MultiTexCoord0;
				texCoords += fract(_Time.x);
				gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;
			}
			
			#endif
			
			#ifdef FRAGMENT
			
			void main(){
				gl_FragColor = texture2D(_MainTex, _MainTex_ST.xy * texCoords.xy + _MainTex_ST.zw);
			}
			
			#endif
			
			ENDGLSL
		}
	}
	
}
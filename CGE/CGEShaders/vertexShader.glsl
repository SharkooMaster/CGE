
#version 330 core //Using version GLSL version 3.3
layout (location = 0) in vec3 vPos;
layout (location = 1) in vec4 vCol;

out vec4 outCol;

void main()
{
	outCol = vCol;
	gl_Position = vec4(vPos.x, vPos.y, vPos.z, 1.0);
}
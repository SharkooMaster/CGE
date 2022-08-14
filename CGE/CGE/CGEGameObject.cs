using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CGE.CGEMath;
using CGE.CGEMVC;

namespace CGE.CGE
{
    internal class CGEGameObject : CGEModel
    {
        //CGEMatrix3 Matrix = new CGEMatrix3();
        public List<float> Vertices   = new List<float>();
        public List<float> ColorArr   = new List<float>();
        public List<uint>  IndexArray = new List<uint>();

        public CGEVector3 Position = new CGEVector3(0, 0, 0);
        public CGEVector3 Rotation = new CGEVector3(0, 0, 0);
        public CGEQuaternion Quaternion;
        public CGEVector3 Scale = new CGEVector3(1, 1, 1);

        public string VertexShaderSource;
        public string FragmentShaderSource;

        public string VertexShader;
        public string FragmentShader;

        public CGEGameObject
            (List<float> vertices, List<float> colorArr, List<uint> indexArray, CGEVector3 rotation, CGEVector3 scale, CGEVector3 position,
             string vertexShaderSource = @"\..\..\..\CGEShaders\vertexShader.glsl", string fragmentShaderSource = @"\..\..\..\CGEShaders\fragmentShader.glsl")
        {
            Vertices   = vertices;
            ColorArr   = colorArr;
            IndexArray = indexArray;

            Position = position;
            Rotation = rotation;
            Quaternion = new CGEQuaternion(0, Rotation);
            Scale = scale;

            VertexShaderSource = @$"{Directory.GetCurrentDirectory()}{vertexShaderSource}";
            FragmentShaderSource = @$"{Directory.GetCurrentDirectory()}{fragmentShaderSource}";

            VertexShader   = CGEIO.FileToString(VertexShaderSource);
            FragmentShader = CGEIO.FileToString(FragmentShaderSource);
        }
    }
}

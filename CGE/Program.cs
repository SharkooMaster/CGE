using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.Windowing;

using CGE.CGEThreading;
using CGE.CGEMath;
using CGE.CGE;

namespace CGE
{
    public static class Program
    {
        public static void Main()
        {
            CGEWindow window = new CGEWindow("CGE");


            CGEMatrix3 vertices_matrix = new CGEMatrix3
            (
                -0.5f, -0.5f, 0.0f,
                +0.5f, -0.5f, 0.0f,
                 0.0f, +0.5f, 0.0f
            );
            vertices_matrix = vertices_matrix.Transpose();

            float[] vertexArr = vertices_matrix.matrixData;

            float[] colorArr = new float[]
            {
                1.0f,0.0f,0.0f,1.0f,
                0.0f,0.0f,1.0f,1.0f,
                0.0f,1.0f,0.0f,1.0f
            };

            uint[] indexArray = new uint[] { 0, 1, 2 };

            CGEGameObject go_1 = new CGEGameObject
                (vertexArr.ToList(), colorArr.ToList(), indexArray.ToList(), new CGEVector3(), new CGEVector3(1.0f, 1.0f, 1.0f), new CGEVector3());
            window.gameObjects.Add(go_1);

            window.Run();
        }
    }
}

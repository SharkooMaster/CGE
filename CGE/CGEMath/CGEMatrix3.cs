using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGE.CGEMath
{
    internal class CGEMatrix3
    {
        public float[] matrixData = new float[9];

        public CGEMatrix3
        (float m0 = 0.0f, float m3 = 0.0f, float m6 = 0.0f,
         float m1 = 0.0f, float m4 = 0.0f, float m7 = 0.0f,
         float m2 = 0.0f, float m5 = 0.0f, float m8 = 0.0f)
        {
            matrixData[0] = m0;
            matrixData[3] = m3;
            matrixData[6] = m6;

            matrixData[1] = m1;
            matrixData[4] = m4;
            matrixData[7] = m7;

            matrixData[2] = m2;
            matrixData[5] = m5;
            matrixData[8] = m8;
        }

        public override string ToString()
        {
            return $"[{matrixData[0]} , {matrixData[3]} , {matrixData[6]}\n {matrixData[1]} , {matrixData[4]} , {matrixData[7]}\n {matrixData[2]} , {matrixData[5]} , {matrixData[8]}]";
        }

        // Addition
        public static CGEMatrix3 operator +(CGEMatrix3 lhs, CGEMatrix3 rhs)
        {
            CGEMatrix3 result = new CGEMatrix3();
            result.matrixData[0] = lhs.matrixData[0] + rhs.matrixData[0];
            result.matrixData[3] = lhs.matrixData[3] + rhs.matrixData[3];
            result.matrixData[6] = lhs.matrixData[6] + rhs.matrixData[6];

            result.matrixData[1] = lhs.matrixData[1] + rhs.matrixData[1];
            result.matrixData[4] = lhs.matrixData[4] + rhs.matrixData[4];
            result.matrixData[7] = lhs.matrixData[7] + rhs.matrixData[7];

            result.matrixData[2] = lhs.matrixData[2] + rhs.matrixData[2];
            result.matrixData[5] = lhs.matrixData[5] + rhs.matrixData[5];
            result.matrixData[8] = lhs.matrixData[8] + rhs.matrixData[8];

            return result;
        }

        // Subtraction
        public static CGEMatrix3 operator -(CGEMatrix3 lhs, CGEMatrix3 rhs)
        {
            CGEMatrix3 result = new CGEMatrix3();
            result.matrixData[0] = lhs.matrixData[0] - rhs.matrixData[0];
            result.matrixData[3] = lhs.matrixData[3] - rhs.matrixData[3];
            result.matrixData[6] = lhs.matrixData[6] - rhs.matrixData[6];

            result.matrixData[1] = lhs.matrixData[1] - rhs.matrixData[1];
            result.matrixData[4] = lhs.matrixData[4] - rhs.matrixData[4];
            result.matrixData[7] = lhs.matrixData[7] - rhs.matrixData[7];

            result.matrixData[2] = lhs.matrixData[2] - rhs.matrixData[2];
            result.matrixData[5] = lhs.matrixData[5] - rhs.matrixData[5];
            result.matrixData[8] = lhs.matrixData[8] - rhs.matrixData[8];

            return result;
        }

        // Scalar Multiplication
        public static CGEMatrix3 operator *(CGEMatrix3 mat1, float c)
        {
            CGEMatrix3 result = new CGEMatrix3();
            result.matrixData[0] = mat1.matrixData[0] * c;
            result.matrixData[3] = mat1.matrixData[3] * c;
            result.matrixData[6] = mat1.matrixData[6] * c;

            result.matrixData[1] = mat1.matrixData[1] * c;
            result.matrixData[4] = mat1.matrixData[4] * c;
            result.matrixData[7] = mat1.matrixData[7] * c;

            result.matrixData[2] = mat1.matrixData[2] * c;
            result.matrixData[5] = mat1.matrixData[5] * c;
            result.matrixData[8] = mat1.matrixData[8] * c;

            return result;
        }

        // Multiplication
        public static CGEMatrix3 operator *(CGEMatrix3 mat1, CGEMatrix3 mat2)
        {
            CGEMatrix3 result = new CGEMatrix3();

            result.matrixData[0] = mat1.matrixData[0] * mat2.matrixData[0] + mat1.matrixData[3] * mat2.matrixData[1] + mat1.matrixData[6] * mat2.matrixData[2];
            result.matrixData[3] = mat1.matrixData[0] * mat2.matrixData[3] + mat1.matrixData[3] * mat2.matrixData[4] + mat1.matrixData[6] * mat2.matrixData[5];
            result.matrixData[6] = mat1.matrixData[0] * mat2.matrixData[6] + mat1.matrixData[3] * mat2.matrixData[7] + mat1.matrixData[6] * mat2.matrixData[8];

            result.matrixData[1] = mat1.matrixData[1] * mat2.matrixData[0] + mat1.matrixData[4] * mat2.matrixData[1] + mat1.matrixData[7] * mat2.matrixData[2];
            result.matrixData[4] = mat1.matrixData[1] * mat2.matrixData[3] + mat1.matrixData[4] * mat2.matrixData[4] + mat1.matrixData[7] * mat2.matrixData[5];
            result.matrixData[7] = mat1.matrixData[1] * mat2.matrixData[6] + mat1.matrixData[4] * mat2.matrixData[7] + mat1.matrixData[7] * mat2.matrixData[8];

            result.matrixData[2] = mat1.matrixData[2] * mat2.matrixData[0] + mat1.matrixData[5] * mat2.matrixData[1] + mat1.matrixData[8] * mat2.matrixData[2];
            result.matrixData[5] = mat1.matrixData[2] * mat2.matrixData[3] + mat1.matrixData[5] * mat2.matrixData[4] + mat1.matrixData[8] * mat2.matrixData[5];
            result.matrixData[8] = mat1.matrixData[2] * mat2.matrixData[6] + mat1.matrixData[5] * mat2.matrixData[7] + mat1.matrixData[8] * mat2.matrixData[8];

            return result;
        }
        public CGEMatrix3 Multiply(CGEMatrix3 mat1)
        {
            CGEMatrix3 temp = this;
            temp *= mat1;
            return temp;
        }

        // Identity Matrix
        public void setIdentityMatrix()
        {
            for (int i = 0; i < 9; i++)
            {
                matrixData[i] = 0.0f;
            }

            matrixData[0] = matrixData[4] = matrixData[8] = 1.0f;
        }

        // Inverse
        public void setInverseOfMatrix(CGEMatrix3 mat)
        {
            float t1 = mat.matrixData[0] * mat.matrixData[4];
            float t2 = mat.matrixData[0] * mat.matrixData[7];
            float t3 = mat.matrixData[3] * mat.matrixData[1];
            float t4 = mat.matrixData[6] * mat.matrixData[1];
            float t5 = mat.matrixData[3] * mat.matrixData[2];
            float t6 = mat.matrixData[6] * mat.matrixData[2];

            float det = (t1 * mat.matrixData[8] - t2 * mat.matrixData[5] - t3 * mat.matrixData[8] + t4 * mat.matrixData[5] + t5 * mat.matrixData[7] - t6 * mat.matrixData[4]);
            
            if (det == 0.0) return;

            float invd = 1.0f / det;

            float m0 = (mat.matrixData[4] * mat.matrixData[8] - mat.matrixData[7] * mat.matrixData[5]) * invd;
            float m3 = -(mat.matrixData[3] * mat.matrixData[8] - mat.matrixData[6] * mat.matrixData[5]) * invd;
            float m6 = (mat.matrixData[3] * mat.matrixData[7] - mat.matrixData[6] * mat.matrixData[4]) * invd;

            float m1 = -(mat.matrixData[1] * mat.matrixData[8] - mat.matrixData[7] * mat.matrixData[2]) * invd;
            float m4 = (mat.matrixData[0] * mat.matrixData[8] - t6) * invd;
            float m7 = -(t2 - t4) * invd;

            float m2 = (mat.matrixData[1] * mat.matrixData[5] - mat.matrixData[4] * mat.matrixData[2]) * invd;
            float m5 = -(mat.matrixData[0] * mat.matrixData[5] - t5) * invd;
            float m8 = (t1 - t3) * invd;

            matrixData[0] = m0;
            matrixData[3] = m3;
            matrixData[6] = m6;

            matrixData[1] = m1;
            matrixData[4] = m4;
            matrixData[7] = m7;

            matrixData[2] = m2;
            matrixData[5] = m5;
            matrixData[8] = m8;
        }
        public CGEMatrix3 Inverse()
        {
            CGEMatrix3 result = new CGEMatrix3();
            result.setInverseOfMatrix(this);
            return result;
        }

        // Transpose
        public void setTransposeOfMatrix(CGEMatrix3 mat)
        {
            matrixData[0] = mat.matrixData[0];
            matrixData[3] = mat.matrixData[1];
            matrixData[6] = mat.matrixData[2];

            matrixData[1] = mat.matrixData[3];
            matrixData[4] = mat.matrixData[4];
            matrixData[7] = mat.matrixData[5];

            matrixData[2] = mat.matrixData[6];
            matrixData[5] = mat.matrixData[7];
            matrixData[8] = mat.matrixData[8];
        }
        public CGEMatrix3 Transpose()
        {
            CGEMatrix3 result = new CGEMatrix3();
            result.setTransposeOfMatrix(this);
            return result;
        }

        // Vector Transformation
        public static CGEVector3 operator *(CGEMatrix3 mat ,CGEVector3 vec)
        {
            CGEVector3 result = new CGEVector3();
            result.x = mat.matrixData[0] * vec.x + mat.matrixData[3] * vec.y + mat.matrixData[6] * vec.z;
            result.y = mat.matrixData[1] * vec.y + mat.matrixData[4] * vec.y + mat.matrixData[7] * vec.z;
            result.z = mat.matrixData[2] * vec.y + mat.matrixData[5] * vec.y + mat.matrixData[8] * vec.z;
            return result;
        }
        public CGEVector3 transformVectorByMatrix(CGEVector3 vec) { return this * vec; }

        // Macros
        public void RotateX(float uAngles)
        {
            CGEMatrix3 rotateMatrix = new CGEMatrix3
            (
                MathF.Cos(uAngles), 0, MathF.Sin(uAngles),
                0, 1, 0,
                -MathF.Sin(uAngles), 0, MathF.Cos(uAngles)
            );

            this.Multiply(rotateMatrix);
        }
    }
}

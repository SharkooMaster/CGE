using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGE.CGEMath
{
    internal class CGEVector3
    {
        public float x;
        public float y;
        public float z;

        public CGEVector3(float uX = 0.0f, float uY = 0.0f, float uZ = 0.0f)
        {
            x = uX; y = uY; z = uZ;
        }

        public override string ToString()
        {
            return $"vec3{{{x},{y},{z}}}";
        }

        // Addition
        public static CGEVector3 operator +(CGEVector3 v1, CGEVector3 v2)
        {
            CGEVector3 result = new CGEVector3();
            result.x = v1.x + v2.x;
            result.y = v1.y + v2.y;
            result.z = v1.z + v2.z;
            return result;
        }

        // Subtraction
        public static CGEVector3 operator -(CGEVector3 v1, CGEVector3 v2)
        {
            CGEVector3 result = new CGEVector3();
            result.x = v1.x - v2.x;
            result.y = v1.y - v2.y;
            result.z = v1.z - v2.z;
            return result;
        }

        // Scalar Multiplication / Divison
        public static CGEVector3 operator *(CGEVector3 v1, float c)
        {
            CGEVector3 result = new CGEVector3();
            result.x = v1.x * c;
            result.y = v1.y * c;
            result.z = v1.z * c;
            return result;
        }

        public static CGEVector3 operator /(CGEVector3 v1, float c)
        {
            CGEVector3 result = new CGEVector3();
            result.x = v1.x / c;
            result.y = v1.y / c;
            result.z = v1.z / c;
            return result;
        }

        // Product Multiplication
        public static float operator *(CGEVector3 v1, CGEVector3 v2)
        {
            return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
        }
        public float Dot(CGEVector3 vec) { return (x * vec.x + y * vec.y + z * vec.z); }

        // Cross Product Multiplication
        public static CGEVector3 operator %(CGEVector3 v1, CGEVector3 v2)
        {
            CGEVector3 result = new CGEVector3();
            result.x = (v1.y * v2.z) - (v1.z * v2.y);
            result.y = (v1.z * v2.x) - (v1.x * v2.z);
            result.z = (v1.x * v2.y) - (v1.y * v2.x);
            return result;
        }
        public CGEVector3 Cross(CGEVector3 vec) { return this % vec; }

        // Magnitude
        public float Magnitude()
        {
            return (float)Math.Sqrt((x * x) + (y * y) + (z * z));
        }

        // Normalize
        public void Normalize()
        {
            float magnitude = Magnitude();
            if(magnitude > 0.0f)
            {
                float _magnitude = 1.0f/magnitude;
                x *= _magnitude;
                y *= _magnitude;
                z *= _magnitude;
            }
        }

        // Vector Rotation
        public CGEVector3 RotateVector(float uAngle, CGEVector3 uAxis)
        {
            CGEQuaternion p = new CGEQuaternion(0, this);
            uAxis.Normalize();

            CGEQuaternion q = new CGEQuaternion(uAngle, uAxis);
            q.ConvertToUnitNormQuaternion();

            CGEQuaternion qInverse = q.Inverse();
            CGEQuaternion rotatedVector = q * p * qInverse;

            return rotatedVector.vec;
        }

        // Macros
        public CGEVector3 Zero() { return new CGEVector3(0.0f, 0.0f, 0.0f); }
    }
}

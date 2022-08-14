using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGE.CGEMath
{
    internal class CGEQuaternion
    {
        public float s;
        public CGEVector3 vec;

        public CGEQuaternion(float uS, CGEVector3 uVec)
        {
            s = uS;
            vec = uVec;
        }

        // Addition
        public static CGEQuaternion operator +(CGEQuaternion q1, CGEQuaternion q2)
        {
            float s = q1.s + q2.s;
            CGEVector3 vec = q1.vec + q2.vec;

            return new CGEQuaternion(s, vec);
        }

        // Subtraction
        public static CGEQuaternion operator -(CGEQuaternion q1, CGEQuaternion q2)
        {
            float s = q1.s - q2.s;
            CGEVector3 vec = q1.vec - q2.vec;

            return new CGEQuaternion(s, vec);
        }

        // Product Multiplication
        public static CGEQuaternion operator *(CGEQuaternion q1, CGEQuaternion q2)
        {
            float s = q1.s * q2.s - q1.vec.Dot(q2.vec);
            CGEVector3 vec = q2.vec * q1.s + q1.vec * q2.s + q1.vec.Cross(q2.vec);

            return new CGEQuaternion(s, vec);
        }
        public CGEQuaternion Multiply(CGEQuaternion q) { return this * q; }

        // Scalar Multiplication
        public static CGEQuaternion operator *(CGEQuaternion q, float val)
        {
            float s = q.s * val;
            CGEVector3 vec = q.vec * val;

            return new CGEQuaternion(s, vec);
        }

        // Norm
        public float Norm()
        {
            float _s = s * s;
            float _vec = vec * vec;

            return (float)Math.Sqrt(_s + _vec);
        }

        // Unit Norm
        public void Normalize()
        {
            if(Norm() != 0)
            {
                float normVal = 1 / Norm();

                s *= normVal;
                vec *= normVal;
            }
        }

        public void ConvertToUnitNormQuaternion()
        {
            float angle = (float)Math.PI * s / 180.0f;
            vec.Normalize();

            s = (float)Math.Cos(angle * 0.5f);
            vec = vec * (float)Math.Sin(angle * 0.5f);
        }

        // Conjugate
        public CGEQuaternion Conjugate()
        {
            float _s = s;
            CGEVector3 _vec = vec * (-1);

            return new CGEQuaternion(_s, _vec);
        }

        // Inverse
        public CGEQuaternion Inverse()
        {
            float absVal = Norm();
            absVal *= absVal;
            absVal = 1 / absVal;

            CGEQuaternion conjugateVal = Conjugate();

            float _s = conjugateVal.s * absVal;
            CGEVector3 _vec = conjugateVal.vec * absVal;

            return new CGEQuaternion(_s, _vec);
        }

    }
}

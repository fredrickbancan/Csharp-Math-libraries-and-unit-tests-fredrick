using System;

namespace MathClasses
{
    public struct Vector3
    {
        public float x, y, z;

        //constructors
        /*public Vector3F()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }*/
        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public Vector3(float w)
        {
            this.x = this.y = this.z = w;
        }
        public Vector3(Vector3 copyVector)
        {
            this.x = copyVector.x;
            this.y = copyVector.y;
            this.z = copyVector.z;
        }

        //vector vector operators
        public static Vector3 operator + (Vector3 a, Vector3 b)
        {
            return new Vector3(a.x+b.x,a.y+b.y,a.z+b.z);
        }
        public static Vector3 operator - (Vector3 a, Vector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static Vector3 operator * (Vector3 a, Vector3 b)
        {
            return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
        }

        //Float operators, Post
        public static Vector3 operator + (Vector3 a, float b)
        {
            return new Vector3(a.x + b, a.y + b, a.z + b);
        }

        public static Vector3 operator - (Vector3 a, float b)
        {
            return new Vector3(a.x - b, a.y - b, a.z - b);
        }

        public static Vector3 operator * (Vector3 a, float b)
        {
            return new Vector3(a.x * b, a.y * b, a.z * b);
        }

        //Float operators, Pre
        public static Vector3 operator + (float b, Vector3 a)
        {
            return new Vector3(a.x + b, a.y + b, a.z + b);
        }

        public static Vector3 operator - (float b, Vector3 a)
        {
            return new Vector3(a.x - b, a.y - b, a.z - b);
        }

        public static Vector3 operator * (float b, Vector3 a)
        {
            return new Vector3(a.x * b, a.y * b, a.z * b);
        }

        //matrix vector operators
        public static Vector3 operator * (Matrix3 mat, Vector3 vec) // column major vector multiplication
        {
            return new Vector3(
                    /*X*/mat.m1 * vec.x + mat.m4 * vec.y + mat.m7 * vec.z,
                    /*Y*/mat.m2 * vec.x + mat.m5 * vec.y + mat.m8 * vec.z,
                    /*Z*/mat.m3 * vec.x + mat.m6 * vec.y + mat.m9 * vec.z);
        }

        //funcs
        public float Dot(Vector3 vec)
        {
            return this.x * vec.x + this.y * vec.y + this.z * vec.z;
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);
        }

        public void Normalize()
        {
            float length = this.Magnitude();
            if (length != 0)
            {
                this.x /= length;
                this.y /= length;
                this.z /= length;
            }
            else
            {
                this.x = this.y = this.z = 0;
            }
        }
        
        public static float magnitude(Vector3 vec)
        {
            return (float)Math.Sqrt(vec.x * vec.x + vec.y * vec.y + vec.z * vec.z);
        }
        public Vector3 Cross(Vector3 vec)
        {
            return new Vector3(this.y * vec.z - this.z * vec.y, this.z * vec.x - this.x * vec.z, this.x * vec.y - this.y * vec.x);
        }
        public static Vector3 normalize(Vector3 vec)
        {
            float length = magnitude(vec);
            if (length != 0)
            {
                vec.x /= length;
                vec.y /= length;
                vec.z /= length;
            }
            else
            {
                vec.x = vec.y = vec.z = 0;
            }
            return vec;
        }

        public static Vector3 cross(Vector3 vecA, Vector3 vecB)
        {
            return new Vector3(vecA.y * vecB.z - vecA.z * vecB.y, vecA.z * vecB.x - vecA.x * vecB.z, vecA.x * vecB.y - vecA.y * vecB.x);
        }
        public static float dot(Vector3 vecA, Vector3 vecB)
        {
            return vecA.x * vecB.x + vecA.y * vecB.y + vecA.z * vecB.z;
        }
    }
}

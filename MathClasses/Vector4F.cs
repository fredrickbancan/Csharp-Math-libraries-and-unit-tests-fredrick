using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Vector4F
    {
        public float x, y, z, w;

        public Vector4F(float x = 0, float y = 0, float z = 0, float w = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public Vector4F(float j = 0)
        {
            this.x = this.y = this.z = this.w = j; 
        }

        //vector vector operators
        public static Vector4F operator + (Vector4F a, Vector4F b)
        {
            return new Vector4F(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        }

        public static Vector4F operator - (Vector4F a, Vector4F b)
        {
            return new Vector4F(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
        }

        public static Vector4F operator * (Vector4F a, Vector4F b)
        {
            return new Vector4F(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
        }

        //Float operators, post
        public static Vector4F operator + (Vector4F a, float b)
        {
            return new Vector4F(a.x + b, a.y + b, a.z + b, a.w + b);
        }

        public static Vector4F operator - (Vector4F a, float b)
        {
            return new Vector4F(a.x - b, a.y - b, a.z - b, a.w - b);
        }

        public static Vector4F operator * (Vector4F a, float b)
        {
            return new Vector4F(a.x * b, a.y * b, a.z * b, a.w * b);
        }

        //Float operators, pre
        public static Vector4F operator + (float b, Vector4F a)
        {
            return new Vector4F(a.x + b, a.y + b, a.z + b, a.w + b);
        }

        public static Vector4F operator - (float b, Vector4F a)
        {
            return new Vector4F(a.x - b, a.y - b, a.z - b, a.w - b);
        }

        public static Vector4F operator * (float b, Vector4F a)
        {
            return new Vector4F(a.x * b, a.y * b, a.z * b, a.w * b);
        }

        //funcs
        public float Dot(Vector4F vec)
        {
            return this.x * vec.x + this.y * vec.y + this.z * vec.z + this.w * vec.w;
        }
    }
}

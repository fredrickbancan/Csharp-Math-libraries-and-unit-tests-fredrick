using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Vector3F
    {
        public float x, y, z;

        public Vector3F(float x = 0, float y = 0, float z = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public Vector3F(float w = 0)
        {
            this.x = y = this.z = w;
        }

        //vector vector operators
        public static Vector3F operator + (Vector3F a, Vector3F b)
        {
            return new Vector3F(a.x+b.x,a.y+b.y,a.z+b.z);
        }
        public static Vector3F operator - (Vector3F a, Vector3F b)
        {
            return new Vector3F(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static Vector3F operator * (Vector3F a, Vector3F b)
        {
            return new Vector3F(a.x * b.x, a.y * b.y, a.z * b.z);
        }

        //Float operators, Post
        public static Vector3F operator + (Vector3F a, float b)
        {
            return new Vector3F(a.x + b, a.y + b, a.z + b);
        }

        public static Vector3F operator - (Vector3F a, float b)
        {
            return new Vector3F(a.x - b, a.y - b, a.z - b);
        }

        public static Vector3F operator * (Vector3F a, float b)
        {
            return new Vector3F(a.x * b, a.y * b, a.z * b);
        }

        //Float operators, Pre
        public static Vector3F operator + (float b, Vector3F a)
        {
            return new Vector3F(a.x + b, a.y + b, a.z + b);
        }

        public static Vector3F operator - (float b, Vector3F a)
        {
            return new Vector3F(a.x - b, a.y - b, a.z - b);
        }

        public static Vector3F operator * (float b, Vector3F a)
        {
            return new Vector3F(a.x * b, a.y * b, a.z * b);
        }

        //funcs
        public float Dot(Vector3F vec)
        {
            return this.x * vec.x + this.y * vec.y + this.z * vec.z;
        }


    }
}

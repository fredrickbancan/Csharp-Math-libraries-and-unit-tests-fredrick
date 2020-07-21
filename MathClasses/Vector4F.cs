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

        public static Vector4F operator + (Vector4F a, Vector4F b)
        {
            return new Vector4F(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        }

        public static Vector4F operator - (Vector4F a, Vector4F b)
        {
            return new Vector4F(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
        }
    }
}

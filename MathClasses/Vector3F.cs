using System;
using System.Collections.Generic;
using System.Linq;
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
            this.x = this.y = this.z = w;
        }

        public static Vector3F operator + (Vector3F a, Vector3F b)
        {
            return new Vector3F(a.x+b.x,a.y+b.y,a.z+b.z);
        }
        public static Vector3F operator - (Vector3F a, Vector3F b)
        {
            return new Vector3F(a.x - b.x, a.y - b.y, a.z - b.z);
        }

    }
}

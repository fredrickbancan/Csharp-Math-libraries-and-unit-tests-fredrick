using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Matrix3F
    {
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9;

        //constructors
        public Matrix3F()
        {
            this.m1 = 1; this.m2 = 0; this.m3 = 0;
            this.m4 = 0; this.m5 = 1; this.m6 = 0;
            this.m7 = 0; this.m8 = 0; this.m9 = 1;
        }
        public Matrix3F(float m1, float m2, float m3, float m4, float m5, float m6, float m7, float m8, float m9)
        {
            this.m1 = m1; this.m2 = m2; this.m3 = m3;
            this.m4 = m4; this.m5 = m5; this.m6 = m6;
            this.m7 = m7; this.m8 = m8; this.m9 = m9;
        }

        //functions
        public void SetRotateX(float rads)
        { 
            float cos = (float)Math.Cos(rads);
            float sin = (float)Math.Sin(rads);

           /* this.m1 = 1; this.m2 = 0; this.m3 = 0;*/
            /*this.m4 = 0;*/ this.m5 = cos; this.m6 = sin;
            /*this.m7 = 0;*/ this.m8 = -sin; this.m9 = cos;
        }

        public void SetRotateY(float rads)
        {
            float cos = (float)Math.Cos(rads);
            float sin = (float)Math.Sin(rads);

            this.m1 = cos; /*this.m2 = 0;*/ this.m3 = -sin;
          /*this.m4 = 0;     this.m5 = 1;   this.m6 = 0;*/
            this.m7 = sin; /*this.m8 = 0;*/ this.m9 = cos;
        }

        public void SetRotateZ(float rads)
        {

        }
    }
}
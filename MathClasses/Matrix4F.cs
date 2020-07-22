using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Matrix4F
    {
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16;

        //constructors
        public Matrix4F()
        {
            this.m1 = 1; this.m2 = 0; this.m3 = 0; this.m4 = 0;
            this.m5 = 0; this.m6 = 1; this.m7 = 0; this.m8 = 0;
            this.m9 = 0; this.m10= 0; this.m11= 1; this.m12= 0;
            this.m13= 0; this.m14= 0; this.m15= 0; this.m16= 1;
        }
        public Matrix4F(float m1, float m2, float m3, float m4, float m5, float m6, float m7, float m8, float m9, float m10, float m11, float m12, float m13, float m14, float m15, float m16)
        {
            this.m1 = m1; this.m2 = m2; this.m3 = m3; this.m4 = m4;
            this.m5 = m5; this.m6 = m6; this.m7 = m7; this.m8 = m8;
            this.m9 = m9; this.m10= m10; this.m11= m11; this.m12= m12;
            this.m13= m13; this.m14= m14; this.m15= m15; this.m16= m16;
        }

        //functions
        public void SetRotateX(float rads)
        {
            float cos = (float)Math.Cos(rads);
            float sin = (float)Math.Sin(rads); 

            /*this.m1 = 1; this.m2 = 0; this.m3 = 0; this.m4 = 0;*/
            /*this.m5 = 0;*/ this.m6 = cos; this.m7 = sin; /*this.m8 = 0;*/
            /*this.m9 = 0;*/ this.m10 = -sin; this.m11 = cos;/* this.m12 = 0;*/
            /*this.m13 = 0; this.m14 = 0; this.m15 = 0; this.m16 = 1;*/
        }


    }
}

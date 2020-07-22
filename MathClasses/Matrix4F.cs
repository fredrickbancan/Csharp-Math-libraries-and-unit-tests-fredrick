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

        //matrix matrix operators
        public static Matrix4F operator * (Matrix4F matA, Matrix4F matB) //same as examples for math, 4 rows of A for each column of B 
        {
            return new Matrix4F(
                    /*m1*/ matA.m1 * matB.m1 + matA.m2 * matB.m5 + matA.m3 * matB.m9 + matA.m4 * matB.m13, /*m2*/ matA.m1 * matB.m2 + matA.m2 * matB.m6 + matA.m3 * matB.m10+ matA.m4 * matB.m14, /*m3*/ matA.m1 * matB.m3 + matA.m2 * matB.m7 + matA.m3 * matB.m11+ matA.m4 * matB.m15, /*m4*/ matA.m1 * matB.m4 + matA.m14* matB.m8 + matA.m15* matB.m12+ matA.m16* matB.m16,
                    /*m5*/ matA.m5 * matB.m1 + matA.m6 * matB.m5 + matA.m7 * matB.m9 + matA.m8 * matB.m13, /*m6*/ matA.m5 * matB.m2 + matA.m6 * matB.m6 + matA.m7 * matB.m10+ matA.m8 * matB.m14, /*m7*/ matA.m5 * matB.m3 + matA.m6 * matB.m7 + matA.m7 * matB.m11+ matA.m8 * matB.m15, /*m8*/ matA.m5 * matB.m4 + matA.m14* matB.m8 + matA.m15* matB.m12+ matA.m16* matB.m16,
                    /*m9*/ matA.m9 * matB.m1 + matA.m10* matB.m5 + matA.m11* matB.m9 + matA.m12* matB.m13, /*m10*/matA.m9 * matB.m2 + matA.m10* matB.m6 + matA.m11* matB.m10+ matA.m12* matB.m14, /*m11*/matA.m9 * matB.m3 + matA.m10* matB.m7 + matA.m11* matB.m11+ matA.m12* matB.m15, /*m12*/matA.m9 * matB.m4 + matA.m14* matB.m8 + matA.m15* matB.m12+ matA.m16* matB.m16,
                    /*m13*/matA.m13* matB.m1 + matA.m14* matB.m5 + matA.m15* matB.m9 + matA.m16* matB.m13, /*m14*/matA.m13* matB.m2 + matA.m14* matB.m6 + matA.m15* matB.m10+ matA.m16* matB.m14, /*m15*/matA.m13* matB.m3 + matA.m14* matB.m7 + matA.m15* matB.m11+ matA.m16* matB.m15, /*m16*/matA.m13* matB.m4 + matA.m14* matB.m8 + matA.m15* matB.m12+ matA.m16* matB.m16);
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
        public void SetRotateY(float rads)
        {
            float cos = (float)Math.Cos(rads);
            float sin = (float)Math.Sin(rads);

            this.m1 = cos; /*this.m2 = 0;*/ this.m3 = -sin;/* this.m4 = 0;*/
            /*this.m5 = 0; this.m6 = 1; this.m7 = 0; this.m8 = 0;*/
            this.m9 = sin; /*this.m10 = 0;*/ this.m11 = cos; /*this.m12 = 0;*/
           /* this.m13 = 0; this.m14 = 0; this.m15 = 0; this.m16 = 1;*/
        }

        public void SetRotateZ(float rads)
        {
            float cos = (float)Math.Cos(rads);
            float sin = (float)Math.Sin(rads);

            this.m1 = cos; this.m2 = sin; /*this.m3 = 0; this.m4 = 0;*/
            this.m5 = -sin; this.m6 = cos;/* this.m7 = 0; this.m8 = 0;*/
            /*this.m9 = 0; this.m10 = 0; this.m11 = 1; this.m12 = 0;
            this.m13 = 0; this.m14 = 0; this.m15 = 0; this.m16 = 1;*/
        }

    }
}

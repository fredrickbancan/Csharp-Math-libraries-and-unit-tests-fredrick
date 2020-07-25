using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Matrix3
    {
        public Vector3 row0;
        public Vector3 row1;
        public Vector3 row2;
        #region constructors
        public Matrix3(float identity = 1.0F)
        {
            row0 = new Vector3(identity, 0.0F, 0.0F);
            row1 = new Vector3(0.0F, identity, 0.0F);
            row2 = new Vector3(0.0F, 0.0F, identity);
        }
        public Matrix3(float m1, float m2, float m3, float m4, float m5, float m6, float m7, float m8, float m9)
        {
            row0 = new Vector3(m1, m2, m3);
            row1 = new Vector3(m4, m5, m6);
            row2 = new Vector3(m7, m8, m9);
        }
        #endregion

        #region get set
        public float m1
        {
            get { return this.row0.x; }
            set { this.row0.x = value; }
        }
        public float m2
        {
            get { return this.row0.y; }
            set { this.row0.y = value; }
        }
        public float m3
        {
            get { return this.row0.z; }
            set { this.row0.z = value; }
        }
        public float m4
        {
            get { return this.row1.x; }
            set { this.row1.x = value; }
        }
        public float m5
        {
            get { return this.row1.y; }
            set { this.row1.y = value; }
        }
        public float m6
        {
            get { return this.row1.z; }
            set { this.row1.z = value; }
        }
        public float m7
        {
            get { return this.row2.x; }
            set { this.row2.x = value; }
        }
        public float m8
        {
            get { return this.row2.y; }
            set { this.row2.y = value; }
        }
        public float m9
        {
            get { return this.row2.z; }
            set { this.row2.z = value; }
        }
        #endregion



        #region matrix matrix operators
        /*public static Matrix3 operator * (Matrix3 matA, Matrix3 matB) //row left column right (Standard)
        {
            Matrix3 result = new Matrix3();

            result.row0.x = (matA.m1 * matB.m1) + (matA.m2 * matB.m4) + (matA.m3 * matB.m7);
            result.row0.y = (matA.m1 * matB.m2) + (matA.m2 * matB.m5) + (matA.m3 * matB.m8);
            result.row0.z = (matA.m1 * matB.m3) + (matA.m2 * matB.m6) + (matA.m3 * matB.m9);
            result.row1.x = (matA.m4 * matB.m1) + (matA.m5 * matB.m4) + (matA.m6 * matB.m7);
            result.row1.y = (matA.m4 * matB.m2) + (matA.m5 * matB.m5) + (matA.m6 * matB.m8);
            result.row1.z = (matA.m4 * matB.m3) + (matA.m5 * matB.m6) + (matA.m6 * matB.m9);
            result.row2.x = (matA.m7 * matB.m1) + (matA.m8 * matB.m4) + (matA.m9 * matB.m7);
            result.row2.y = (matA.m7 * matB.m2) + (matA.m8 * matB.m5) + (matA.m9 * matB.m8);
            result.row2.z = (matA.m7 * matB.m3) + (matA.m8 * matB.m6) + (matA.m9 * matB.m9);

            return result;
        }*/
        public static Matrix3 operator * (Matrix3 matA, Matrix3 matB) //column left row right
        {
            Matrix3 result = new Matrix3();

            result.row0.x = (matA.m1 * matB.m1) + (matA.m4 * matB.m2) + (matA.m7 * matB.m3);
            result.row0.y = (matA.m2 * matB.m1) + (matA.m5 * matB.m2) + (matA.m8 * matB.m3);
            result.row0.z = (matA.m3 * matB.m1) + (matA.m6 * matB.m2) + (matA.m9 * matB.m3);
            result.row1.x = (matA.m1 * matB.m4) + (matA.m4 * matB.m5) + (matA.m7 * matB.m6);
            result.row1.y = (matA.m2 * matB.m4) + (matA.m5 * matB.m5) + (matA.m8 * matB.m6);
            result.row1.z = (matA.m3 * matB.m4) + (matA.m6 * matB.m5) + (matA.m9 * matB.m6);
            result.row2.x = (matA.m1 * matB.m7) + (matA.m4 * matB.m8) + (matA.m7 * matB.m9);
            result.row2.y = (matA.m2 * matB.m7) + (matA.m5 * matB.m8) + (matA.m8 * matB.m9);
            result.row2.z = (matA.m3 * matB.m7) + (matA.m6 * matB.m8) + (matA.m9 * matB.m9);

            return result;
        }

        #endregion

        #region functions
        public void SetRotateX(float rads)
        {
            float cos = (float)Math.Cos(rads);
            float sin = (float)Math.Sin(rads);
            this.row1 = new Vector3(0.0F, cos, sin);
            this.row2 = new Vector3(0.0F, -sin, cos);
        }

        public void SetRotateY(float rads)
        {
            float cos = (float)Math.Cos(rads);
            float sin = (float)Math.Sin(rads);
            this.row0 = new Vector3(cos, 0.0F, -sin);
            this.row2 = new Vector3(sin, 0.0F, cos);
        }

        public void SetRotateZ(float rads)
        {
            float cos = (float)Math.Cos(rads);
            float sin = (float)Math.Sin(rads);
            this.row0 = new Vector3(cos, sin, 0.0F);
            this.row1 = new Vector3(-sin, cos, 0.0F);
        }
        #endregion
    }
}
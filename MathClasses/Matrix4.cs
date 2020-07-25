using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Matrix4
    {
        public Vector4 row0;
        public Vector4 row1;
        public Vector4 row2;
        public Vector4 row3;

        #region constructors
        public Matrix4(float identity = 1.0F)
        {
            this.row0 = new Vector4(identity, 0, 0, 0);
            this.row1 = new Vector4(0, identity, 0, 0);
            this.row2 = new Vector4(0, 0, identity, 0);
            this.row3 = new Vector4(0, 0, 0, identity);
        }

        public Matrix4(Vector4 row0, Vector4 row1, Vector4 row2, Vector4 row3)
        {
            this.row0 = row0;
            this.row1 = row1;
            this.row2 = row2;
            this.row3 = row3;
        }

        public Matrix4(float m1, float m2, float m3, float m4, float m5, float m6, float m7, float m8, float m9, float m10, float m11, float m12, float m13, float mm4, float m15, float m16)
        {
            this.row0 = new Vector4(m1,m2,m3,m4);
            this.row1 = new Vector4(m5,m6,m7,m8);
            this.row2 = new Vector4(m9,m10,m11,m12);
            this.row3 = new Vector4(m13,mm4,m15,m16);
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
            get { return this.row0.w; }
            set { this.row0.w = value; }
        }
        public float m5
        {
            get { return this.row1.x; }
            set { this.row1.x = value; }
        }
        public float m6
        {
            get { return this.row1.y; }
            set { this.row1.y = value; }
        }
        public float m7
        {
            get { return this.row1.z; }
            set { this.row1.z = value; }
        }
        public float m8
        {
            get { return this.row1.w; }
            set { this.row1.w = value; }
        }
        public float m9
        {
            get { return this.row2.x; }
            set { this.row2.x = value; }
        }
        public float m10
        {
            get { return this.row2.y; }
            set { this.row2.y = value; }
        }
        public float m11
        {
            get { return this.row2.z; }
            set { this.row2.z = value; }
        }
        public float m12
        {
            get { return this.row2.w; }
            set { this.row2.w = value; }
        }
        public float m13
        {
            get { return this.row3.x; }
            set { this.row3.x = value; }
        }
        public float m14
        {
            get { return this.row3.y; }
            set { this.row3.y = value; }
        }
        public float m15
        {
            get { return this.row3.z; }
            set { this.row3.z = value; }
        }
        public float m16
        {
            get { return this.row3.w; }
            set { this.row3.w = value; }
        }
        #endregion

        #region matrix matrix operators
       /* public static Matrix4 operator * (Matrix4 matA, Matrix4 matB) // Row left column right (standard)
        {
            Matrix4 result = new Matrix4();

            result.row0.x = (matA.m1 * matB.m1) + (matA.m2 * matB.m5) + (matA.m3 * matB.m9) + (matA.m4 * matB.m13);
            result.row0.y = (matA.m1 * matB.m2) + (matA.m2 * matB.m6) + (matA.m3 * matB.m10) + (matA.m4 * matB.m14);
            result.row0.z = (matA.m1 * matB.m3) + (matA.m2 * matB.m7) + (matA.m3 * matB.m11) + (matA.m4 * matB.m15);
            result.row0.w = (matA.m1 * matB.m4) + (matA.m2 * matB.m8) + (matA.m3 * matB.m12) + (matA.m4 * matB.m16);
            result.row1.x = (matA.m5 * matB.m1) + (matA.m6 * matB.m5) + (matA.m7 * matB.m9) + (matA.m8 * matB.m13);
            result.row1.y = (matA.m5 * matB.m2) + (matA.m6 * matB.m6) + (matA.m7 * matB.m10) + (matA.m8 * matB.m14);
            result.row1.z = (matA.m5 * matB.m3) + (matA.m6 * matB.m7) + (matA.m7 * matB.m11) + (matA.m8 * matB.m15);
            result.row1.w = (matA.m5 * matB.m4) + (matA.m6 * matB.m8) + (matA.m7 * matB.m12) + (matA.m8 * matB.m16);
            result.row2.x = (matA.m9 * matB.m1) + (matA.m10 * matB.m5) + (matA.m11 * matB.m9) + (matA.m12 * matB.m13);
            result.row2.y = (matA.m9 * matB.m2) + (matA.m10 * matB.m6) + (matA.m11 * matB.m10) + (matA.m12 * matB.m14);
            result.row2.z = (matA.m9 * matB.m3) + (matA.m10 * matB.m7) + (matA.m11 * matB.m11) + (matA.m12 * matB.m15);
            result.row2.w = (matA.m9 * matB.m4) + (matA.m10 * matB.m8) + (matA.m11 * matB.m12) + (matA.m12 * matB.m16);
            result.row3.x = (matA.m13 * matB.m1) + (matA.m14 * matB.m5) + (matA.m15 * matB.m9) + (matA.m16 * matB.m13);
            result.row3.y = (matA.m13 * matB.m2) + (matA.m14 * matB.m6) + (matA.m15 * matB.m10) + (matA.m16 * matB.m14);
            result.row3.z = (matA.m13 * matB.m3) + (matA.m14 * matB.m7) + (matA.m15 * matB.m11) + (matA.m16 * matB.m15);
            result.row3.w = (matA.m13 * matB.m4) + (matA.m14 * matB.m8) + (matA.m15 * matB.m12) + (matA.m16 * matB.m16);

            return result;
        }*/

        public static Matrix4 operator * (Matrix4 matA, Matrix4 matB) // Column left row right 
        {
            Matrix4 result = new Matrix4();
            result.row0.x = (matA.m1 * matB.m1) + (matA.m5 * matB.m2) + (matA.m9  * matB.m3) + (matA.m13 * matB.m4);
            result.row0.y = (matA.m2 * matB.m1) + (matA.m6 * matB.m2) + (matA.m10 * matB.m3) + (matA.m14 * matB.m4);
            result.row0.z = (matA.m3 * matB.m1) + (matA.m7 * matB.m2) + (matA.m11 * matB.m3) + (matA.m15 * matB.m4);
            result.row0.w = (matA.m4 * matB.m1) + (matA.m8 * matB.m2) + (matA.m12 * matB.m3) + (matA.m16 * matB.m4);
            result.row1.x = (matA.m1 * matB.m5) + (matA.m5 * matB.m6) + (matA.m9  * matB.m7) + (matA.m13 * matB.m8);
            result.row1.y = (matA.m2 * matB.m5) + (matA.m6 * matB.m6) + (matA.m10 * matB.m7) + (matA.m14 * matB.m8);
            result.row1.z = (matA.m3 * matB.m5) + (matA.m7 * matB.m6) + (matA.m11 * matB.m7) + (matA.m15 * matB.m8);
            result.row1.w = (matA.m4 * matB.m5) + (matA.m8 * matB.m6) + (matA.m12 * matB.m7) + (matA.m16 * matB.m8);
            result.row2.x = (matA.m1 * matB.m9) + (matA.m5 * matB.m10) + (matA.m9  * matB.m11) + (matA.m13 * matB.m12);
            result.row2.y = (matA.m2 * matB.m9) + (matA.m6 * matB.m10) + (matA.m10 * matB.m11) + (matA.m14 * matB.m12);
            result.row2.z = (matA.m3 * matB.m9) + (matA.m7 * matB.m10) + (matA.m11 * matB.m11) + (matA.m15 * matB.m12);
            result.row2.w = (matA.m4 * matB.m9) + (matA.m8 * matB.m10) + (matA.m12 * matB.m11) + (matA.m16 * matB.m12);
            result.row3.x = (matA.m1 * matB.m13) + (matA.m5 * matB.m14) + (matA.m9  * matB.m15) + (matA.m13 * matB.m16);
            result.row3.y = (matA.m2 * matB.m13) + (matA.m6 * matB.m14) + (matA.m10 * matB.m15) + (matA.m14 * matB.m16);
            result.row3.z = (matA.m3 * matB.m13) + (matA.m7 * matB.m14) + (matA.m11 * matB.m15) + (matA.m15 * matB.m16);
            result.row3.w = (matA.m4 * matB.m13) + (matA.m8 * matB.m14) + (matA.m12 * matB.m15) + (matA.m16 * matB.m16);

            return result;
        }
        public static Matrix4 operator + (Matrix4 matA, Matrix4 matB)
        {
            return new Matrix4(matA.row0 + matB.row0, matA.row1 + matB.row1, matA.row2 + matB.row2, matA.row3 + matB.row3);
        }
        public static Matrix4 operator - (Matrix4 matA, Matrix4 matB)
        {
            return new Matrix4(matA.row0 - matB.row0, matA.row1 - matB.row1, matA.row2 - matB.row2, matA.row3 - matB.row3);
        }
        public static Matrix4 operator * (Matrix4 matA, float value)
        {
            return new Matrix4(matA.row0 * value, matA.row1 * value, matA.row2 * value, matA.row3 * value);
        }
        #endregion

        #region functions
        public void SetRotateX(float rads)
        {
            float cos = (float)Math.Cos(rads);
            float sin = (float)Math.Sin(rads);
            this.row1 = new Vector4(0.0F, cos, sin, 0.0F);
            this.row2 = new Vector4(0.0F, -sin, cos, 0.0F);
        }
        public void SetRotateY(float rads)
        {
            float cos = (float)Math.Cos(rads);
            float sin = (float)Math.Sin(rads);
            this.row0 = new Vector4(cos, 0.0F, -sin, 0.0F);
            this.row2 = new Vector4(sin, 0.0F, cos, 0.0F);
        }

        public void SetRotateZ(float rads)
        {
            float cos = (float)Math.Cos(rads);
            float sin = (float)Math.Sin(rads);
            this.row0 = new Vector4(cos, sin,0.0F, 0.0F);
            this.row1 = new Vector4(-sin, cos,0.0F, 0.0F);
        }

        public static Matrix4 lookAt(Vector3 eye, Vector3 target, Vector3 up)
        {
            Vector3 front = new Vector3(Vector3.normalize(eye - target));
            Vector3 side = new Vector3(Vector3.cross(front, up));
            Vector3 upVector = new Vector3(Vector3.cross(side, front));

            Matrix4 translateToEye = createTranslationMatrix(-eye.x, -eye.y, -eye.z);
            Matrix4 rotateToTarget = new Matrix4(new Vector4(side.x, upVector.x, front.x, 0.0F), new Vector4(side.y, upVector.y, front.y, 0.0F), new Vector4(side.z, upVector.z, front.z, 0.0F), new Vector4(0.0F, 0.0F, 0.0F, 1.0F));
            
            return translateToEye * rotateToTarget;
        }

        public static Matrix4 createTranslationMatrix(float x, float y, float z)
        {
            Matrix4 result = new Matrix4(1.0F);
            result.row3 = new Vector4(x, y, z, 1.0F);
            return result;
        }

        public static Matrix4 createPerspectiveMatrix(float fov, float aspectRatio, float zNear, float zFar)
        {
            float yMax = zNear * (float)Math.Tan(0.5f * fov);
            float yMin = -yMax;
            float xMin = yMin * aspectRatio;
            float xMax = yMax * aspectRatio;
            float x = (2.0F * zNear) / (xMax - xMin);
            float y = (2.0F * zNear) / (yMax - yMin);
            float a = (xMax + xMin) / (xMax - xMin);
            float b = (yMax + yMin) / (yMax - yMin);
            float c = -(zFar + zNear) / (zFar - zNear);
            float d = -(2.0F * zFar * zNear) / (zFar - zNear);
            return new Matrix4(new Vector4(x, 0, 0, 0), new Vector4(0, y, 0, 0), new Vector4(a, b, c, -1), new Vector4(0, 0, d, 0));
        }
        #endregion
    }
}

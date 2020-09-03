using System;

namespace MathClasses
{
    /*Class for storing a color as a 4 byte unsigned integer*/
    public struct Colour
    {
        #region pre-set colours;
        public static Colour blue = new Colour(0, 0, 255);
        public static Colour darkBlue = new Colour(0, 0, 100);
        public static Colour red = new Colour(255, 0, 0);
        public static Colour darkRed = new Colour(100, 0, 0);
        public static Colour green = new Colour(0, 255, 0);
        public static Colour darkGreen = new Colour(0, 100, 0);
        public static Colour white = new Colour(255, 255, 255);
        public static Colour black = new Colour(0, 0, 0);
        public static Colour lightGrey = new Colour(100, 100, 100);
        public static Colour darkGrey = new Colour(50, 50, 50);
        public static Colour yellow = new Colour(255, 255, 0);
        public static Colour darkYellow = new Colour(153, 153, 0);
        public static Colour facility = new Colour(35, 75, 75);
        public static Colour steelBlue = new Colour(70, 130, 180);
        #endregion

        public UInt32 colour;//color values stored in this 4 byte unsigned integer

        //constructors
        /*Constructor taking in a whole unsigned 4 byte integer, or hexadecimal value*/
        public Colour(UInt32 color)
        {
            this.colour = color;
        }

        /*Constructor for specifying each color value from 0 to 255, alpha defaults to 255.*/
        public Colour(byte r, byte g, byte b, byte a = 255)
        {
            colour = (UInt32)(r << 24 | g << 16 | b << 8 | a);
        }


        //get functions
        public byte GetRed()
        {
            return (byte)(colour >> 24);
        }
        public byte GetGreen()
        {
            return (byte)(colour >> 16);
        }
        public byte GetBlue()
        {
            return (byte)(colour >> 8);
        }
        public byte GetAlpha()
        {
            return (byte)(colour);
        }

        public float[] getNormalisedFloats()//returns colours as an array of floats with values 0 - 1 relative to the current values from 0 to 255, for opengl
        {
            return new float[] {MathUtil.normalize(0, 255, (float)this.GetRed()), MathUtil.normalize(0, 255, (float)this.GetGreen()), MathUtil.normalize(0, 255, (float)this.GetBlue()), MathUtil.normalize(0, 255, (float)this.GetAlpha())};
        }

        //set functions
        public void SetRed(byte red)
        {
            colour |= (UInt32) red << 24;
        }
        public void SetGreen(byte green)
        {
            colour |= (UInt32)green << 16;
        }
        public void SetBlue(byte blue)
        {
            colour |= (UInt32)blue << 8;
        }
        public void SetAlpha(byte alpha)
        {
            colour |= (UInt32)alpha;
        }

        /*Returns colour values as a normalized vector 4 with each color converted to a range from 0F to 1F.*/
        public Vector4 GetNormalizedVector4()
        {
            return new Vector4(MathUtil.normalize(0,255,this.GetRed()), MathUtil.normalize(0, 255, this.GetGreen()), MathUtil.normalize(0, 255, this.GetBlue()), MathUtil.normalize(0, 255, this.GetAlpha()));
        }

        /*Written for the test as part of the exercise. Shifts red bits to the green bits.
          Would normally set blue bits to zero, but i will make it save them.*/
        public void ShiftRedToGreen()
        {
            byte savedBlue = GetBlue();
            colour = (UInt32)((byte)(colour >> 24)) << 16;
            SetBlue(savedBlue);
        }
    }
}

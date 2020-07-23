using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Colour
    {
        public UInt32 colour;
        
        //constructors
        public Colour()
        {
            colour = 0;
        }
        public Colour(UInt32 color)
        {
            this.colour = color;
        }

        public Colour(byte r, byte g, byte b, byte a)
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
    }
}

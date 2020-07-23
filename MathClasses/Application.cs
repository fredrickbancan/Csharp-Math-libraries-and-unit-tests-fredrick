using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathClasses
{
    class Application
    {
        //simple program to illustrate different vector and matrix manipulations. Unrelated to assignment and non required.
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                byte typeChoice = 0;
                do
                {
                    typeChoice = getTypeChoiceFromUser();
                }
                while (typeChoice == 0);

                Vector3F vec3A = null;
                Vector3F vec3B = null;
                Vector4F vec4A = null;
                Vector4F vec4B = null;
                Colour color   = null;

                if (typeChoice == 1)
                {
                    vec3A = getVector3FFromInput("Vector A");
                    if (vec3A == null) continue;
                    vec3B = getVector3FFromInput("Vector B", 1);
                    if (vec3B == null) continue;
                    Console.WriteLine();

                    printVector(vec3A, "Vector A");
                    printVectorNormalized(vec3A, "Vector A");
                    printVector(vec3B, "Vector B", 1);
                    printVectorNormalized(vec3B, "Vector B", 1);

                    printVectorDotProduct(vec3A, vec3B, "Vector A", "Vector B");
                    printVectorCrossProduct(vec3A, vec3B, "Vector A", "Vector B");
                }
                else if(typeChoice == 2)
                {
                    vec4A = getVector4FFromInput("Vector A");
                    if (vec4A == null) continue;
                    vec4B = getVector4FFromInput("Vector B", 1);
                    if (vec4B == null) continue;
                    Console.WriteLine();

                    printVector(vec4A, "Vector A");
                    printVectorNormalized(vec4A, "Vector A");
                    printVector(vec4B, "Vector B", 1);
                    printVectorNormalized(vec4B, "Vector B", 1);

                    printVectorDotProduct(vec4A, vec4B, "Vector A", "Vector B");
                    printVectorCrossProduct(vec4A, vec4B, "Vector A", "Vector B");
                }
                else
                {
                    color = getColourFromInput("Colour");
                    printColour(color, "Colour");
                    Console.WriteLine();
                }

                Console.WriteLine();
                pausePrompt();
            }
            while (true);
        }

        //returns a new vector3 based on inputs in input string, format: x, y, z    0.4,-1,2   etc
        public static Vector3F getVector3FFromInput(String vectorName, byte color = 0)
        {
            do
            {
                Console.Write("Enter x, y and z for ");
                Console.ForegroundColor = color == 0 ? ConsoleColor.Blue : ConsoleColor.Yellow;
                Console.Write(vectorName);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" (e.g 4, 0.1, -3): ");
                Console.ForegroundColor = color == 0 ? ConsoleColor.Blue : ConsoleColor.Yellow;
                String input = Console.ReadLine().ToUpper().Replace('F', ' ');
                Console.ForegroundColor = ConsoleColor.White;
                try
                {
                    float[] floatsFromString = Array.ConvertAll(input.Split(','), float.Parse); // gets floats from string
                    return new Vector3F(floatsFromString[0], floatsFromString[1], floatsFromString[2]);
                }
                catch 
                {
                    warn("Input invalid, try again please.");
                }
            }
            while (true);
        }

        //returns a new vector4 based on inputs in input string, format: x, y, z, 4   0.4,-1,2,1   etc
        public static Vector4F getVector4FFromInput(String vectorName, byte color = 0)
        {
            do
            {
                Console.Write("Enter x, y, z and w for ");
                Console.ForegroundColor = color == 0 ? ConsoleColor.Blue : ConsoleColor.Yellow;
                Console.Write(vectorName);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" (e.g 4, 0.1, -3, 23): ");
                Console.ForegroundColor = color == 0 ? ConsoleColor.Blue : ConsoleColor.Yellow;
                String input = Console.ReadLine().ToUpper().Replace('F', ' ');
                Console.ForegroundColor = ConsoleColor.White;

                try
                {
                    float[] floatsFromString = Array.ConvertAll(input.Split(','), float.Parse); // gets floats from string
                    return new Vector4F(floatsFromString[0], floatsFromString[1], floatsFromString[2], floatsFromString[3]);
                }
                catch
                {
                    warn("Input invalid, try again please.");
                }
            }
            while (true);
        }

        public static Colour getColourFromInput(String colourName)
        {
            do
            {
                Console.Write("Enter value for ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(colourName);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" (e.g 00ffff or 00ffff00 or FF00FF or #FFA500 etc): ");
                Console.ForegroundColor = ConsoleColor.White;
                String input = Console.ReadLine().ToLower().Replace('#', ' ').TrimStart();
                //add extra F or FF at end of input if user does not specify alpha values
                while(input.Length < 8)
                {
                    input += "f";
                }
                Console.ForegroundColor = ConsoleColor.White;

                try
                {
                    return new Colour((UInt32)int.Parse(input, System.Globalization.NumberStyles.HexNumber));
                }
                catch
                {
                    warn("Input invalid, try again please.");
                }
            }
            while (true);
        }
        //displays the x,y and z values of the provided vector in a neat fashion
        public static void printVector(Vector3F vec, String vecName, byte color = 0)
        {
            Console.Write("Info for ");
            Console.ForegroundColor = color == 0 ? ConsoleColor.Blue : ConsoleColor.Yellow;
            Console.Write(vecName);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(":\n");
            Console.ForegroundColor = color == 0 ? ConsoleColor.Blue : ConsoleColor.Yellow;
            Console.WriteLine("X: " + vec.x);
            Console.WriteLine("Y: " + vec.y);
            Console.WriteLine("Z: " + vec.z);
            Console.WriteLine("Magnitude/Length: " + vec.Magnitude());
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        //displays the x,y and z values of the provided vector in a neat fashion
        public static void printVectorNormalized(Vector3F vec, String vecName, byte color = 0)
        {
            Vector3F vecCopy = new Vector3F(vec);
            vecCopy.Normalize();
            Console.Write("Info for ");
            Console.ForegroundColor = color == 0 ? ConsoleColor.Blue : ConsoleColor.Yellow;
            Console.Write(vecName);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" Normalized:\n");
            Console.ForegroundColor = color == 0 ? ConsoleColor.Blue : ConsoleColor.Yellow;
            Console.WriteLine("X: " + vecCopy.x);
            Console.WriteLine("Y: " + vecCopy.y);
            Console.WriteLine("Z: " + vecCopy.z);
            Console.WriteLine("Magnitude/Length: " + vecCopy.Magnitude());
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        //prints the dot product of the two provided vectors
        public static void printVectorDotProduct(Vector3F vecA, Vector3F vecB, String vecAName, String vecBName)
        {
            Console.Write("Dot product for ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(vecAName);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" and ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(vecBName);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(": ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(vecA.Dot(vecB));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        //prints the dot product of the two provided vectors
        public static void printVectorCrossProduct(Vector3F vecA, Vector3F vecB, String vecAName, String vecBName)
        {
            Vector3F crossProduct = vecA.Cross(vecB);
            Console.Write("Cross product for ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(vecAName);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" and ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(vecBName);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(":\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Cross product vector info: ");
            Console.WriteLine("X: " + crossProduct.x);
            Console.WriteLine("Y: " + crossProduct.y);
            Console.WriteLine("Z: " + crossProduct.z);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        //displays the x,y,z and w values of the provided vector in a neat fashion
        public static void printVector(Vector4F vec, String vecName, byte color = 0)
        {
            Console.Write("Info for ");
            Console.ForegroundColor = color == 0 ? ConsoleColor.Blue : ConsoleColor.Yellow;
            Console.Write(vecName);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(":\n");
            Console.ForegroundColor = color == 0 ? ConsoleColor.Blue : ConsoleColor.Yellow;
            Console.WriteLine("X: " + vec.x);
            Console.WriteLine("Y: " + vec.y);
            Console.WriteLine("Z: " + vec.z);
            Console.WriteLine("W: " + vec.w);
            Console.WriteLine("Magnitude/Length: " + vec.Magnitude());
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        //displays the x,y,z and w values of the provided vector in a neat fashion
        public static void printVectorNormalized(Vector4F vec, String vecName, byte color = 0)
        {
            Vector4F vecCopy = new Vector4F(vec);
            vecCopy.Normalize();
            Console.Write("Info for ");
            Console.ForegroundColor = color == 0 ? ConsoleColor.Blue : ConsoleColor.Yellow;
            Console.Write(vecName);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" Normalized:\n");
            Console.ForegroundColor = color == 0 ? ConsoleColor.Blue : ConsoleColor.Yellow;
            Console.WriteLine("X: " + vecCopy.x);
            Console.WriteLine("Y: " + vecCopy.y);
            Console.WriteLine("Z: " + vecCopy.z);
            Console.WriteLine("W: " + vecCopy.w);
            Console.WriteLine("Magnitude/Length: " + vecCopy.Magnitude());
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        //prints the dot product of the two provided vectors
        public static void printVectorDotProduct(Vector4F vecA, Vector4F vecB, String vecAName, String vecBName)
        {
            Console.Write("Dot product for ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(vecAName);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" and ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(vecBName);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(": ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(vecA.Dot(vecB));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        //prints the dot product of the two provided vectors
        public static void printVectorCrossProduct(Vector4F vecA, Vector4F vecB, String vecAName, String vecBName)
        {
            Vector4F crossProduct = vecA.Cross(vecB);
            Console.Write("Cross product for ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(vecAName);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" and ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(vecBName);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(":\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Cross product vector info: ");
            Console.WriteLine("X: " + crossProduct.x);
            Console.WriteLine("Y: " + crossProduct.y);
            Console.WriteLine("Z: " + crossProduct.z);
            Console.WriteLine("W: " + crossProduct.w);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        //displays the r, g, b and a values of the provided color in a neat fashion
        public static void printColour(Colour color, String colorName)
        {
            Console.WriteLine();
            Console.Write("Info for ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(colorName);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(":\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("RED  : " + color.GetRed());
            Console.WriteLine("GREEN: " + color.GetGreen());
            Console.WriteLine("BLUE : " + color.GetBlue());
            Console.WriteLine("ALPHA: " + color.GetAlpha());
            Form tempForm = new Form();
            tempForm.BackColor = System.Drawing.Color.FromArgb(255, color.GetRed(), color.GetGreen(), color.GetBlue());
            tempForm.SetDesktopBounds(1000, 1000, 1000, 1000);
            tempForm.Show();
            MessageBox.Show("This is your color! (Ignoring alpha values)\nPress OK to close...");
            tempForm.Close();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
        /*returns the choce of the user as a byte, 0 if error.*/
        public static byte getTypeChoiceFromUser()
        {
            Console.WriteLine("Press the number key for which vector type you want to test:");
            Console.WriteLine("1: for Vector 3");
            Console.WriteLine("2: for Vector 4");
            Console.WriteLine("3: for Colour");
            Console.WriteLine("Escape: to quit");
            ConsoleKeyInfo keyToCheck = Console.ReadKey();
            if (keyToCheck.Key == ConsoleKey.Escape)
                System.Environment.Exit(1);
            Console.WriteLine("\n");
            bool passed = byte.TryParse(keyToCheck.KeyChar.ToString(), out byte useless);
            if (passed)
            {
                if (byte.Parse(keyToCheck.KeyChar.ToString()) == 1)
                    return 1;
                if (byte.Parse(keyToCheck.KeyChar.ToString()) == 2)
                    return 2;
                
                    return 3;
            }
            warn("Invalid Input. Try again.");
            return 0;
        }

        /*pauses prompt and asks to press enter to continue*/
        public static void pausePrompt()
        {
            Console.WriteLine("Press enter to continue or escape to exit...");
            do
            {
                ConsoleKeyInfo input = Console.ReadKey();
                if (input.Key == ConsoleKey.Escape)
                {
                    System.Environment.Exit(1);
                }
                if (input.Key == ConsoleKey.Enter)
                {
                    break;
                }
            } while (true); //will not allow the program to continue untill the enter or esc key is pressed

            Console.WriteLine();
        }

        /// <summary>
        /// used for saying things in a red text
        /// </summary>
        /// <param name="input"></param>
        public static void warn(String input)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(input);
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}

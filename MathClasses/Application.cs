using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    class Application
    {
        //simple program to illustrate different vector manipulations. Unrelated to assignment and non required.
        static void Main(string[] args)
        {
            do
            {
                Vector3F vecA = getVectorFromInput("Vector A");
                if (vecA == null) continue;
                Vector3F vecB = getVectorFromInput("Vector B", 1);
                if (vecB == null) continue;
                Console.WriteLine();

                printVector(vecA, "Vector A");
                printVectorNormalized(vecA, "Vector A");
                printVector(vecB, "Vector B", 1);
                printVectorNormalized(vecB, "Vector B", 1);

                printVectorDotProduct(vecA, vecB, "Vector A", "Vector B", 0, 1);
                printVectorDotProduct(vecB, vecA, "Vector B", "Vector A", 1, 0);

                Console.WriteLine();
                pausePrompt();
                Console.Clear();
            }
            while (true);
        }

        //returns a new vector based on inputs in input string, format: x, y, z    0.4,-1,2   etc
        public static Vector3F getVectorFromInput(String vectorName, byte color = 0)
        {
            do
            {
                Console.Write("Enter x, y and z for ");
                Console.ForegroundColor = color == 0 ? ConsoleColor.Blue : ConsoleColor.Yellow;
                Console.Write(vectorName);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" (e.g 4, 0.1, -3): ");
                Console.ForegroundColor = color == 0 ? ConsoleColor.Blue : ConsoleColor.Yellow;
                String input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                try
                {
                    float[] floatsFromString = Array.ConvertAll(input.Split(','), float.Parse); // gets floats from string
                    return new Vector3F(floatsFromString[0], floatsFromString[1], floatsFromString[2]);
                }
                catch 
                {
                    Console.WriteLine("Input invalid, try again please.");
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
            Vector3F vecCopy = new Vector3F(vec.x,vec.y,vec.z);
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

        public static void printVectorDotProduct(Vector3F vecA, Vector3F vecB, String vecAName, String vecBName, byte colorA, byte colorB)
        {
            Console.Write("Dot product for ");
            Console.ForegroundColor = colorA == 0 ? ConsoleColor.Blue : ConsoleColor.Yellow;
            Console.Write(vecAName);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" and ");
            Console.ForegroundColor = colorB == 0 ? ConsoleColor.Blue : ConsoleColor.Yellow;
            Console.Write(vecBName);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(": ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(vecA.Dot(vecB));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
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

    }
}

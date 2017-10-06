using System;
using System.Collections.Generic;
using Triangles.Shared.Models;

namespace Triangles
{
	class Program
	{
        private const string rowFormat = "| {0,8} | {1,8} | {2,8} | {3,20} |";
        private static string rowSeparator = $"|{new string('-', 55)}|";
        
		static void Main(string[] args)
		{
			bool exit = false;

			List<Triangle> triangles = new List<Triangle>();
			string input = string.Empty;

			while (exit == false)
			{
                Console.Clear();

                Triangle tempTriangle = new Triangle()
                {
                    Side1 = GetInputForSide(1),
                    Side2 = GetInputForSide(2),
                    Side3 = GetInputForSide(3)
                };

                WriteSingleTriangle(tempTriangle);

				triangles.Add(tempTriangle);

                exit = AskToExit();
			}

            Console.Clear();

            WriteAllTriangleTypes(triangles);
            
			Console.WriteLine("Press any key to exit...");
			Console.ReadLine();
		}

        private static float GetInputForSide(int sideNumber)
        {
            float sideValue = 0;
            bool isInputValid = false;

            while (isInputValid == false)
            {
                Console.WriteLine($"Enter a value for side {sideNumber} of the triangle: ");
                sideValue = ValidateInput(Console.ReadLine());
                if (sideValue >= 0)
                {
                    isInputValid = true;
                }
            }

            return sideValue;
        }
		
		private static float ValidateInput(string input)
		{
			bool valid = float.TryParse(input, out float value);

			return valid ? value : -1;
		}

		private static void WriteTriangleType(Triangle t)
		{
            Console.WriteLine(String.Format(rowFormat, t.Side1, t.Side2, t.Side3, t.Classification));
		}

		private static void WriteTableHeader()
		{
            WriteRowSeparator();
            Console.WriteLine(String.Format(rowFormat, "Side 1", "Side 2", "Side 3", "Response"));
            WriteRowSeparator();
        }

        private static void WriteRowSeparator()
        {
            Console.WriteLine(rowSeparator);
        }

        private static void WriteSingleTriangle(Triangle t)
        {
            WriteTableHeader();
            WriteTriangleType(t);
            WriteRowSeparator();
        }

		private static void WriteAllTriangleTypes(List<Triangle> triangles)
		{
            Console.WriteLine();
            Console.WriteLine("Here are all of the triangles you entered:");
            Console.WriteLine();

            WriteTableHeader();
            foreach (Triangle t in triangles)
			{
				WriteTriangleType(t);
			}
            WriteRowSeparator();

            Console.WriteLine();
        }

        private static bool AskToExit()
        {
            bool exit = false;

            Console.WriteLine();
            Console.WriteLine("Would you like you calculate another triangle (y/n)?");
            string input = Console.ReadLine();

            if (input.Length > 0 && String.Equals(input[0].ToString(), "n", StringComparison.InvariantCultureIgnoreCase))
            {
                exit = true;
            }

            return exit;
        }
	}
}

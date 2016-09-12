using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Calculator;

namespace Interface {
	class Program {
		static void Main(string[] args) {

		Start:

			string Input = Console.ReadLine();

			Console.Clear();
			Console.WriteLine("Doing your math homework...");
			Console.WriteLine("Please Wait...");

			char[] space = { ' ' };
			string[] cmd = Input.Split(space);

			int Result = DoMath(cmd[0], Int32.Parse(cmd[1]), Int32.Parse(cmd[2]));

			Console.Clear();

			Console.WriteLine("And the result of\n" + Input + "\nis:");
			Console.WriteLine(Result);

			EndProgram();
			goto Start;
		}

		private static long DoMath(string function, int n1, int n2 = 0) {
			switch (function.ToLower()) {
				default: throw new Exception("Invalid Math Function"); break;
					
				case "addition": case "add": case "a":
					return Calculator.Add(n1, n2);
					break;

				case "subtract": case "sub": case "s":
					return Calculator.Subtract(n1, n2);
					break;

				case "power": case "pow": case "p":
					return Calculator.Power(n1, n2);
					break;

				case "factorial": case "fact": case "fac": case "f":
					return Calculator.Factorial(n1);
					break;

				case "multiply": case "multi": case "m":
					return Calculator.Multiply(n1, n2);
					break;
		
			}
		}

		private static void EndProgram() {
			Console.WriteLine("");
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
			Console.Clear();
		}
	}
}

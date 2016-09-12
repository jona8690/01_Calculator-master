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
			int n2;

			if (cmd.Length == 3) {
				n2 = Int32.Parse(cmd[2]);
			} else if (cmd.Length > 3) {
				killapp("Cannot take more than 3 parameters.");
				goto Start;
			} else n2 = 0;

			long Result = DoMath(cmd[0], cmd[1], n2);

			Console.Clear();

			Console.WriteLine("And the result of\n" + Input + "\nis:");
			Console.WriteLine(Result);

			EndProgram();
			goto Start;
		}

		private static long DoMath(string function, string a1, int n2 = 0) {
			switch (function.ToLower()) {
				default: killapp("Invalid Math Function"); throw new Exception("Meh");
					
				case "addition": case "add": case "a":
					int n1 = Int32.Parse(a1);
					return Calculator.Add(n1, n2);

				case "subtract": case "sub": case "s":
					int b1 = int.Parse(a1);
					return Calculator.Subtract(b1, n2);

				case "power": case "pow": case "p":
					int c1 = int.Parse(a1);
					return Calculator.Power(c1, n2);

				case "factorial": case "fact": case "fac": case "f":
					int d1 = int.Parse(a1);
					return Calculator.Factorial(d1);

				case "divide": case "div": case "d":
					int e1 = int.Parse(a1);
					return Calculator.Divide(e1, n2);

				case "multiply": case "multi": case "m":
					int f1 = Int32.Parse(a1);
					return Calculator.Multiply(f1, n2);

				case "sum":
					char[] space = { ',' };
					string[] array = a1.Split(space);
					int[] g1 = Array.ConvertAll(array, int.Parse);

					return Calculator.Sum(g1);
			}
		}

		private static void EndProgram() {
			Console.WriteLine("");
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
			Console.Clear();
		}

		private static void killapp() {
			Console.Clear();
			Console.WriteLine("You broke the app! Nooooooooooooo");
			Console.Read();
		}
	}
}

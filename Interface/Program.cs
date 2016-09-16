using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using _01_Calculator;

namespace Interface {
	class Program {
		static void Main(string[] args) {

		Start:

			Console.Clear();
			Console.WriteLine("For Assistance, type:\n!commands\n");
			Console.WriteLine("Type your Input:");
			string Input = Console.ReadLine().ToLower();

			Console.Clear();
			Console.WriteLine("Doing your math homework...");
			Console.WriteLine("Please Wait...");

			char[] space = { ' ' };
			string[] cmd = Input.Split(space);
			int n2;

			if (cmd[0] == "!commands") {
				sendCommands();
			} else {
				String pattern = @"(\d+)\s*([-+*/])\s*(\d+)";
				long Result;

				Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
				Match m = r.Match(Input);

				if (m.Success) {
					//Console.WriteLine("DEBUG --Regex was successful--"); Console.ReadKey();
					string Method = "";

					switch(m.Groups[2].Value) {
						case "+": Method = "add"; break;
						case "-": Method = "sub"; break;
						case "/": Method = "div"; break;
						case "*": case "x": Method = "mult"; break;
						default: killapp("Invalid Math Operator", true); goto Start;
					}

					string v1 = m.Groups[1].Value;
					int v2 = int.Parse(m.Groups[3].Value);

					Result = DoMath(Method, v1, v2);
				} else {
					//Console.WriteLine("DEBUG --Regex was NOT successful--"); Console.ReadKey();
					if (cmd.Length == 3) {
						n2 = Int32.Parse(cmd[2]);
					} else if (cmd.Length < 2) {
						killapp("Needs at least 2 parameters.", true);
						goto Start;
					} else if (cmd.Length > 3) {
						killapp("Cannot take more than 3 parameters.", true);
						goto Start;
					} else n2 = 0;

					Result = DoMath(cmd[0], cmd[1], n2);
				}
				Console.Clear();

				Console.WriteLine("And the result of\n" + Input + "\nis:");
				Console.WriteLine(Result);
			}
			EndProgram();
			goto Start;
		}

		private static long DoMath(string function, string a1, int n2 = 0) {
			switch (function.ToLower()) {
				default: killapp("Invalid Math Function"); return 0;
					
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
					if(d1 > 20) { killapp("Sorry, cannot factorial higher than 20"); }
					return Calculator.Factorial(d1);

				case "divide": case "div": case "d":
					int e1 = int.Parse(a1);
					return Calculator.Divide(e1, n2);

				case "multiply": case "multi": case "mult": case "m":
					int f1 = Int32.Parse(a1);
					return Calculator.Multiply(f1, n2);

				case "sum":
					char[] space = { ',' };
					string[] array = a1.Split(space);
					int[] g1 = Array.ConvertAll(array, int.Parse);

					return Calculator.Sum(g1);
			}
		}

		private static void sendCommands() {

			string Commands = 
@"There are 2 formats which you can enter math functions.
Standard format: (Matematical equation)
	Adding........:	<number> + <number>
	Subtracting...:	<number> - <number>
	Multiplying...:	<number> * <number>
			<number> x <number>
	Division......:	<number> / <number>

Alternative Format: (Command based: <command> <input> <input2>)
	add <number> <number>
		Alternative commands:
		a, addition
	sub <number> <number>
		Alternative commands:
		s, subtract
	multiply <number> <number>
		Alternative commands:
		m, mult, multi
	divide <number> <number>
		Alternative commands:
		d, div
	power <number> <power>
		Alternative commands:
		p, pow
	factorial <number>
		Alternative commands:
		f, fac, fact
	sum <number>,<number>,<number>,...
";

			Console.Clear();
			Console.WriteLine(Commands);
		}

		private static void EndProgram() {
			Console.WriteLine("");
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
			Console.Clear();
		}

		private static void killapp(string msg, bool canreturn = false) {
			Console.Clear();
			Console.WriteLine("You broke the app! Nooooooooooooo");
			Console.WriteLine(msg);
			Console.ReadKey();

			if(!canreturn)
				throw new Exception(msg);
		}
	}
}

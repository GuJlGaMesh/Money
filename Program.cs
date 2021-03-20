using System;

namespace Money
{
	class Program
	{
		public static Money TakeMoney(string input)
		{
			if (input.EndsWith('R'))
			{
				return new Rub(int.Parse(input.Remove(input.Length - 1)));
			}
			if (input.EndsWith('E'))
			{
				return new Euro(int.Parse(input.Remove(input.Length - 1)));
			}
			if (input.EndsWith('D'))
			{
				return new Dollar(int.Parse(input.Remove(input.Length - 1)));
			}
			return new UnconvertableMoney(0, null);
		}
		static void Main(string[] args)
		{
			var exit = "";
			while (exit != "stop")
			{
				var input = Console.ReadLine();
				if (input == "stop") break;
				var moneys = input.Split(new char[] {'+', '-', '>', '<', ' '}, StringSplitOptions.RemoveEmptyEntries);
				var m1 = TakeMoney(moneys[0]);
				var m2 = TakeMoney(moneys[1]);
				if (input.Contains('+'))
					Console.WriteLine(m1+m2);
				if (input.Contains('-'))
					Console.WriteLine(m1-m2);
				if (input.Contains('<'))
					Console.WriteLine(m1<m2);
				if (input.Contains('>'))
					Console.WriteLine(m1>m2);
			}
		}
	}
}

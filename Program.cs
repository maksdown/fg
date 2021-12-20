using System;

namespace dotenet_core
{
	class Program
	{
		static int winrate;
		static int bal=1000;
		static string rpl;
		static int parserpl;
		static int win;
		static Random rd = new Random();
		static void Main(string[] args)
		{
			

			int day = 1;
			Console.WriteLine("Эмулятор казино! День: "+day+"\n");
			MainMenu();
			static void MainMenu()
			{
				Console.WriteLine("Главное меню\n1. Казино\n2. Профиль\n3. Пополнить баланс");
				rpl = Console.ReadLine();
				bool result = int.TryParse(rpl, out parserpl);
				if (result)
				{
					parserpl = int.Parse(rpl);
					switch (parserpl)
					{
						case 1:
							Menu();
							break;
						case 2:
							Profile();
							break;
						case 3:
							Donate();
							break;
						default:
							Console.WriteLine("Введено некорректное значение!");
							MainMenu();
							break;
					}
				}
				else
				{
					Console.WriteLine("Введено некорректное значение!");
					MainMenu();
				}
			}
			static void Menu()
			{
				Console.WriteLine("Выберете игру (напишите номер в консоль) \n1. 50/50\n0. Назад");
				rpl = Console.ReadLine();
				bool result = int.TryParse(rpl, out parserpl);
				if (result)
				{
					parserpl = int.Parse(rpl);
					switch (parserpl)
					{
						case 1:
							game1();
							break;
						case 0:
							MainMenu();
							break;
						default:
							Console.WriteLine("Введено некорректное значение!");
							Menu();
							break;
					}
				}
				else
				{
					Console.WriteLine("Введено некорректное значение!");
					Menu();
				}

				static void game1()
				{
					int rdcase = rd.Next(2);
					Console.Write("Введите ставку:\t");
					rpl = Console.ReadLine();
					int bet = int.Parse(rpl);

					bool result = int.TryParse(rpl, out parserpl);
					if (result)
					{
						parserpl = int.Parse(rpl);
						if (parserpl <= bal)
						{
						}
						else
						{
							Console.WriteLine("Вы не можете поставить больше, чем имеете!");
							game1();
						}
					}
					else
					{
						Console.WriteLine("Введено некорректное значение!");
						Menu();
					}

					switch (rdcase)
					{
						case 0:
							Console.WriteLine("Вы проиграли :(");
							winrate--;
							bal = bal - bet;
							//Console.WriteLine(winrate);
							Menu();
							break;
						case 1:
							Console.WriteLine("Вы выйграли!");
							winrate++;
							win++;
							bal = bal + bet;
							//Console.WriteLine(winrate);
							Menu();
							break;
					}
				}
			}
				static void Profile()
				{
					Console.WriteLine("Баланс: "+bal+"\nКол-во побед: "+win+"\n");
					Console.WriteLine("1. Пополнить баланс\n0. Назад");
					rpl = Console.ReadLine();
					bool result = int.TryParse(rpl, out parserpl);
					if (result)
					{
						parserpl = int.Parse(rpl);
						switch (parserpl)
						{
							case 1:
							Donate();
								break;
							case 0:
								MainMenu();
								break;
							default:
								Console.WriteLine("Введено некорректное значение!");
								Menu();
								break;
						}
					}
					else
					{
						Console.WriteLine("Введено некорректное значение!");
						Menu();
					}
				}
			static void Donate()
			{
				Console.WriteLine("Способ пополнения баланса\n1. Промо-код\n2. Платёжная система (Никогда не выйдет)\n0. Назад");
				rpl = Console.ReadLine();
				bool result = int.TryParse(rpl, out parserpl);
				if (result)
				{
					parserpl = int.Parse(rpl);
					switch (parserpl)
					{
						case 1:
							Console.WriteLine("Введите промо-код:");
							string a =Console.ReadLine();
							if (a == "3108")
							{
								Console.WriteLine("Баланс пополнен на 5000 рублей!");
								bal = bal + 5000;
								Donate();
							}
							else
							{
								Console.WriteLine("Промо-код не действителен!");
								Donate();
							}
							break;
						case 0:
							MainMenu();
							break;
						case 2:
								Console.WriteLine("мшк фреде");
								Donate();
							break;
						default:
							Console.WriteLine("Введено некорректное значение!");
							Donate();
							break;
					}
				}
				else
				{
					Console.WriteLine("Введено некорректное значение!");
					Menu();
				}
			}
			
		}		
	}
}

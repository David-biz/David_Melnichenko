using System;

namespace Laboratory_7_2{
	class Program {
		static void Main() {
			Console.OutputEncoding = System.Text.Encoding.UTF8;
			Console.Title = "Lab5_3";

			MyMatrix<int> matrix = null;
			while (Console.KeyAvailable)
				Console.ReadKey();  // Очистить буферобмену 
			for (; ; ) {
				int a, b;
				if (matrix == null) {
					Console.Write("Пожалуйста, введите ширину матрицы от 1 до 9: ");
					do {
						a = GetNumberKey();
					} while (a < 1);
					Console.WriteLine(a);

					Console.Write("Пожалуйста, введите высоту матрицы від 1 до 9: ");
					do {
						b = GetNumberKey();
					} while (b < 1);
					Console.WriteLine(b);

					matrix = new MyMatrix<int>(a, b);
				}

				Console.WriteLine("Что вы хотите сделать?");
				Console.WriteLine("1. Показать матрицу");
				Console.WriteLine("2. Редоктировать матрицу");
				Console.WriteLine("3. Пересоздать матрицу");
				Console.WriteLine("4. Добавить столбец матрицы");
				Console.WriteLine("5. Добавить строку к матрицы");
				Console.WriteLine("6. Удалить столбцы матрицы");
				Console.WriteLine("7. Удалить строку матрицы");
				Console.WriteLine("8. Выйти с програмы");

				do {
					a = GetNumberKey();
				} while (a < 1 || a > 8);
				switch (a) {
				case 1:
					ShowMatrix(matrix);
					break;
				case 2:
					EditMatrix(matrix);
					break;
				case 3:
					matrix = null;
					break;
				case 4:
					Console.WriteLine("В конец матрицы добавили столбец.");
					matrix.AddOneColumn();
					break;
				case 5:
					Console.WriteLine("В конец матрицы добавили столбец.");
					matrix.AddOneRow();
					break;
				case 6:
					Console.WriteLine("Удален последний столбец матрицы.");
					matrix.RemoveOneColumn();
					break;
				case 7:
					Console.WriteLine("Удален последний столбец матрицы.");
					matrix.RemoveOneRow();
					break;
				case 8:
					return;
				}
			}
		}

		static void ShowMatrix(MyMatrix<int> matrix) {
			// вывести на экран матрицу
			for (var i = 0; i < matrix.Height; i++) {
				for (var j = 0; j < matrix.Width; j++) {
					Console.Write("{0,4}", matrix[j, i]);
				}
				Console.WriteLine();
			}
		}

		static void EditMatrix(MyMatrix<int> matrix) {
			ShowMatrix(matrix);

			var fgc = Console.ForegroundColor;
			var bgc = Console.BackgroundColor;
			var x = 0;
			var y = 0;
			var currentline = Console.CursorTop;  // Запомнить номер строки
			while (Console.KeyAvailable)
				Console.ReadKey();  // Очистити буферобмена
			for (; ; ) {
				Console.SetCursorPosition(x * 4, currentline - matrix.Height + y);
				Console.BackgroundColor = fgc;
				Console.ForegroundColor = bgc;
				Console.Write("{0,4}", matrix[x, y]);
				Console.ResetColor();
				Console.SetCursorPosition(0, currentline);
				ConsoleKey key = Console.ReadKey(true).Key;
				Console.SetCursorPosition(x * 4, currentline - matrix.Height + y);
				Console.Write("{0,4}", matrix[x, y]);
				Console.SetCursorPosition(0, currentline);
				switch (key) {
				case ConsoleKey.Enter:
					goto Exit;  
				case ConsoleKey.LeftArrow:
					// Перемістить курсор вліво.
					if (x > 0)
						x--;
					break;
				case ConsoleKey.UpArrow:
					// Перемістить курсор вверх.
					if (y > 0)
						y--;
					break;
				case ConsoleKey.RightArrow:
					// Перемістить курсор вправо.
					if (x < matrix.Width - 1)
						x++;
					break;
				case ConsoleKey.DownArrow:
					// Переместить курсор вниз.
					if (y < matrix.Height - 1)
						y++;
					break;
				case ConsoleKey.D0:
				case ConsoleKey.D1:
				case ConsoleKey.D2:
				case ConsoleKey.D3:
				case ConsoleKey.D4:
				case ConsoleKey.D5:
				case ConsoleKey.D6:
				case ConsoleKey.D7:
				case ConsoleKey.D8:
				case ConsoleKey.D9:
						// Если ввести цифру, минус меняется 
						if (matrix[x, y] < 0)
						matrix[x, y] = -matrix[x, y];
					matrix[x, y] = (matrix[x, y] % 10 * 10) + (key - ConsoleKey.D0);
					break;
				case ConsoleKey.NumPad0:
				case ConsoleKey.NumPad1:
				case ConsoleKey.NumPad2:
				case ConsoleKey.NumPad3:
				case ConsoleKey.NumPad4:
				case ConsoleKey.NumPad5:
				case ConsoleKey.NumPad6:
				case ConsoleKey.NumPad7:
				case ConsoleKey.NumPad8:
				case ConsoleKey.NumPad9:
					// Если ввести цифру, минус меняется 
					if (matrix[x, y] < 0)
						matrix[x, y] = -matrix[x, y];
					matrix[x, y] = (matrix[x, y] % 10 * 10) + (key - ConsoleKey.NumPad0);
					break;
				case ConsoleKey.OemMinus:
				case ConsoleKey.Subtract:
					matrix[x, y] = -matrix[x, y];
					break;
				default:
					break;
				}
			}
		Exit:
			Console.CursorVisible = true;  // Курсор.
		}

		static int GetNumberKey() {
			for (; ; ) {
				var key = Console.ReadKey(true).Key;
				switch (key) {
				case ConsoleKey.D0:
				case ConsoleKey.D1:
				case ConsoleKey.D2:
				case ConsoleKey.D3:
				case ConsoleKey.D4:
				case ConsoleKey.D5:
				case ConsoleKey.D6:
				case ConsoleKey.D7:
				case ConsoleKey.D8:
				case ConsoleKey.D9:
					return key - ConsoleKey.D0;
				case ConsoleKey.NumPad0:
				case ConsoleKey.NumPad1:
				case ConsoleKey.NumPad2:
				case ConsoleKey.NumPad3:
				case ConsoleKey.NumPad4:
				case ConsoleKey.NumPad5:
				case ConsoleKey.NumPad6:
				case ConsoleKey.NumPad7:
				case ConsoleKey.NumPad8:
				case ConsoleKey.NumPad9:
					return key - ConsoleKey.NumPad0;
				}
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _20_Lab7_1 {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
			array = new int[random.Next(2, 100)];
			for (int i = 0; i < array.Length; i++) {
				array[i] = random.Next(-99, 100);
			}
			Slider.Maximum = array.Length - 1;
			Slider.Value = index = random.Next(array.Length);
			ItemValue.Text = array[index].ToString();
			ItemInfo.Text = $"Значение элемента {index}:";
			UpdateInfo();
		}

		readonly Random random = new Random();
		int[] array;
		int index;

		private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
			index = (int)Slider.Value;  
			ItemInfo.Text = $"Значение элемента {index}:";
			ItemValue.Text = array[index].ToString();
			UpdateInfo();
		}

		private void ItemValue_TextChanged(object sender, TextChangedEventArgs e) {
			if (int.TryParse(ItemValue.Text.Trim(), out int value) ||
				ItemValue.Text.Trim() == "-") {
				array[index] = value;
				UpdateInfo();
			} else {
				MessageBox.Show("Можна вводить только цифры", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				ItemValue.Text = array[index].ToString();
			}
		}

		private void CreateArrayButton_Click(object sender, RoutedEventArgs e) {
			if (ArraySizeInput.Text.Trim() == "") {
				MessageBox.Show("Пожалуйста, введите размер масива!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			} else if (!int.TryParse(ArraySizeInput.Text.Trim(), out int size) || size < 2) {
				MessageBox.Show($"{ArraySizeInput.Text.Trim()} Не правильный размер масива!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			} else {
				array = new int[size];
				for (int i = 0; i < size; i++) {
					array[i] = random.Next(-99, 100);
				}
				Slider.Value = index = random.Next(size);
				Slider.Maximum = size - 1;
				ItemValue.Text = array[index].ToString();
				ItemInfo.Text = $"Значение элемента {index}:";
				UpdateInfo();
			}
		}

		private void UpdateInfo() {
			// Динамичный ввод (Если в интерфейсе миняется значение) Вводить:
			int max = array[0];// Найбольшее значние масива,
			int min = array[0];// найменьшее значние масива,
			int sum = array[0];// общая сумма елементов,
			double avg;        // среднее арифметическое всех елементов,
			string odds = ""; 

			for (int i = 1; i < array.Length; i++) {
				if (array[i] > max)
					max = array[i];
				if (array[i] < min)
					min = array[i];
				sum += array[i];
			}
			avg = (double)sum / array.Length;

			bool oddnum = false;
			for (int i = 0; i < array.Length; i++) {
				if (array[i] % 2 != 0) {
					odds += oddnum ? $", {array[i]}" : array[i];
					oddnum = true;
				}
			}
			if (!oddnum)
				odds = "відсутні";

			ArrayInfo.Text =
				$"Найбольшее значение : {max}\n" +
				$"Найменьшее значение: {min}\n" +
				$"Сумма всех елементов: {sum}\n" +
				$"Среднее значение: {avg}\n" +
				$"Непарное значение: {odds}"
				;
		}
	}
}

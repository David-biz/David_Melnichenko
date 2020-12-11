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

namespace _20_Lab7_3 {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			Store = new Store();
			InitializeComponent();
		}

		readonly Store Store;

		private void CreateItem_Click(object sender, RoutedEventArgs e) {
			int price;
			if (NewItemName.Text.Length == 0 || NewStoreName.Text.Length == 0) {
				MessageBox.Show("Назва товару та/або магазину не може бути порожньою!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
			} else if (!int.TryParse(NewPrice.Text, out price) || price <= 0) {
				MessageBox.Show($"{NewPrice.Text} не є коректною вартістю товару!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
			} else {
				Article article = new Article(NewItemName.Text, NewStoreName.Text, price);
				Store.AddArticle(article);
				MessageBox.Show("Товар успішно додано!", "", MessageBoxButton.OK, MessageBoxImage.Asterisk);
			}
		}

		private void FindItemIndex_TextChanged(object sender, TextChangedEventArgs e) {
			if (FindItemIndex.Text == "") {
				IndexOut.Text = "";
			} else if (!int.TryParse(FindItemIndex.Text, out int index) || index < 0) {
				IndexOut.Text = $"{FindItemIndex.Text} не є коректним індексом!";
			} else if (Store[index] == null) {
				IndexOut.Text = $"Товар за індексом {index} відсутній!";
			} else {
				IndexOut.Text =
					$"Назва товару: {Store[index].ItemName}\n" +
					$"Назва магазину: {Store[index].StoreName}\n" +
					$"Вартість, ₴: {Store[index].Price}\n";
			}
		}

		private void FindItemName_TextChanged(object sender, TextChangedEventArgs e) {
			if (FindItemName.Text == "") {
				NameOut.Text = "";
			} else if (Store[FindItemName.Text] == null) {
				NameOut.Text = "Товар за даною назвою відсутній!";
			} else {
				NameOut.Text =
					$"Назва товару: {Store[FindItemName.Text].ItemName}\n" +
					$"Назва магазину: {Store[FindItemName.Text].StoreName}\n" +
					$"Вартість, ₴: {Store[FindItemName.Text].Price}\n";
			}
		}

		private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e) {
			FindItemIndex.Text = "";
			FindItemName.Text = "";
		}

		private void NewItemName_TextChanged(object sender, TextChangedEventArgs e) {

		}
	}
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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

namespace StarWars
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		static private Dictionary<int, List<Person>> cashDictionary = new Dictionary<int, List<Person>>();
		public MainWindow()
		{
			InitializeComponent();
		}

		private void GetData(int pageNum)
		{
			try
			{
				if (!cashDictionary.ContainsKey(pageNum))
				{
					using (WebClient wc = new WebClient())
					{
						var json = wc.DownloadString($"https://swapi.co/api/people/?page={pageNum}");
						var result = JsonConvert.DeserializeObject<RootObject>(json);
						var people = result.results.ToList<Person>();

						cashDictionary.Add(pageNum,people);

						peopleDataGrid.ItemsSource = people;
					}
				}
				else
				{
					peopleDataGrid.ItemsSource = cashDictionary.GetValueOrDefault(pageNum);
				}
			}
			catch
			{
				WrongPage();
			}
		}

		private void SearchPageClicked(object sender, RoutedEventArgs e)
		{
			int num;
			Int32.TryParse(pageNumber.Text, out num);
			if (num != 0)
			{
				GetData(num);
				return;
			}
			WrongPage();
		}

		private static void WrongPage()
		{
			MessageBox.Show("Введенной страницы не существует, всего страниц - 9");
		}

		private void TextBoxPreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			e.Handled = !IsTextAllowed(e.Text);
		}

		private static readonly Regex _regex = new Regex("[^0-9.-]+");

		private bool IsTextAllowed(string text)
		{
			return !_regex.IsMatch(text);
		}
	}
}

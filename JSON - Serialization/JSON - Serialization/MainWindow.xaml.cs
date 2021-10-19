using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace JSON___Serialization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Game> games = new List<Game>();
        private List<Game> filterGames;

        public MainWindow()
        {
            InitializeComponent();

            var lines = File.ReadAllLines("all_games.csv").Skip(1);

            foreach (var item in lines)
            {
                games.Add(new Game(item));
            }
            PopulateComboBox();
            PopulateListBox(games);
        }

        private void PopulateListBox(List<Game> games)
        {
            listBox.Items.Clear();
            foreach (var item in games)
            {
                listBox.Items.Add(item);
            }
        }

        private void PopulateComboBox()
        {
            comboBox.Items.Add("All");
            comboBox.SelectedIndex = 0;
            foreach (var item in games)
            {
                if (string.IsNullOrWhiteSpace(item.Platform))
                {
                    continue;
                }
                if (!comboBox.Items.Contains(item.Platform))
                {
                    comboBox.Items.Add(item.Platform);
                }
            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //List<Game> filterGames;
            filterGames = FilteredGames(games);
            PopulateListBox(filterGames);
        }

        private List<Game> FilteredGames(List<Game> games)
        {
            string gName = comboBox.SelectedValue.ToString();
            List<Game> filterGames = new List<Game>();
            foreach (var item in games)
            {
                if (gName.ToLower() == "all")
                {
                    filterGames.Add(item);
                }
                else if (item.Platform.Contains(gName))
                {
                    filterGames.Add(item);
                }
            }
            return filterGames;
        }

        private void buttonJSON_Click(object sender, RoutedEventArgs e)
        {
            string json = JsonConvert.SerializeObject(filterGames, Formatting.Indented);
            File.WriteAllText("games.json", json);
        }

        private void listBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Game selection = (Game)listBox.SelectedItem;
            DetailWindow win = new DetailWindow();
            win.SetupWindow(selection);
            win.ShowDialog();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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

namespace Snake.Pages
{
    /// <summary>
    /// Interaktionslogik für PageScoreboard.xaml
    /// </summary>
    public partial class PageScoreboard : Page
    {
        public PageScoreboard()
        {
            InitializeComponent();
        }

        private List<DataEntry> ReadEntries()
        {
            try
            {
                using(StreamReader reader = new StreamReader("scoreboard.snake"))
                {

                    return DataEntry.Sort(JsonSerializer.Deserialize<List<DataEntry>>(reader.ReadToEnd()));
                }
            }
            catch
            {
                var result = MessageBox.Show("No scoreboard found.", "Scoreboard", MessageBoxButton.OK, MessageBoxImage.Error);
                if(result == MessageBoxResult.OK)
                {
                    MainWindow.frame.Navigate(MainWindow.pages["menu"]);
                    SnakeLogger.logger.Debug("No scoreboard-file.");
                    
                }
                return new List<DataEntry>();
            }
        }
         
        public void SetUserScore(int score)
        {
            List<DataEntry> list = new List<DataEntry>();
            if (File.Exists("scoreboard.snake"))
            {
                list = ReadEntries();
            }
            bool inList = false;
            foreach(DataEntry entry in list)
            {
                if(MainWindow.username == entry.Username)
                {
                    inList = true;
                    entry.Score += score;
                }
            }
            if (!inList)
            {
                list.Add(new DataEntry(score, MainWindow.username, 0));
            }
            var jsonoptions = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            using(StreamWriter writer = new StreamWriter("scoreboard.snake"))
            {
                writer.Write(JsonSerializer.Serialize(DataEntry.Sort(list), jsonoptions));
            }
        }

        public void SetDataGrid()
        {
            DataGridScoreboard.ItemsSource = ReadEntries();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.frame.Navigate(MainWindow.pages["menu"]);
        }
    }
}

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
    /// Interaktionslogik für PageMenu.xaml
    /// </summary>
    public partial class PageMenu : Page
    {
        public PageMenu()
        {
            InitializeComponent();
        }

        private void ButtonPlayNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow.pages["game"] = new PageGame();
            }
            catch
            {
                MainWindow.pages.Add("game", new PageGame());
            }
            MainWindow.frame.Navigate(MainWindow.pages["game"]);
            SnakeLogger.logger.Information("Started game.");
        }

        private void ButtonPlaySaved_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamReader reader = new StreamReader($"savegame-{MainWindow.username}.snake"))
                {
                    SaveData between = JsonSerializer.Deserialize<SaveData>(reader.ReadToEnd());
                    GameSettings.Apply(between.speed, between.width, between.height, between.difficulty);
                    PageSettings settings = (PageSettings)MainWindow.pages["settings"];
                    settings.Set();
                }
                try
                {
                    MainWindow.pages["game"] = new PageGame();
                }
                catch
                {
                    MainWindow.pages.Add("game", new PageGame());
                }
                MainWindow.game.LoadFromJson();
                SnakeLogger.logger.Information("Loaded game.");
                MainWindow.frame.Navigate(MainWindow.pages["game"]);
            }
            catch
            {
                SnakeLogger.logger.Debug("No savegame.");
                MessageBox.Show("No savegame found!", "Savegame", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonRanked_Click(object sender, RoutedEventArgs e)
        {
            PageScoreboard scoreboard = (PageScoreboard)MainWindow.pages["scoreboard"];
            MainWindow.frame.Navigate(MainWindow.pages["scoreboard"]);
            scoreboard.SetDataGrid();
            SnakeLogger.logger.Information("Open scoreboard.");
        }

        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            SnakeLogger.logger.Debug("Open settings.");
            MainWindow.frame.Navigate(MainWindow.pages["settings"]);
        }
    }
}

using Snake.Pages;
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
using static System.Formats.Asn1.AsnWriter;

namespace Snake.UserControlls
{
    /// <summary>
    /// Interaction logic for UCLose.xaml
    /// </summary>
    public partial class UCLose : UserControl
    {
        public UCLose()
        {
            InitializeComponent();
            this.Height = GameSettings.FieldHeight * 50 + 150;
            this.Width = GameSettings.FieldWith * 50 + 70;
            this.Visibility = Visibility.Hidden;
        }

        private void ButtonRestart_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.game.Reset();
            this.Visibility = Visibility.Hidden;
        }

        private void ButtonMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.frame.Navigate(MainWindow.pages["menu"]);
            MainWindow.mainWindow.Height = 450;
            MainWindow.mainWindow.Width = 600;
        }

        public void Show(int score, bool win)
        {
            LabelScore.Content = $"Score: {score}";
            PageScoreboard scoreboard = (PageScoreboard)MainWindow.pages["scoreboard"];
            scoreboard.SetUserScore(score);
            this.Visibility= Visibility.Visible;
            RectBackground.Height = this.Height;
            RectBackground.Width = this.Width;
            if (win)
            {
                LabelWin.Content = "You won!";
            }
        }
    }
}

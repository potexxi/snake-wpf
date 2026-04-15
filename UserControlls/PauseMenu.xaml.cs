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

namespace Snake.UserControlls
{
    /// <summary>
    /// Interaktionslogik für PauseMenu.xaml
    /// </summary>
    public partial class PauseMenu : UserControl
    {
        public PauseMenu()
        {
            InitializeComponent();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.game.SaveToJson();
        }

        private void ButtonMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.frame.Navigate(MainWindow.pages["menu"]);
            MainWindow.mainWindow.Height = 450;
            MainWindow.mainWindow.Width = 600;
        }

        private void ButtonContinue_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            MainWindow.game.Continue();
        }

        public void SetSize()
        {
            this.Height = MainWindow.mainWindow.Height;
            this.Width = MainWindow.mainWindow.Width;
            RectBackground.Height = MainWindow.mainWindow.Height;
            RectBackground.Width = MainWindow.mainWindow.Width;
        }
    }
}

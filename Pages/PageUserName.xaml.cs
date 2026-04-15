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

namespace Snake.Pages
{
    /// <summary>
    /// Interaktionslogik für PageUserName.xaml
    /// </summary>
    public partial class PageUserName : Page
    {
        public PageUserName()
        {
            InitializeComponent();
        }

        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            if(TextBoxUsername.Text != "")
            {
                MainWindow.username = TextBoxUsername.Text;
                MainWindow.frame.Navigate(MainWindow.pages["menu"]);
                SnakeLogger.logger.Information($"Username entered: \"{MainWindow.username}\"");
            }
        }
    }
}

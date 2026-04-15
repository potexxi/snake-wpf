using Snake.UserControlls;
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
    /// Interaktionslogik für PageGame.xaml
    /// </summary>
    public partial class PageGame : Page
    {
        public static PauseMenu pauseMenu;
        public static UCLose uCLose;
        public static bool playing = false;
        public static Field field { get; private set; }
        public static Label labelScore;
        public PageGame()
        {
            InitializeComponent();
            CanvasField.Children.Clear();
            labelScore = LabelScore;
            playing = true;

            GridMain.Height = GameSettings.FieldHeight * 50 + 150;
            GridMain.Width = GameSettings.FieldWith * 50 + 70;

            PageMain.Height = GameSettings.FieldHeight * 50 + 150;
            PageMain.Width = GameSettings.FieldWith * 50 + 70;
            MainWindow.mainWindow.Height = GameSettings.FieldHeight * 50 + 150;
            MainWindow.mainWindow.Width = GameSettings.FieldWith * 50 + 70;
            field = new Field(GameSettings.FieldWith, GameSettings.FieldHeight);
            CanvasField.Children.Add(field);
            Canvas.SetLeft(field, 30);

            pauseMenu = new PauseMenu();
            pauseMenu.Visibility = Visibility.Hidden;
            pauseMenu.SetSize();
            CanvasAll.Children.Add(pauseMenu);

            uCLose = new UCLose();
            CanvasAll.Children.Add(uCLose);

            MainWindow.game = new Game();
            MainWindow.game.Start();
        }
    }
}

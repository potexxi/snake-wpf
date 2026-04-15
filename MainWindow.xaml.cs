using Snake.Pages;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Snake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame frame {  get; private set; }
        public static Dictionary<string, Page> pages;
        public static Game game;
        public static string username {  get; set; }
        public static MainWindow mainWindow {  get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            SnakeLogger.init("snake-log-.txt");
            mainWindow = this;
            frame = MainFrame;
            GameSettings.Init(-500, 4, 4, 1);
            pages = new Dictionary<string, Page>();
            pages.Add("menu", new Pages.PageMenu());
            pages.Add("settings", new Pages.PageSettings());
            pages.Add("username", new Pages.PageUserName());
            pages.Add("scoreboard", new Pages.PageScoreboard());
            MainFrame.Navigate(pages["username"]);
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(PageGame.playing == true)
            {
                if (e.Key == Key.Escape)
                {
                    if (PageGame.pauseMenu.Visibility == Visibility.Visible)
                    {
                        PageGame.pauseMenu.Visibility = Visibility.Hidden;
                        game.Continue();
                    }
                    else if (PageGame.pauseMenu.Visibility == Visibility.Hidden)
                    {
                        PageGame.pauseMenu.Visibility = Visibility.Visible;
                        game.Pause();
                    }
                }
                if(e.Key == Key.W)
                {
                    game.snake.ChangeDirection(Direction.Up);
                }
                if (e.Key == Key.A)
                {
                    game.snake.ChangeDirection(Direction.Left);
                }
                if (e.Key == Key.S)
                {
                    game.snake.ChangeDirection(Direction.Down);
                }
                if (e.Key == Key.D)
                {
                    game.snake.ChangeDirection(Direction.Right);
                }
            }
        }
    }
}
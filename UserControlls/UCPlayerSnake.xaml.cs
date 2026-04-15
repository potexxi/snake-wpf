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
    /// Interaction logic for UCPlayerSnake.xaml
    /// </summary>
    public partial class UCPlayerSnake : UserControl
    {
        public static List<UCBodySegment> bodySegmentsUC;
        public static List<Coconut> coconuts;
        public static UCSnakeHead uCSnakeHead;
        public static Canvas CanvasSnake;
        public UCPlayerSnake()
        {
            InitializeComponent();
            CanvasMain.IsHitTestVisible = false;
            CanvasSnake = CanvasMain;
            coconuts = new List<Coconut>();
            RenderOptions.SetBitmapScalingMode(CanvasMain, BitmapScalingMode.LowQuality);
            bodySegmentsUC = new List<UCBodySegment>();
            this.Height = GameSettings.FieldHeight * 50;
            this.Width = GameSettings.FieldWith * 50;
            uCSnakeHead = new UCSnakeHead();
            CanvasMain.Children.Add(uCSnakeHead);
            (int x, int y) = PlayerSnake.bodySegments[0].GetPosition();
            Canvas.SetLeft(uCSnakeHead, x * 50);
            Canvas.SetTop(uCSnakeHead, y * 50);
            for (int i = 1; i < PlayerSnake.bodySegments.Count; i++)
            {
                UCBodySegment uc = new UCBodySegment();
                bodySegmentsUC.Add(uc);
                CanvasMain.Children.Add(uc);
                (int x1, int y1) = PlayerSnake.bodySegments[i].GetPosition();
                Canvas.SetLeft(uc, x1 * 50);
                Canvas.SetTop(uc, y1 * 50);
            }
            for(int i = 0; i < Game.food.Count(); i++)
            {
                Coconut coconut = new Coconut();
                coconuts.Add(coconut);
                CanvasMain.Children.Add(coconut);
                Canvas.SetLeft(coconut, Game.food[i].GetPosition().Item1 * 50);
                Canvas.SetTop(coconut, Game.food[i].GetPosition().Item2 * 50);
            }
        }

        public void Redraw(Direction direction)
        {
            for (int i = 1; i < PlayerSnake.bodySegments.Count; i++)
            {
                (int x1, int y1) = PlayerSnake.bodySegments[i].GetPosition();
                Canvas.SetLeft(bodySegmentsUC[i - 1], x1 * 50);
                Canvas.SetTop(bodySegmentsUC[i - 1], y1 * 50);
            }
            for (int i = 0; i < Game.food.Count; i++)
            {
                Coconut coconut = coconuts[i];
                Canvas.SetLeft(coconut, Game.food[i].GetPosition().Item1 * 50);
                Canvas.SetTop(coconut, Game.food[i].GetPosition().Item2 * 50);
            }
            (int x, int y) = PlayerSnake.bodySegments[0].GetPosition();
            Canvas.SetLeft(uCSnakeHead, x * 50);
            Canvas.SetTop(uCSnakeHead, y * 50);
            uCSnakeHead.SetDirection(direction);
        }
    }
}

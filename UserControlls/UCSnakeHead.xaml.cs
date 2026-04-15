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
    /// Interaktionslogik für UCSnakeHead.xaml
    /// </summary>
    public partial class UCSnakeHead : UserControl
    {
        public UCSnakeHead()
        {
            InitializeComponent();
        }

        public void SetDirection(Direction direction)
        {
            if(direction == Direction.Down)
            {
                RotateTransformSnake.Angle = 90;
            }
            else if(direction == Direction.Left)
            {
                RotateTransformSnake.Angle = 180;
            }
            else if (direction == Direction.Up)
            {
                RotateTransformSnake.Angle = 270;
            }
            else if (direction == Direction.Right)
            {
                RotateTransformSnake.Angle = 0;
            }
        }
    }
}

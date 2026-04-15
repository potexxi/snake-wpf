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
    /// Interaktionslogik für Field.xaml
    /// </summary>
    public partial class Field : UserControl
    {
        public List<List<FieldTile>> fieldTiles;
        public UCPlayerSnake uCPlayerSnake;
        public Field(int fieldWidth, int fieldHeight)
        {
            InitializeComponent();
            fieldTiles = new List<List<FieldTile>>();
            for(int i = 0; i < fieldHeight; i++)
            {
                List<FieldTile> list = new List<FieldTile>();
                for (int t = 0; t < fieldWidth; t++)
                {
                    FieldTile tile = new FieldTile();
                    CanvasMain.Children.Add(tile);
                    list.Add(tile);
                    Canvas.SetLeft(tile, t * 50);
                    Canvas.SetTop(tile, i * 50);
                }
                fieldTiles.Add(list);
            }
        }

        public void SetSegment(Direction direction)
        {
            if(uCPlayerSnake == null)
            {
                uCPlayerSnake = new UCPlayerSnake();
            }
            if (!CanvasMain.Children.Contains(uCPlayerSnake))
            {
                CanvasMain.Children.Add(uCPlayerSnake);
            }
            uCPlayerSnake.Redraw(direction);
        }
    }
}

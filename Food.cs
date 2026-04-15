using Snake.Pages;
using Snake.UserControlls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Snake
{
    public class Food
    {
        private int x;
        private int y;
        private int fieldWidth;
        private int fieldHeight;
        private int index;
        private bool initial;
        public Food(int fieldWidth, int fieldHeight, int index)
        {
            this.fieldHeight = fieldHeight;
            this.fieldWidth = fieldWidth;
            this.index = index;
            initial = true;
            Respawn();
        }

        public void Respawn()
        {
            Random rand = new Random();
            bool noerror = false;
            int counter = 0;
            try
            {
                if ((GameSettings.FieldWith * GameSettings.FieldHeight - PlayerSnake.bodySegments.Count()) < Game.food.Count() && !initial)
                {
                    Game.food.Remove(this);
                    Coconut coconut = UCPlayerSnake.coconuts[index];
                    Canvas.SetLeft(coconut, 100000);
                    x = 10000;
                    y = 10000;
                    //UCPlayerSnake.coconuts.Remove(coconut);
                    UCPlayerSnake.CanvasSnake.Children.Remove(coconut);
                    return;
                }
            }
            catch { }
            while (!noerror)
            {
                int newx = rand.Next(fieldWidth);
                int newy = rand.Next(fieldHeight);

                noerror = true;
                if (PlayerSnake.bodySegments != null)
                {
                    foreach (BodySegment body in PlayerSnake.bodySegments)
                    {
                        if ((newx, newy) == body.GetPosition())
                        {
                            noerror = false;
                            break;
                        }
                    }
                    foreach (Food food in Game.food)
                    {
                        if ((newx, newy) == food.GetPosition())
                        {
                            noerror = false;
                            break;
                        }
                    }
                }
                if (noerror)
                {
                    x = newx;
                    y = newy;
                }
                //counter += 1;
                //if (counter > 3 && !initial && Game.food.Count() != 1)
                //{
                //    Game.food.Remove(this);
                //    Coconut coconut = UCPlayerSnake.coconuts[index];
                //    Canvas.SetLeft(coconut, 10000);
                //    //UCPlayerSnake.coconuts.Remove(coconut);
                //    UCPlayerSnake.CanvasSnake.Children.Remove(coconut);
                //    return;
                //}
                initial = false;
            }

            SnakeLogger.logger.Debug($"Respawn food: {x};{y}");
        }

        public (int, int) GetPosition()
        {
            return (x, y);
        }
    }
}

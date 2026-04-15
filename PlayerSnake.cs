using Snake.Pages;
using Snake.UserControlls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Snake
{
    public class PlayerSnake
    {
        public static List<BodySegment> bodySegments { get; set; }
        public Direction direction { get; set; }
        public bool isAlive { get; set; }
        public int score {  get; set; }
        public PlayerSnake() { }
        public PlayerSnake(int startLenght)
        {
            score = GameSettings.InitialLenght + 1;
            PageGame.labelScore.Content = $"Score: {score}";
            bodySegments = new List<BodySegment>();
            direction = Direction.Up;
            bodySegments.Add(new BodySegment(0, GameSettings.FieldHeight - 2));
            for (int i = 0; i < GameSettings.InitialLenght; i++)
            {
                bodySegments.Add(new BodySegment(i, GameSettings.FieldHeight - 1));
            }
            PageGame.field.SetSegment(direction);
        }

        public void Move()
        {
            (int lasttailx, int lasttaily) = bodySegments[^1].GetPosition();
            if (CheckCollision(direction))
            {
                PageGame.uCLose.Show(score, false);
                isAlive = false;
                MainWindow.game.Pause();
                return;
            }
            for (int i = bodySegments.Count - 1; i > 0; i--)
            {
                (int x, int y) = bodySegments[i - 1].GetPosition();
                bodySegments[i].ChangePosition(x, y);
            }
            if (direction == Direction.Left)
            {
                (int x, int y) = bodySegments[0].GetPosition();
                bodySegments[0].ChangePosition(x - 1, y);
            }
            else if (direction == Direction.Right)
            {
                (int x, int y) = bodySegments[0].GetPosition();
                bodySegments[0].ChangePosition(x + 1, y);
            }
            else if (direction == Direction.Up)
            {
                (int x, int y) = bodySegments[0].GetPosition();
                bodySegments[0].ChangePosition(x, y - 1);
            }
            else if (direction == Direction.Down)
            {
                (int x, int y) = bodySegments[0].GetPosition();
                bodySegments[0].ChangePosition(x, y + 1);
            }
            Grow(lasttailx, lasttaily);
            PageGame.field.SetSegment(direction);
        }

        public void ChangeDirection(Direction direction)
        {
            if (direction == Direction.Up && this.direction != Direction.Down)
            {
                this.direction = direction;
            }
            else if (direction == Direction.Down && this.direction != Direction.Up)
            {
                this.direction = direction;
            }
            else if (direction == Direction.Left && this.direction != Direction.Right)
            {
                this.direction = direction;
            }
            else if (direction == Direction.Right && this.direction != Direction.Left)
            {
                this.direction = direction;
            }
        }

        public void Grow(int x, int y)
        {
            foreach(Food food in Game.food)
            {
                if(food.GetPosition() == bodySegments[0].GetPosition())
                {
                    SnakeLogger.logger.Debug($"Ate coconut: {food.GetPosition()}");
                    score += 1;
                    PageGame.labelScore.Content = $"Score: {score}";
                    bodySegments.Add(new BodySegment(x, y));
                    UCPlayerSnake.bodySegmentsUC.Add(new UCBodySegment());
                    UCPlayerSnake.CanvasSnake.Children.Add(UCPlayerSnake.bodySegmentsUC[^1]);
                    if(score >= (GameSettings.FieldWith * GameSettings.FieldHeight))
                    {
                        PageGame.uCLose.Show(score, true);
                        MainWindow.game.Pause();
                        return;
                    }
                    food.Respawn();
                    return;
                }
            }
        }

        public bool CheckCollision(Direction direction)
        {
            (int x, int y) = bodySegments[0].GetPosition();
            if(this.direction == Direction.Up && y <= 0)
            {
                SnakeLogger.logger.Debug("Snake went in wall.");
                return true;
            }
            else if (this.direction == Direction.Down && (y + 1) >= GameSettings.FieldHeight)
            {
                SnakeLogger.logger.Debug("Snake went in wall.");
                return true;
            }
            else if (this.direction == Direction.Left && x <= 0)
            {
                SnakeLogger.logger.Debug("Snake went in wall.");
                return true;
            }
            else if (this.direction == Direction.Right && (x + 1) >= GameSettings.FieldWith)
            {
                SnakeLogger.logger.Debug("Snake went in wall.");
                return true;
            }
            for (int i = 1; i < bodySegments.Count(); i++)
            {
                if((x, y) == bodySegments[i].GetPosition())
                {
                    SnakeLogger.logger.Debug("Snake went in itself.");
                    return true;
                }
            }
            return false;
        }

        public void Reset()
        {
            SnakeLogger.logger.Debug("Reset game.");
            MainWindow.game = new Game();
        }
    }
}

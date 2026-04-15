using Snake.Pages;
using Snake.UserControlls;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Xml.Linq;

namespace Snake
{
    public class Game
    {
        public PlayerSnake snake;
        public static List<Food> food;
        private int score;
        DispatcherTimer timer;

        public Game()
        {
            PlayerSnake.bodySegments = new List<BodySegment>();
            food = new List<Food>();
            int foodCount = 3;
            if(GameSettings.Difficulty == 2)
            {
                foodCount = 2;
            }
            else if (GameSettings.Difficulty == 3)
            {
                foodCount = 1;
            }
            for (int i = 0; i < foodCount; i++)
            {
                Food food1 = new Food(GameSettings.FieldWith, GameSettings.FieldHeight, i);

                if(food.Count !=1)
                {
                    foreach (Food food2 in food)
                    {
                        while (food2.GetPosition() == food1.GetPosition())
                        {
                            food1.Respawn();
                        }
                    }
                }
                food.Add(food1);
            }
            snake = new PlayerSnake(GameSettings.InitialLenght);
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(GameSettings.Speed * -1);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            var interval = timer.Interval;
            snake.Move();
        }

        public void Start()
        {
            timer.Start();
        }

        public void Update()
        {

        }

        public void Pause()
        {
            timer.Stop();
        }

        public void Reset()
        {
            try
            {
                MainWindow.pages["game"] = new PageGame();
            }
            catch
            {
                MainWindow.pages.Add("game", new PageGame());
            }
            MainWindow.frame.Navigate(MainWindow.pages["game"]);
            SnakeLogger.logger.Information("Started game.");
        }

        public void Continue()
        {
            timer.Start();
        }

        public void SaveToJson()
        {
            SaveData between = new SaveData(PlayerSnake.bodySegments, MainWindow.game.snake.direction, MainWindow.game.snake.isAlive, MainWindow.game.snake.score);
            using(StreamWriter writer = new StreamWriter($"savegame-{MainWindow.username}.snake"))
            {
                writer.Write(JsonSerializer.Serialize(between));
            }
        }

        public void LoadFromJson()
        {
            //MainWindow.game = new Game();
            //var between = { };
            using(StreamReader reader = new StreamReader($"savegame-{MainWindow.username}.snake"))
            {
                SaveData between = JsonSerializer.Deserialize<SaveData>(reader.ReadToEnd());
                MainWindow.game.snake = new PlayerSnake();
                PlayerSnake.bodySegments = between.bodySegments;
                MainWindow.game.snake.direction = between.Direction;
                MainWindow.game.snake.isAlive = between.isAlive;
                MainWindow.game.snake.score = between.score;
            }
            //MainWindow.game.snake = new PlayerSnake();
            //PlayerSnake.bodySegments = between
            //List<BodySegment> bodySegemtns = PlayerSnake.bodySegments;
            UCPlayerSnake.bodySegmentsUC.Clear();
            UCPlayerSnake.CanvasSnake.Children.Clear();
            for (int i = 1; i < PlayerSnake.bodySegments.Count(); i++)
            {
                UCBodySegment uc = new UCBodySegment();
                UCPlayerSnake.bodySegmentsUC.Add(uc);
                UCPlayerSnake.CanvasSnake.Children.Add(uc);
            }
            UCSnakeHead head = new UCSnakeHead();
            UCPlayerSnake.uCSnakeHead = head;
            UCPlayerSnake.CanvasSnake.Children.Add(head);
            foreach(Coconut coc in UCPlayerSnake.coconuts)
            {
                UCPlayerSnake.CanvasSnake.Children.Add(coc);
            }
            PageGame.field.SetSegment(MainWindow.game.snake.direction);
        }
    }
}

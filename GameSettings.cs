using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public static class GameSettings
    {
        public static int Speed;
        public static int FieldWith;
        public static int FieldHeight;
        public static int InitialLenght;
        public static int Difficulty;

        public static void Init(int speed, int fieldWith, int fieldHeight, int difficulty)
        {
            Speed = speed;
            FieldWith = fieldWith;
            FieldHeight = fieldHeight;
            Difficulty = difficulty;
            if(difficulty == 1)
            {
                InitialLenght = (fieldWith / 100) * 30;
                if(InitialLenght <= 0)
                {
                    InitialLenght = 1;
                }
            }
            else if (difficulty == 2)
            {
                InitialLenght = (fieldWith / 100) * 50;
                if (InitialLenght <= 0)
                {
                    InitialLenght = 1;
                }
            }
            else if (difficulty == 3)
            {
                InitialLenght = (fieldWith / 100) * 75;
                if (InitialLenght <= 0)
                {
                    InitialLenght = 1;
                }
            }
        }

        public static void Apply(int speed, int fieldWith, int fieldHeight, int difficulty)
        {
            Speed = speed;
            FieldWith = fieldWith;
            FieldHeight = fieldHeight;
            Difficulty = difficulty;
            if (difficulty == 1)
            {
                InitialLenght = Convert.ToInt32((fieldWith / 100.0) * 30);
                if (InitialLenght <= 0)
                {
                    InitialLenght = 1;
                }
            }
            else if (difficulty == 2)
            {
                InitialLenght = Convert.ToInt32((fieldWith / 100.0) * 50);
                if (InitialLenght <= 0)
                {
                    InitialLenght = 1;
                }
            }
            else if (difficulty == 3)
            {
                InitialLenght = Convert.ToInt32((fieldWith / 100.0) * 75);
                if (InitialLenght <= 0)
                {
                    InitialLenght = 1;
                }
            }
        }
    }
}

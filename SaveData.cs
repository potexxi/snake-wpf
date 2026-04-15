using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class SaveData
    {
        public List<BodySegment> bodySegments { get; set; }
        public Direction Direction {  get; set; }
        public bool isAlive { get; set; }
        public int score { get; set; }
        public int height {  get; set; }
        public int width { get; set; }
        public int difficulty {  get; set; }
        public int initiallenght {  get; set; }
        public int speed {  get; set; }
        public SaveData() { }
        public SaveData(List<BodySegment> bodySegments, Direction direction, bool isAlive, int score)
        {
            this.bodySegments = bodySegments;
            this.isAlive = isAlive;
            this.Direction = direction;
            this.score = score;
            height = GameSettings.FieldHeight;
            width = GameSettings.FieldWith;
            difficulty = GameSettings.Difficulty;
            initiallenght = GameSettings.InitialLenght;
            speed = GameSettings.Speed;
        }
    }
}

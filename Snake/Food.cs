using System;
using System.Drawing;
using System.Linq;

namespace Snake
{
    public class Food
    {
        public Rectangle FoodObj;
        public Food()
        {
            var rnd = new Random();
            var x = rnd.Next(0, 280);
            var y = rnd.Next(30, 200);

            FoodObj = new Rectangle(x, y, 10, 10);
        }

        public void CreateFood()
        {
            var rnd = new Random();
            var x = rnd.Next(0, 280);
            var y = rnd.Next(30, 200);

            FoodObj = new Rectangle(x, y, 10, 10);

            var snakeFood = Snake.GetInstance();
            foreach (var t in snakeFood.SnakeRec.Where(t => FoodObj.IntersectsWith(t)))
            {
                x = rnd.Next(0, 280);
                y = rnd.Next(30, 200);
                FoodObj = new Rectangle(x, y, 10, 10);
            }
        }

        public void MakeFood(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Black), FoodObj);
        }
    }
}

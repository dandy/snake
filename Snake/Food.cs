using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Snake
{
    class Food
    {
        public Rectangle foodObj;

        public Food()
        {
            Random rnd = new Random();
            int x = rnd.Next(0, 280);
            int y = rnd.Next(0, 200);

            foodObj = new Rectangle(x, y, 10, 10);
        }

        public void CreateFood()
        {
            Random rnd = new Random();
            int x = rnd.Next(0, 280);
            int y = rnd.Next(0, 200);

            foodObj = new Rectangle(x, y, 10, 10);

            Snake snakeFood = Snake.getInstance();
            for (int i = 0; i < snakeFood.snakeRec.Length; i++)
            {
                if (foodObj.IntersectsWith(snakeFood.snakeRec[i]))
                {
                     x = rnd.Next(0, 280);
                     y = rnd.Next(0, 200);

                    foodObj = new Rectangle(x, y, 10, 10);
                }
            }

        }

        public void MakeFood(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Black), foodObj);

        }
    }
}

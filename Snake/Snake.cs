using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    class Snake
    {
        public Rectangle[] snakeRec; // snake structure is represented as array of rectangles
        Brush brush;
        int x, y;
        public string currentDirection;
        public int SnakeFormWidth;

        //Making Singleton so that single object is available througout the application
        private static Snake instance = null;
        public static Snake getInstance()
        {
            if (instance == null)
            {
                instance = new Snake();
            }
            return instance;
        }


        public Snake()
        {
            SnakeFormWidth = 0;
            snakeRec = new Rectangle[10];
            x = 50;
            y = 0;
            brush = new SolidBrush(Color.Blue);
            currentDirection = "right";

            for (int i = 0; i < snakeRec.Length; i++)
            {
                if (i == 0)
                {
                    snakeRec[i] = new Rectangle(x, y, 9, 9);

                }
                else
                {
                    snakeRec[i] = new Rectangle(x, y, 9, 9);

                }
                x = x - 10;
            }

        }

        //After snake eats food, the length is increased by one rectangle.
        //Whole snakeRec array is moved one point back and then a new rectangle
        //is inserted in the head with the position coordinates.

        public void IncreaseLength()
        {
            // A new array with +1 length than the current snakeRec array
            Rectangle[] snakeTemp = new Rectangle[snakeRec.Count() + 1];
            int j = 0;
            for (int i = 1; i < snakeTemp.Count(); i++)
            {

                snakeTemp[i] = snakeRec[j];
                j++;
            }
            //New head rectangle, with the same points as the previous HEAD coordinates
            snakeTemp[0] = new Rectangle(snakeRec[0].X, snakeRec[0].Y, 9, 9);

            snakeRec = snakeTemp;


        }

        //Draw is called in on FormPaint event, that draws all the rectangles in the snakeRec array
        public void Draw(Graphics g)
        {
            int i = 0;
            foreach (Rectangle rec in snakeRec)
            {
                if (i == 0)
                {
                    //snake HEAD rectangle is colored white for distinction
                    g.FillRectangle(new SolidBrush(Color.White), rec);
                    i++;
                }
                else
                {
                    g.FillRectangle(new SolidBrush(Color.Red), rec);
                }
            }

        }

        internal void Move(string direction)
        {
            //Save snake rectangles states
            for (int i = snakeRec.Length - 1; i > 0; i--)
            {
                snakeRec[i] = snakeRec[i - 1];
            }

            //Left wall collision detection
            // If collides with left wall, spawn the snake from the right side
            if (snakeRec[0].X - 10 < 0)
            {
                if (direction == "left")
                {
                    snakeRec[0].X = SnakeFormWidth;
                }
            }

            //Right wall collision detection
            //If snake collides with right wall, spawn snake from the left.
            if (snakeRec[0].X + 10 >= SnakeFormWidth)
            {
                if (direction == "right")
                {
                    snakeRec[0].X = -10;
                }
            }

            //Setting snake HEAD to direction. If left the snake HEAD rectangle X is decreased
            if (direction == "left")
            {
                snakeRec[0].X = snakeRec[0].X - 10;
            }
            if (direction == "right")
            {
                snakeRec[0].X = snakeRec[0].X + 10;
            }
            if (direction == "down")
            {
                snakeRec[0].Y = snakeRec[0].Y + 10;
            }
            if (direction == "up")
                snakeRec[0].Y = snakeRec[0].Y - 10;

        }

        internal void Reset()
        {
            SnakeFormWidth = 0;
            snakeRec = new Rectangle[10];
            x = 50;
            y = 0;
            brush = new SolidBrush(Color.Blue);
            currentDirection = "right";

            for (int i = 0; i < snakeRec.Length; i++)
            {
                if (i == 0)
                {
                    snakeRec[i] = new Rectangle(x, y, 9, 9);

                }
                else
                {
                    snakeRec[i] = new Rectangle(x, y, 9, 9);

                }
                x = x - 10;
            }
        }
    }
}


using System.Drawing;
using System.Linq;

namespace Snake
{
    public class Snake
    {
        public Rectangle[] SnakeRec; // snake structure is represented as array of rectangles
        Brush _brush;
        int _x, _y;
        private string _currentDirection;
        public int SnakeFormWidth;
        public int SnakeFormHeight;

        //Making Singleton so that single object is available througout the application
        private static Snake _instance = null;
        public static Snake GetInstance()
        {
            return _instance ?? (_instance = new Snake());
        }

        public Snake()
        {
            SnakeFormWidth = 0;
            SnakeRec = new Rectangle[10];
            _x = 50;
            _y = 0;
            _brush = new SolidBrush(Color.Blue);
            _currentDirection = "right";

            for (var i = 0; i < SnakeRec.Length; i++)
            {
                if (i == 0)
                {
                    SnakeRec[i] = new Rectangle(_x, _y, 9, 9);
                }
                else
                {
                    SnakeRec[i] = new Rectangle(_x, _y, 9, 9);
                }
                _x = _x - 10;
            }

        }

        //After snake eats food, the length is increased by one rectangle.
        //Whole snakeRec array is moved one point back and then a new rectangle
        //is inserted in the head with the position coordinates.

        public void IncreaseLength()
        {
            // A new array with +1 length than the current snakeRec array
            var snakeTemp = new Rectangle[SnakeRec.Count() + 1];
            var j = 0;
            for (var i = 1; i < snakeTemp.Count(); i++)
            {
                snakeTemp[i] = SnakeRec[j];
                j++;
            }
            //New head rectangle, with the same points as the previous HEAD coordinates
            snakeTemp[0] = new Rectangle(SnakeRec[0].X, SnakeRec[0].Y, 9, 9);
            SnakeRec = snakeTemp;
        }

        //Draw is called in on FormPaint event, that draws all the rectangles in the snakeRec array
        public void Draw(Graphics g)
        {
            var i = 0;
            foreach (var rec in SnakeRec)
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
            for (var i = SnakeRec.Length - 1; i > 0; i--)
            {
                SnakeRec[i] = SnakeRec[i - 1];
            }

            //Left wall collision detection
            // If collides with left wall, spawn the snake from the right side
            if (SnakeRec[0].X - 10 < 0)
            {
                if (direction == "left")
                {
                    SnakeRec[0].X = SnakeFormWidth;
                }
            }

            //Right wall collision detection
            //If snake collides with right wall, spawn snake from the left.
            if (SnakeRec[0].X + 10 >= SnakeFormWidth)
            {
                if (direction == "right")
                {
                    SnakeRec[0].X = -10;
                }
            }

            if (SnakeRec[0].Y - 10 < 0)
            {
                if (direction == "up")
                {
                    SnakeRec[0].Y = SnakeFormHeight;
                }
            }

            if (SnakeRec[0].Y + 10 >= SnakeFormHeight)
            {
                if (direction == "down")
                {
                    SnakeRec[0].Y = -10;
                }
            }

            //Setting snake HEAD to direction. If left the snake HEAD rectangle X is decreased
            if (direction == "left")
            {
                SnakeRec[0].X = SnakeRec[0].X - 10;
            }
            if (direction == "right")
            {
                SnakeRec[0].X = SnakeRec[0].X + 10;
            }
            if (direction == "down")
            {
                SnakeRec[0].Y = SnakeRec[0].Y + 10;
            }
            if (direction == "up")
                SnakeRec[0].Y = SnakeRec[0].Y - 10;

        }

        internal void Reset()
        {
            SnakeFormWidth = 0;
            SnakeRec = new Rectangle[10];
            _x = 50;
            _y = 0;
            _brush = new SolidBrush(Color.Blue);
            _currentDirection = "right";

            for (int i = 0; i < SnakeRec.Length; i++)
            {
                if (i == 0)
                    SnakeRec[i] = new Rectangle(_x, _y, 9, 9);
                else SnakeRec[i] = new Rectangle(_x, _y, 9, 9);
                _x = _x - 10;
            }
        }
    }
}

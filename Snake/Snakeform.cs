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
    public partial class Snakeform : Form
    {
        static Snakeform _frmObj;
        string direction = "right";

        public static Snakeform frmObj
        {
            get { return _frmObj; }
            set { _frmObj = value; }
        }

        Scoreboard score = new Scoreboard();
        Graphics paper;
        Snake snake = Snake.GetInstance();
        Food food = new Food();

        public Snakeform()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            snake.SnakeFormWidth = this.ClientRectangle.Width;
            snake.SnakeFormHeight = this.ClientRectangle.Height;
            _frmObj = this;
        }

        private void ResetOptions()
        {
            food = new Food();
            snake = new Snake();
            snake.SnakeFormWidth = this.ClientRectangle.Width;
            snake.SnakeFormHeight = this.ClientRectangle.Height;
            score = new Scoreboard();
            direction = "right";
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            paper = e.Graphics;
            food.MakeFood(paper);
            snake.Draw(paper);
            scoreBox.Text = score.CurrentScore.ToString();
            IfCollidedWithOwnBody();   // A method to check if the snake collides with its own body

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && direction != "up")
            {
                direction = "down";
            }
            else if (e.KeyCode == Keys.Up && direction != "down")
            {
                direction = "up";
            }
            else if (e.KeyCode == Keys.Left && direction != "right")
            {
                direction = "left";
            }
            else if (e.KeyCode == Keys.Right && direction != "left")
            {
                direction = "right";
            }

        }

        public void EatFood()
        {

            if (snake.SnakeRec[0].IntersectsWith(food.FoodObj))
            {
                Console.WriteLine("Food eaten");
                food.CreateFood();
                snake.IncreaseLength();
                score.AddScore();
            }

        }
        // A method for detecting if snake collides with its own body.
        // Result : end game

        public void IfCollidedWithOwnBody()
        {
            for (int i = 2; i < snake.SnakeRec.Length - 1; i++)
            {
                if (snake.SnakeRec[i].IntersectsWith(snake.SnakeRec[0]))
                {
                    ResetOptions();


                  //  timer1.Enabled = false;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (direction == "down")
            {
                snake.Move("down");
                this.Invalidate();
            }
            if (direction == "up")
            {
                snake.Move("up");
                this.Invalidate();
            }
            if (direction == "left")
            {
                snake.Move("left");
                this.Invalidate();
            }
            if (direction == "right")
            {
                snake.Move("right");
                this.Invalidate();
            }
            EatFood();
            this.Invalidate();
        }
    }
}

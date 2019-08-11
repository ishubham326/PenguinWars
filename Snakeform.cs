/* SNAKE
 * June.2015
 * FUN LITTLE MINI GAME INSIDE THE ORIGINAL FOR SOMEONE WHO IS ABLE TO FIND IT
 * Shubham
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Penguin_Wars
{
    public partial class Snake : Form
    {
        //MINI GAME INSIDE ACTUAL GAME!!
        List<SnakePart> snake = new List<SnakePart>();
        const int twidth = 16;
        const int theight = 16;
        bool gameover = false;
        int score = 0;
        int direction = 0; // Down = 0, Left = 1, Right = 2, Up = 3
        SnakePart food = new SnakePart();

        public Snake()
        {
            InitializeComponent();
            tmrMain.Interval = 1000 / 4;
            tmrMain.Tick += new EventHandler(Update);
            tmrMain.Start();
            StartGame();
           
        }
        private void StartGame()
        {
            gameover = false;
            score = 0;
            direction = 0;
            snake.Clear();
            SnakePart head = new SnakePart();
            head.X = 10;
            head.Y = 5;
            snake.Add(head);
            GenerateFood();
        }

        private void GenerateFood()
        {
            int max_tile_w = pbCanvas.Size.Width / twidth;
            int max_tile_h = pbCanvas.Size.Height / theight;
            Random random = new Random();
            food = new SnakePart();
            food.X = random.Next(0, max_tile_w);
            food.Y = random.Next(0, max_tile_h);
        }

        private void Update(object sender, EventArgs e)
        {
            if (gameover)
            {
                if (Input.Pressed(Keys.Enter))
                
                    Application.Exit();
                
            }
            else
            {
                if (Input.Pressed(Keys.Right))
                {
                    if (snake.Count < 2 || snake[0].X == snake[1].X)
                        direction = 2;
                }
                else if (Input.Pressed(Keys.Left))
                {
                    if (snake.Count < 2 || snake[0].X == snake[1].X)
                        direction = 1;
                }
                else if (Input.Pressed(Keys.Up))
                {
                    if (snake.Count < 2 || snake[0].Y == snake[1].Y)
                        direction = 3;
                }
                else if (Input.Pressed(Keys.Down))
                {
                    if (snake.Count < 2 || snake[0].Y == snake[1].Y)
                        direction = 0;
                }
                UpdateSnake();
            }
            pbCanvas.Invalidate();
        }

        private void UpdateSnake()
        {
            for (int i = snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (direction)
                    {
                        case 0: // Down
                            snake[i].Y++;
                            break;
                        case 1: // Left
                            snake[i].X--;
                            break;
                        case 2: // Right
                            snake[i].X++;
                            break;
                        case 3: // Up
                            snake[i].Y--;
                            break;
                    }
                    int maxtwidth = pbCanvas.Width / twidth;
                    int maxtheight = pbCanvas.Height / theight;
                    if (snake[i].X < 0 || snake[i].X >= maxtwidth || snake[i].Y < 0 || snake[i].Y >= maxtheight)
                        gameover = true;
                    for (int j = 1; j < snake.Count; j++)
                        if (snake[i].X == snake[j].X && snake[i].Y == snake[j].Y)
                            gameover = true;
                    if (snake[i].X == food.X && snake[i].Y == food.Y)
                    {
                        SnakePart part = new SnakePart();
                        part.X = snake[snake.Count - 1].X;
                        part.Y = snake[snake.Count - 1].Y;
                        snake.Add(part);
                        GenerateFood();
                        score++;
                    }
                }
                else
                {
                    snake[i].X = snake[i - 1].X;
                    snake[i].Y = snake[i - 1].Y;
                }
            }
        }
        private void Snake_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }

        private void Snake_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
            if (gameover)
            {
                if (Input.Pressed(Keys.Enter))

                    Application.Exit();
            }
        }

        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            if (gameover)
            {
                Font font = this.Font;
                string govermsg = "Gameover";
                string scoremsg = "Score: " + score.ToString();
                string endgamemsg = "Press Enter to Quit";
                int ctrWidth = pbCanvas.Width / 2;
                SizeF msgsize = canvas.MeasureString(govermsg, font);
                PointF msgplace = new PointF(ctrWidth - msgsize.Width / 2, 16);
                canvas.DrawString(govermsg, font, Brushes.Black, msgplace);
                msgsize = canvas.MeasureString(scoremsg, font);
                msgplace = new PointF(ctrWidth - msgsize.Width / 2, 32);
                canvas.DrawString(scoremsg, font, Brushes.Black, msgplace);
                msgsize = canvas.MeasureString(endgamemsg, font);
                msgplace = new PointF(ctrWidth - msgsize.Width / 2, 48);
                canvas.DrawString(endgamemsg, font, Brushes.Black, msgplace);
            }
            else
            {
                for (int i = 0; i < snake.Count; i++)
                {
                    Brush scolour = i == 0 ? Brushes.Yellow : Brushes.Black;
                    canvas.FillRectangle(scolour, new Rectangle(snake[i].X * twidth, snake[i].Y * theight, twidth, theight));
                }
                canvas.FillRectangle(Brushes.White, new Rectangle(food.X * twidth, food.Y * theight, twidth, theight));
                canvas.DrawString("Score: " + score.ToString(), this.Font, Brushes.White, new PointF(4, 4));
            }
        }
        


        private void Snake_Load(object sender, EventArgs e)
        {

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {

        }
    }
}

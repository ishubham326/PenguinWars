/* PENGUIN WARS
 * Written by Mr. Trink, Shubham Shukla with help from Albert :p & graphics by Mitchell Irvine and Shubham Shukla
 * Moral support - Clark
 * June.2015
 * A fun and simple top down shooter game called Penguin Wars with access to a hidden mini game!!! :p 
 * ******************** See if you can find it without looking at the code **********************
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
using System.Media;
namespace Penguin_Wars
{
    public partial class Form1key : Form
    {        
        List<Rectangle> walls = new List<Rectangle>(); //Creates a list of rectangles called walls

        public enum SHOTDIR{UP,LEFT,RIGHT,DOWN}; //DIRECTIONS FOR SNOWBALLS TO GO

        SHOTDIR p1Dir = SHOTDIR.UP;
        SHOTDIR p2Dir = SHOTDIR.DOWN;

        private SoundPlayer song1, song2, winnersound; //Variables for sounds throughout the game
        Image title = Properties.Resources.Title_Screen; //Variable for title screen image, assigned
        Image map = Properties.Resources.Complete_Map;  //^
        //Player 1 Images (Movement)
        Image StnUpO, StnDownO, LeftO, RightO, StnUpG, StnDownG, RightG, LeftG, StnUpB, StnDownB, RightB, LeftB, StnUpR, StnDownR, RightR, LeftR; 
        //Player 2 Images (Movement)
        Image StnUpO2, StnDownO2, LeftO2, RightO2, StnUpG2, StnDownG2, RightG2, LeftG2, StnUpB2, StnDownB2, RightB2, LeftB2, StnUpR2, StnDownR2, RightR2, LeftR2;
        Image ScrPaused = Properties.Resources.ScrPaused; //variable for paused screen image, assigned
        Image die1, die2, life1, life2; //Images for healths ofr penguins

        int mode = 0; //integers for modes 
        const int MENU = 0;//^
        const int GAMEPLAY = 1;//^^
        const int CHARACTER = 2;//^^^
        const int GAMEOVER = 3; //^^^^
        int colour = 0; //Integers for colours of penguins at character selection page (Player 1)
        const int red = 0; //^
        const int blue = 1; //^^
        const int orange = 2; //^^^
        const int green = 3; //^^^^
        int colour2 = 0; //Integers for colours of penguins at character selection page (Player 2)
        const int red2 = 0; //^
        const int blue2 = 1;//^^
        const int orange2 = 2; //^^^
        const int green2 = 3; //^^^^
        int snowcounter1 = 0; //Snowball counter (Player 1)
        int snowcounter2 = 0; //Snowball counter (Player 2)
        int lives1 = 5; //Healths (Player 1)
        int lives2 = 5; //Healths (Player 2)
        int counter1 = 0; //Counter for penguin selection (Player 1)
        int counter2 = 0; //Counter for penguin selection (Player 2)
        int winner = 0; //integer to assign winner for winner declaration
        const int win1 = 1; //Winner (Player 1)
        const int win2 = 2; //Winner (Player 2)
        Rectangle p1 = new Rectangle(125, 110, 25, 25); //Rectangle (Player 1)
        Rectangle p2 = new Rectangle(440, 275, 25, 25); //Rectangle (Player 2)

        //Rectangles to display number of lives in GAMEPLAY mode (Player 1)
        Rectangle l1p1 = new Rectangle(58, 347, 30, 30);
        Rectangle l2p1 = new Rectangle(88, 347, 30, 30);
        Rectangle l3p1 = new Rectangle(118, 347, 30, 30);
        Rectangle l4p1 = new Rectangle(148, 347, 30, 30);
        Rectangle l5p1 = new Rectangle(178, 347, 30, 30);

        //Rectangles to display number of lives in GAMEPLAY mode (Player 2)
        Rectangle l1p2 = new Rectangle(667, 347, 30, 30);
        Rectangle l2p2 = new Rectangle(637, 347, 30, 30);
        Rectangle l3p2 = new Rectangle(607, 347, 30, 30);
        Rectangle l4p2 = new Rectangle(577, 347, 30, 30);
        Rectangle l5p2 = new Rectangle(547, 347, 30, 30);


        int dx = 2; //Integer to be used for movement (X)
        int dy = 2; //Integer to be used for movement (Y)


        List<Snowball> mySnowBalls = new List<Snowball>(); //List for snowballs that will appear (Player 1)
        List<Snowball> mySnowBalls2 = new List<Snowball>(); //Second List for snowballs that will appear (Player 2)
        KeyboardController kbc; //Class access, variable, for movement of penguins using keys and class
        int x = 0; //Integer

        
        public Form1key()
        {
            InitializeComponent(); 

            kbc = new KeyboardController(this);
            kbc.KeyboardTick += HandleKeyboardTick;
            
            InitializeComponent();
            mode = MENU; //assigns mode

            //Movement Images Assigned (Player 1)
            StnUpO = Properties.Resources.StnUpO;
            StnDownO = Properties.Resources.StnDownO;
            LeftO = Properties.Resources.LeftO;
            RightO = Properties.Resources.RightO;
            StnUpB = Properties.Resources.StnUpB;
            StnDownB = Properties.Resources.StnDownB;
            LeftB = Properties.Resources.LeftB;
            RightB = Properties.Resources.RightB;
            StnUpG = Properties.Resources.StnUpG;
            StnDownG = Properties.Resources.StnDownG;
            LeftG = Properties.Resources.LeftG;
            RightG = Properties.Resources.RightG;
            StnUpR = Properties.Resources.StnUpR;
            StnDownR = Properties.Resources.StnDownR;
            LeftR = Properties.Resources.LeftR;
            RightR = Properties.Resources.RightR;

            //Movement Images Assigned (Player 2)
            StnUpO2 = Properties.Resources.StnUpO2;
            StnDownO2 = Properties.Resources.StnDownO2;
            LeftO2 = Properties.Resources.LeftO2;
            RightO2 = Properties.Resources.RightO2;
            StnUpB2 = Properties.Resources.StnUpB2;
            StnDownB2 = Properties.Resources.StnDownB2;
            LeftB2 = Properties.Resources.LeftB2;
            RightB2 = Properties.Resources.RightB2;
            StnUpG2 = Properties.Resources.StnUpG2;
            StnDownG2 = Properties.Resources.StnDownG2;
            LeftG2 = Properties.Resources.LeftG2;
            RightG2 = Properties.Resources.RightG2;
            StnUpR2 = Properties.Resources.StnUpR2;
            StnDownR2 = Properties.Resources.StnDownR2;
            LeftR2 = Properties.Resources.LeftR2;
            RightR2 = Properties.Resources.RightR2;

            
            //Images assigned to variables for healths to be displayed
            life1 = Properties.Resources.Life1c;
            life2 = Properties.Resources.Life2c;
            die1 = Properties.Resources.Life1;
            die2 = Properties.Resources.Life2;

            
            //Rectangles added to list: walls
            walls.Add(new Rectangle(57, 20, 11, 324));
            walls.Add(new Rectangle(57, 20, 60, 46));
            walls.Add(new Rectangle(588, 300, 106, 45));
            walls.Add(new Rectangle(67, 181, 103, 4));
            walls.Add(new Rectangle(67, 141, 103, 4));
            walls.Add(new Rectangle (111, 102, 59, 4));
            walls.Add(new Rectangle(57, 21, 643, 5));
            walls.Add(new Rectangle(692, 20, 3, 324));
            walls.Add(new Rectangle(57, 341, 643, 3));
            walls.Add(new Rectangle(113, 221, 5, 44));
            walls.Add(new Rectangle(164, 62, 59, 3));
            walls.Add(new Rectangle(375, 300, 58, 39));
            walls.Add(new Rectangle(165, 105, 3, 36));
            walls.Add(new Rectangle(218, 142, 3, 40));
            walls.Add(new Rectangle(219, 142, 54, 4));
            walls.Add(new Rectangle(271, 142, 4, 43));
            walls.Add(new Rectangle(65, 300, 210, 4)); 
            walls.Add(new Rectangle(165, 223, 4, 79)); 
            walls.Add(new Rectangle(165, 222, 108, 3)); 
            walls.Add(new Rectangle(216, 223, 4, 41)); 
            walls.Add(new Rectangle(270, 223, 4, 41));
            walls.Add(new Rectangle(217, 101, 52, 4)); 
            walls.Add(new Rectangle(271, 62, 3, 40)); 
            walls.Add(new Rectangle(272, 62, 108, 3)); 
            walls.Add(new Rectangle(536, 27, 57, 36));
            walls.Add(new Rectangle(323, 67, 3, 36)); 
            walls.Add(new Rectangle(330, 102, 49, 3)); 
            walls.Add(new Rectangle(376, 107, 3, 36)); 
            walls.Add(new Rectangle(325, 141, 49, 4));
            walls.Add(new Rectangle(431, 102, 53, 3)); 
            walls.Add(new Rectangle(481, 106, 3, 37)); 
            walls.Add(new Rectangle(430, 142, 53, 3)); 
            walls.Add(new Rectangle(324, 182, 3, 42)); 
            walls.Add(new Rectangle(328, 181, 156, 3));
            walls.Add(new Rectangle(377, 185, 3, 75)); 
            walls.Add(new Rectangle(324, 261, 214, 3));
            walls.Add(new Rectangle(324, 300, 48, 3)); 
            walls.Add(new Rectangle(430, 223, 3, 75)); 
            walls.Add(new Rectangle(482, 263, 3, 38)); 
            walls.Add(new Rectangle(485, 300, 53, 3)); 
            walls.Add(new Rectangle(640, 181, 53, 3)); 
            walls.Add(new Rectangle(641, 185, 3, 39));
            walls.Add(new Rectangle(430, 62, 104, 3)); 
            walls.Add(new Rectangle(536, 63, 3, 79)); 
            walls.Add(new Rectangle(589, 63, 3, 79)); 
            walls.Add(new Rectangle(590, 102, 51, 3)); 
            walls.Add(new Rectangle(641, 63, 3, 39)); 
            walls.Add(new Rectangle(591, 141, 52, 3)); 
            walls.Add(new Rectangle(482, 222, 54, 3)); 
            walls.Add(new Rectangle(536, 183, 4, 39)); 
            walls.Add(new Rectangle(540, 181, 51, 3)); 
            walls.Add(new Rectangle(588, 182, 3, 80));
            walls.Add(new Rectangle(594, 260, 50, 4));
            walls.Add(new Rectangle(641, 265, 4, 34)); 

            //Sound file assigned to variables to be used later
            song1 = new SoundPlayer("Little Sound.wav");
            song2 = new SoundPlayer("Funky Element.wav");
            //noot = new SoundPlayer("Pingu Noise.wav");
            winnersound = new SoundPlayer("Winner.wav");
           
        }
   
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            Graphics g = e.Graphics;

            if (mode == GAMEOVER)
            { // when mode is gameover (when game ends), a button will hide and another (to exit) will appear
                btnIcon.Visible = false; //Hides
                btnover.Visible = true; //Appears
            }

            //Spawning of player (Player 1)
            if (mode == GAMEPLAY)
            { //when mode is gameplay, based on what character was selected, selection will appear
                if (colour == red)
                { //red penguin spawns
                    g.DrawImage(StnUpR, p1); //draws red penguin inside rectangle for player 1
                }
                else if (colour == orange)
                { //orange penguin spawns
                    g.DrawImage(StnUpO, p1);
                }
                else if (colour == green)
                {//green penguin spawns
                    g.DrawImage(StnUpG, p1);
                }
                else if (colour == blue)
                {//blue player spawns
                    g.DrawImage(StnUpB, p1);
                }

               /* In case walls need to be corrected, this displays the rectangles
                foreach (Rectangle r in walls)
                {
                    g.FillRectangle(new SolidBrush (Color.FromArgb (65, 255,0,0)), r);
                }
                */

                //Spawning of player (Player 2)
                if (colour2 == red2)
                {//red penguin spawns
                    g.DrawImage(StnDownR2, p2); //draws red penguin inside rectangle for player 1
                }
                else if (colour2 == orange2)
                {//orange player spawns
                    g.DrawImage(StnDownO2, p2);
                }
                else if (colour2 == green2)
                {//green player spawns
                    g.DrawImage(StnDownG2, p2);
                }
                else if (colour2 == blue2)
                {//blue player spawns
                    g.DrawImage(StnDownB2, p2);
                }
            }

            //To draw snowballs using class
            //(Player 1)
            foreach (Snowball sb in mySnowBalls)
                { 
                    sb.Draw(g);
                }

            //(Player 2)
            foreach (Snowball sb2 in mySnowBalls2)
            {
                sb2.Draw(g);
            }

            //When mode switches to gameplay (When the actual game starts) This draws the lives according to the amount left
            if (mode == GAMEPLAY)
            {
                //LIVES OF PLAYER 2
                    if (lives2 == 5)
                    { //Draws all 5 coloured lives
                        g.DrawImage(life2, l1p2);
                        g.DrawImage(life2, l2p2);
                        g.DrawImage(life2, l3p2);
                        g.DrawImage(life2, l4p2);
                        g.DrawImage(life2, l5p2);
                    }
                    else if (lives2 == 4)
                    { //When hit once, 4 coloured lives and 1 black and white
                        g.DrawImage(die2, l1p2);
                        g.DrawImage(life2, l2p2);
                        g.DrawImage(life2, l3p2);
                        g.DrawImage(life2, l4p2);
                        g.DrawImage(life2, l5p2);
                    }
                    else if (lives2 == 3)
                    { //When hit twice, 3 coloured lives and 2 black and white
                        g.DrawImage(die2, l1p2);
                        g.DrawImage(die2, l2p2);
                        g.DrawImage(life2, l3p2);
                        g.DrawImage(life2, l4p2);
                        g.DrawImage(life2, l5p2);
                    }
                    else if (lives2 == 2)
                    {
                        g.DrawImage(die2, l1p2);
                        g.DrawImage(die2, l2p2);
                        g.DrawImage(die2, l3p2);
                        g.DrawImage(life2, l4p2);
                        g.DrawImage(life2, l5p2);
                    }
                    else if (lives2 == 1)
                    {
                        g.DrawImage(die2, l1p2);
                        g.DrawImage(die2, l2p2);
                        g.DrawImage(die2, l3p2);
                        g.DrawImage(die2, l4p2);
                        g.DrawImage(life2, l5p2);
                    }
                     
                //LIVES OF PLAYER 1
                    if (lives1 == 5)
                    {
                        g.DrawImage(life1, l1p1);
                        g.DrawImage(life1, l2p1);
                        g.DrawImage(life1, l3p1);
                        g.DrawImage(life1, l4p1);
                        g.DrawImage(life1, l5p1);
                    }
                    else if (lives1 == 4)
                    {
                        g.DrawImage(life1, l1p1);
                        g.DrawImage(life1, l2p1);
                        g.DrawImage(life1, l3p1);
                        g.DrawImage(life1, l4p1);
                        g.DrawImage(die1, l5p1);
                    }
                    else if (lives1 == 3)
                    {
                        g.DrawImage(life1, l1p1);
                        g.DrawImage(life1, l2p1);
                        g.DrawImage(life1, l3p1);
                        g.DrawImage(die1, l4p1);
                        g.DrawImage(die1, l5p1);
                    }
                    else if (lives1 == 2)
                    {
                        g.DrawImage(life1, l1p1);
                        g.DrawImage(life1, l2p1);
                        g.DrawImage(die1, l3p1);
                        g.DrawImage(die1, l4p1);
                        g.DrawImage(die1, l5p1);
                    }
                    else if (lives1 == 1)
                    {
                        g.DrawImage(life1, l1p1);
                        g.DrawImage(die1, l2p1);
                        g.DrawImage(die1, l3p1);
                        g.DrawImage(die1, l4p1);
                        g.DrawImage(die1, l5p1);
                    }
                }
            
            //When mode is menu, meaning title screen, two buttons become visible
            if (mode == MENU)
            {
                btnExit.Visible = true; //Appear
                btnStart.Visible = true; //Appear
            }            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {//When in menu and start button is clicked... 
            
            mode = CHARACTER; //changes mode to gameplay
            btnExit.Visible = false; //Hides
            btnStart.Visible = false; //Hides
            btnRed1.Visible = true; //Appears
            btnBlue1.Visible = true; //Appears
            btnGreen1.Visible = true; //Appears
            btnOrange1.Visible = true; //Appears
            btnRed2.Visible = true; //Appears
            btnBlue2.Visible = true; //Appears
            btnGreen2.Visible = true; //Appears
            btnOrange2.Visible = true; //Appears
            
            Form1key.ActiveForm.Focus(); //Keeps the form
            Form1key.ActiveForm.BackgroundImage = Properties.Resources.Selection; //Changes backgroud to a Selection screen
            song1.Play(); //Song 1 starts playing 
        }

        private void btnover_Click(object sender, EventArgs e)
        {//Game Over button
            Application.Exit(); //Exits form when clicked

        }   


        private void btnExit_Click(object sender, EventArgs e)
        {//exit button
            Application.Exit(); //Exits form when clicked

        }

        private bool HitWall(Rectangle penguin)
        {//bool function to check pengun running into wall
            bool hitWall = false;  //set to false

            foreach (Rectangle r in walls) //for all the rectangles in the list walls
            {
                if (penguin.IntersectsWith(r)) hitWall = true; //if rectangle intersencts, boo changes to true
            }

            return hitWall; //returns situation
        }

        private void HandleKeyboardTick(object sender, EventArgs e)
        {
            //MOVEMENT FOR PLAYER 1

            if (kbc.KeyDown(Keys.W))
            { //When W is pressed
                StnUpO = Properties.Resources.StnUpO; //goes back to resources to fetch image, orange penguin
                StnUpR = Properties.Resources.StnUpR; //red penguin
                StnUpB = Properties.Resources.StnUpB; //blue penguin
                StnUpG = Properties.Resources.StnUpG; //green penguin
                p1.Y -= dy; //when W is pressed, dy is subtracted from p1 point, allowing movement upwards

                p1Dir = SHOTDIR.UP; //Direction teh snowball needs to be shot at is switched to up 

                if (HitWall(p1)) 
                { //if player 1 comes across a wall
                    p1.Y += dy; //dy is added on to it again
                }

            }
          
            else if (kbc.KeyDown(Keys.A))
            { //Left movement
                p1Dir = SHOTDIR.LEFT;
                StnUpO = LeftO;
                StnUpR = LeftR;
                StnUpB = LeftB;
                StnUpG = LeftG;
                p1.X -= dx;
                
                if (HitWall(p1))
                {
                    p1.X += dx;
                }
            }
            else if (kbc.KeyDown(Keys.D))
            { //right movement
                p1Dir = SHOTDIR.RIGHT;
                StnUpO = RightO;
                StnUpR = RightR;
                StnUpB = RightB;
                StnUpG = RightG;
                p1.X += dx;
                
                if (HitWall(p1))
                {
                    p1.X -= dx;
                }
            }
            else if (kbc.KeyDown(Keys.S))
            { //down movement
                p1Dir = SHOTDIR.DOWN;
                StnUpO = StnDownO;
                StnUpR = StnDownR;
                StnUpB = StnDownB;
                StnUpG = StnDownG;
                p1.Y += dy;
                

                if (HitWall(p1))
                {
                    p1.Y -= dy;
                }

            }
            if (kbc.KeyDown(Keys.Q))
            { //to shoot
                
                if (mySnowBalls.Count == 0) // when the counter for snowballs present is 0
                mySnowBalls.Add(new Snowball(Color.White, p1.X+13, p1.Y+13, p1Dir, 1)); //adds a snowball                
            }

           //MOVEMENT FOR OTEHR PLAYER
            if (kbc.KeyDown(Keys.I))
            { //Upwards movement
                p2Dir = SHOTDIR.UP;
                StnDownO2 = StnUpO2;
                StnDownR2 = StnUpR2;
                StnDownB2 = StnUpB2;
                StnDownG2 = StnUpG2;
                p2.Y -= dy;

                if (HitWall(p2))
                {//in case it comes across a wall, adds dy 
                    p2.Y += dy;
                }
            }
            else if (kbc.KeyDown(Keys.J))
            {//Left movement
                p2Dir = SHOTDIR.LEFT;
                StnDownO2 = LeftO2;
                StnDownR2 = LeftR2;
                StnDownB2 = LeftB2;
                StnDownG2 = LeftG2;
                p2.X -= dx;               

                if (HitWall(p2))
                {
                    p2.X += dx;
                }
            }
            else if (kbc.KeyDown(Keys.L))
            {//Left movement
                p2Dir = SHOTDIR.RIGHT;
                StnDownO2 = RightO2;
                StnDownR2 = RightR2;
                StnDownB2 = RightB2;
                StnDownG2 = RightG2;
                p2.X += dx;
               
                if (HitWall(p2))
                {
                    p2.X -= dx;
                }
            }
            else if (kbc.KeyDown(Keys.K))
            {//Down movement
                p2Dir = SHOTDIR.DOWN;
                StnDownO2 = Properties.Resources.StnDownO2;
                StnDownR2 = Properties.Resources.StnDownR2;
                StnDownB2 = Properties.Resources.StnDownB2;
                StnDownG2 = Properties.Resources.StnDownG2;
                p2.Y += dy;
                
                if (HitWall(p2))
                {
                    p2.Y -= dy;
                }
            }

            if (kbc.KeyDown(Keys.V))
            {//To Shoot

                if (mySnowBalls2.Count == 0)
                mySnowBalls2.Add(new Snowball(Color.White, p2.X + 13, p2.Y + 13, p2Dir, 2));                
            }

           this.Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        { 

        }

        private void timer1_Tick(object sender, EventArgs e)
        {      
            Rectangle screenBoundary=new Rectangle (0,0,this.Width,this.Height );
            List<Snowball> toMelt=new List<Snowball >(); //to destray snowballs, accesses class

            foreach (Snowball sb in mySnowBalls)
            { //performs this for snowball for player 1
                bool meltMe = false;
                sb.Update();

                foreach (Rectangle wally in walls)
                { //if collision with wall
                    if (sb.CollidesWith(wally))
                    {
                        meltMe = true; //destroys snowball
                        break;
                    }
                }
                if (!sb.CollidesWith(screenBoundary)||meltMe) toMelt.Add(sb);
            }
            foreach (Snowball sb2 in mySnowBalls2)
            {//performs this for snowballs for player 2
                bool meltMe = false;
                sb2.Update();

                foreach (Rectangle wally in walls)
                {
                    if (sb2.CollidesWith(wally))
                    {
                        meltMe = true;
                        break;
                    }
                }
                if (!sb2.CollidesWith(screenBoundary) || meltMe) toMelt.Add(sb2);
            }

            foreach (Snowball sb in toMelt)
            { //removes snowballs player 1
                mySnowBalls.Remove(sb);
            }
            foreach (Snowball sb2 in toMelt)
            {//removes snowball player 2
                mySnowBalls2.Remove(sb2);
            }

            //Check if penguin 1's snowballs have hit pengin 2
            foreach (Snowball sb in mySnowBalls)
            {
                if (sb.GetPenguinNumber() == 1)
                {
                    if (sb.CollidesWith(p2))
                    {
                        //Penguin 1 has hit penguin 2
                        //tmrMain.Stop();
                        toMelt.Add(sb);
                        lives2--;
                        if (lives2 == 0)
                        {
                            mode = GAMEOVER;
                            winner = win1;
                            winnersound.Play();
                            if (winner == win1)
                            {
                                Form1key.ActiveForm.Focus();
                                //keeps the form
                                Form1key.ActiveForm.BackgroundImage = Properties.Resources.GAMEOVER1;

                            }
                            else if (winner == win2)
                            {
                                Form1key.ActiveForm.Focus();

                                Form1key.ActiveForm.BackgroundImage = Properties.Resources.GAMEOVER2;
                            }
                        }

                    }
                }
            }
            foreach (Snowball sb2 in mySnowBalls2)
            {
                if (sb2.GetPenguinNumber() == 2)
                { //for hits
                    if (sb2.CollidesWith(p1))
                    {                       
                        //Penguin 2 has hit penguin 1
                        toMelt.Add(sb2);
                        lives1--;
                        if (lives1 == 0)
                        {
                            mode = GAMEOVER; //changes mode to game over when a penguin reaches 0 lives
                            winner = win2; //winner is player 2 in this case
                            winnersound.Play(); //plays winner sound
                            if (winner == win1) 
                            {//when winner is player 1, this is displayed
                                Form1key.ActiveForm.Focus();
                                //keeps the form
                                Form1key.ActiveForm.BackgroundImage = Properties.Resources.GAMEOVER1;

                            }
                            else if (winner == win2)
                            {//is winner is player 2, this is displayed
                                Form1key.ActiveForm.Focus();

                                Form1key.ActiveForm.BackgroundImage = Properties.Resources.GAMEOVER2;
                            }
                        }
                    }
                    
                }
               

                }
            foreach (Snowball sb in toMelt)
            {//removes snowballs
                mySnowBalls.Remove(sb);
            }

            foreach (Snowball sb2 in toMelt)
            {
                mySnowBalls2.Remove(sb2);
            }
            this.Invalidate();
        }
    
        //ALL FOR SELECTION OF CHARACTER
        //PLAYER 1 SELECTION
        public void btnRed1_Click(object sender, EventArgs e)
        {//when red player is clicked
            colour = red; //colour gets assigned red
            counter1++; //adds one to
            if (counter1 == 2)
            {//if another player is selected, and counter value is 2
                counter1 = 1; //changes value back to back
            }
            if (counter1 == 1 && counter2 == 1)
            { //button for starting the game becomes visible as soon as both counters, for player 1 and 2 are equal to 1
                btnStart2.Visible = true;
            }
        }

        public void btnOrange1_Click(object sender, EventArgs e)
        {//orange player 1
            colour = orange;
            counter1++;
            if (counter1 == 2)
            {
                counter1 = 1;
            }
            if (counter1 == 1 && counter2 == 1)
            {
                btnStart2.Visible = true;
            }
        }

        public void btnGreen1_Click(object sender, EventArgs e)
        {//green player 1
            colour = green;
            counter1++;
            if (counter1 == 2)
            {
                counter1 = 1;
            }
            if (counter1 == 1 && counter2 == 1)
            {
                btnStart2.Visible = true;
            }
        }

        public void btnBlue1_Click(object sender, EventArgs e)
        {//blue player 1
            colour = blue;
            counter1++;
            if (counter1 == 2)
            {
                counter1 = 1;
            }
            if (counter1 == 1 && counter2 == 1)
            {
                btnStart2.Visible = true;
            }
        }
        //CHARACTERS FOR PLAYER 2
        public void btnBlue2_Click(object sender, EventArgs e)
        {
            colour2 = blue2;
            counter2++;
            if (counter2 == 2)
            {
                counter2 = 1;
            }
            if (counter1 == 1 && counter2 == 1)
            {
                btnStart2.Visible = true;
            }
        }

        public void btnGreen2_Click(object sender, EventArgs e)
        {
            colour2 = green2;
            counter2++;
            if (counter2 == 2)
            {
                counter2 = 1;
            }
            if (counter1 == 1 && counter2 == 1)
            {
                btnStart2.Visible = true;
            }
        }
        public void btnOrange2_Click(object sender, EventArgs e)
        {
            colour2 = orange2;
            counter2++;
            if (counter2 == 2)
            {
                counter2 = 1;
            }
            if (counter1 == 1 && counter2 == 1)
            {
                btnStart2.Visible = true;
            }
        }

        public void btnRed2_Click(object sender, EventArgs e)
        {
            colour2 = red2;
            counter2++;
            if (counter2 == 2)
            {
                counter2 = 1;
            }
            if (counter1 == 1 && counter2 == 1)
            {
                btnStart2.Visible = true;
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {//When start button at selection screen is pressed
            mode = GAMEPLAY;
            btnRed1.Visible = false; //hides button
            btnBlue1.Visible = false; //hides button
            btnGreen1.Visible = false; //hides button
            btnOrange1.Visible = false; //hides button
            btnRed2.Visible = false; //hides button
            btnBlue2.Visible = false; //hides button
            btnGreen2.Visible = false; //hides button
            btnOrange2.Visible = false; //hides button
            btnStart2.Visible = false; 
            btnIcon.Visible = true; //visible
            Form1key.ActiveForm.Focus(); //keeps the form
            Form1key.ActiveForm.BackgroundImage = Properties.Resources.Complete_Map; //changes the background to map
            song1.Stop(); //song 1 stops playing
            song2.PlayLooping(); //2 starts playing in a loop

        }
        
        private void Form1key_MouseMove(object sender, MouseEventArgs e)
        {
            //USED TO DETERMINE COORDINATES ON THE FORM
           // pointLabel.Text = "X: " + e.Location.X + " Y: " + e.Location.Y;
        }

        private void btnIcon_Click(object sender, EventArgs e)
            {//when this button is pressed
                this.Hide(); //current form is closed
            //new form starts up 
                var snake = new Snake(); 
                snake.Closed += (s, args) => this.Close(); 
                snake.Show();
            }

       
        }


        }
    

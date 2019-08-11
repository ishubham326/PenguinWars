using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Penguin_Wars
{
    public class Snowball
    {
        Brush myBrush;
        int curX;
        int curY;
        int dX;
        int dY;
        int myPenguin;
        Rectangle myBounds;

        

        public Snowball(Color myColour, int startX, int startY,Form1key.SHOTDIR direction, int penguinNumber)
        {
            myPenguin = penguinNumber;
            myBrush = new SolidBrush(myColour);
            this.curX = startX;
            this.curY = startY;

            switch (direction)
            {
                case Form1key.SHOTDIR.UP:
                    this.dX = 0;
                    this.dY = -10;
                    break;
                case Form1key.SHOTDIR.DOWN:
                    this.dX = 0;
                    this.dY = 10;
                    break;
                case Form1key.SHOTDIR.LEFT:
                    this.dX = -10;
                    this.dY = 0;
                    break;
                case Form1key.SHOTDIR.RIGHT:
                    this.dX = 10;
                    this.dY = 0;
                    break;
                default:
                    //do nothing
                    break;

            }
            
            SetBounds();   
        }

        public void Update()
        {
            curX += dX;
            curY += dY;
            SetBounds();
        }

        public bool CollidesWith(Rectangle screenBoundary)
        {
            return screenBoundary.IntersectsWith(myBounds);
        }

        private void SetBounds(){
            this.myBounds =new Rectangle (curX-5,curY-5,7,7);
        }

        public void Draw(Graphics g)
        {
            g.FillEllipse(myBrush, myBounds); 
        }

        public int GetPenguinNumber(){
            return myPenguin;
        }

    }
}

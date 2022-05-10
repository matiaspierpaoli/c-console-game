using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pierpaoli_Console_Game
{
    class Enemy : Entity
    {
        private bool moveUpLeft = false;
        private bool moveDownRight = false;
        private bool moveUpRight = false;
        private bool moveDownLeft = false;

        public Enemy(int x, int y, ConsoleColor color) : base(x, y, color)
        {
        
        }

        public void MoveOneNormalPos()
        {
            int rnd = GameManager.generadorRandoms.Next(0, 5);

            switch (rnd)
            {
                case 0:
                    MoveUp();
                    break;
                case 1:
                    MoveDown();
                    break;
                case 2:
                    MoveLeft();
                    break;
                case 3:
                    MoveRight();
                    break;
                default:
                    break;
            }
        }

        public void MoveDiagonaly()
        {
            int rnd = GameManager.generadorRandoms.Next(0, 4);

            switch (rnd)
            {
                case 1:
                    moveUpLeft = true;
                    break;
                case 2:
                    moveDownRight = true; 
                    break;
                case 3:
                    moveUpRight = true;
                    break;
                case 4:
                    moveDownLeft = true;
                    break;
                default:
                    break;
            }
        
            if (moveUpLeft == true)
            {                
                x--;
                y--;

                if (x <= UI.gameFrameXBasePos)
                {
                    x += x;
                }

                if (y <= UI.gameFrameYBasePos)
                {
                    y += y;
                }
                


                moveUpLeft = false;
            }
            else if (moveDownRight == true)
            {
                x++;
                y++;

                if (x <= UI.gameFrameWidth)
                {
                    x -= x;
                }
                
                if (y <= UI.gameFrameHeight)
                {
                    y -= y;
                }

                moveDownRight = false;
            }
            else if (moveUpRight == true)
            {
                x++;
                y--;
                
                if (x <= UI.gameFrameWidth)
                {
                    x -= x;
                }
                
                if (y <= UI.gameFrameYBasePos)
                {
                    y += y;
                }

                moveUpRight = false;
            }
            else 
            {
                x--;
                y++;

                if (x <= UI.gameFrameXBasePos)
                {
                    x += x;
                }
                
                if (y <= UI.gameFrameHeight)
                {
                    y -= y;
                }

                moveDownLeft = false;
            }
        }

        public void MoveInLineVerticaly()
        {
            MoveUp();

            if (y <= UI.gameFrameYBasePos + 1)
            {
                y = UI.gameFrameHeight + UI.gameFrameYBasePos;
            }                       
        }
    }
}

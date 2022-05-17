using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pierpaoli_Console_Game
{
    class DiagonalMovement : Movement
    {
        private bool moveUpLeft = false;
        private bool moveDownRight = false;
        private bool moveUpRight = false;
        private bool moveDownLeft = false;

        public override void Move(ref Position position)
        {
            int rnd = GameManager.generadorRandoms.Next(0, 4);

            switch (rnd)
            {
                case 0:
                    moveUpLeft = true;
                    break;
                case 1:
                    moveDownRight = true;
                    break;
                case 2:
                    moveUpRight = true;
                    break;
                case 3:
                    moveDownLeft = true;
                    break;
                default:
                    break;
            }

            if (moveUpLeft == true)
            {
                position.x--;
                position.y--;

                moveUpLeft = false;
            }
            else if (moveDownRight == true)
            {
                position.x++;
                position.y++;                

                moveDownRight = false;
            }
            else if (moveUpRight == true)
            {
                position.x++;
                position.y--;               

                moveUpRight = false;
            }
            else
            {
                position.x--;
                position.y++;

                moveDownLeft = false;
            }
        }
    }
}

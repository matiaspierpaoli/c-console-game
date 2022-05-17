using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pierpaoli_Console_Game
{
    class RandomMovement : Movement
    {
        public override void Move(ref Position position)
        {
            int rnd = GameManager.generadorRandoms.Next(0, 4);

            switch (rnd)
            {
                case 0:
                    position.y--;
                    break;
                case 1:
                    position.y++;
                    break;
                case 2:
                    position.x--;
                    break;
                case 3:
                    position.x++;
                    break;
                default:
                    break;
            }
        }

    }
}
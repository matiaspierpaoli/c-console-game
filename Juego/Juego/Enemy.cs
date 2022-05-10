using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pierpaoli_Console_Game
{
    class Enemy : Entity
    {

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
    }
}

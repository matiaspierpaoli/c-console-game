using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pierpaoli_Console_Game
{
    class Object
    {      
        public int x { get; set; }
        public int y { get; set; }
        public ConsoleColor color { get; set; }
       
        public Object(int x, int y, ConsoleColor color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }

        public void MoveUp() { y--; if (y <= UI.gameFrameYBasePos) y = UI.gameFrameYBasePos + 1; }
        public void MoveDown() { y++; if (y >= UI.gameFrameHeight + UI.gameFrameYBasePos) y = UI.gameFrameHeight + UI.gameFrameYBasePos; }
        public void MoveLeft() { x--; if (x <= UI.gameFrameXBasePos) x = UI.gameFrameXBasePos + 1; }
        public void MoveRight() { x++; if (x >= UI.gameFrameWidth) x = UI.gameFrameWidth; }

        public void MoveEnemyOnePos()
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

        public void RandomizePosition()
        {
            x = GameManager.generadorRandoms.Next(UI.gameFrameXBasePos + 1, UI.gameFrameWidth - 1);
            y = GameManager.generadorRandoms.Next(UI.gameFrameYBasePos + 1, UI.gameFrameHeight - 1);
        }

        public void Draw(char letter) { Console.Write(letter); }
    }
}

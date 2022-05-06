using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego
{
    class Object
    {
        private int lives = 5;
       
        public void Draw(char letter) { Console.Write(letter); }
        public void DrawLives() { Console.Write("Lives: " + lives); }

        public int x { get; set; }
        public int y { get; set; }   
        public int GetLives() { return lives; }

        public void MoveUp() {  y--; if (y <= UI.gameFrameYBasePos) y = UI.gameFrameYBasePos + 1; }
        public void MoveDown() { y++; if (y >= UI.gameFrameHeight + UI.gameFrameYBasePos) y = UI.gameFrameHeight + UI.gameFrameYBasePos; }
        public void MoveLeft() { x--; if (x <= UI.gameFrameXBasePos) x = UI.gameFrameXBasePos + 1; }
        public void MoveRight() { x++; if (x >= UI.gameFrameWidth) x = UI.gameFrameWidth; }

        public void MoveEnemyOnePos()
        {           
            int rnd = Program.generadorRandoms.Next(0, 5);

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
            x = Program.generadorRandoms.Next(UI.gameFrameXBasePos + 1, UI.gameFrameWidth - 1);
            y = Program.generadorRandoms.Next(UI.gameFrameYBasePos + 1, UI.gameFrameHeight - 1);
        }

        public void TakeDamage() { lives--;}
        public void AddPoint() { UI.points++;}

    }
}

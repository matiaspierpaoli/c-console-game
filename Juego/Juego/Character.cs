using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego
{
    class Character
    {
        private int lives = 5;
       
        public void Draw(char letter) { Console.Write(letter); }
        public void DrawLives() { Console.Write("Lives: " + lives); }

        public int x { get; set; }
        public int y { get; set; }   
        public int GetLives() { return lives; }

        public void MoveUp() {  y--; if (y <= Program.frameYBasePos) y = Program.frameYBasePos + 1; }
        public void MoveDown() { y++; if (y >= Program.frameHeight + Program.frameYBasePos) y = Program.frameHeight + Program.frameYBasePos; }
        public void MoveLeft() { x--; if (x <= Program.frameXBasePos) x = Program.frameXBasePos + 1; }
        public void MoveRight() { x++; if (x >= Program.frameWidth) x = Program.frameWidth; }

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
            x = Program.generadorRandoms.Next(Program.frameXBasePos, Program.frameWidth);
            y = Program.generadorRandoms.Next(Program.frameYBasePos, Program.frameHeight);
        }

        public void TakeDamage() { lives--;}

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego
{
    class Character
    {
        private int x = 0;
        private int y = 0;

        private int lives = 5;
       
        public void Draw(char letter) { Console.Write(letter); }
        public void DrawLives() { Console.Write(lives); }
        public void SetX(int value) {x = value; }
        public void SetY(int value) { y = value; }
        public int GetX() { return x; }
        public int GetY() { return y;}
        public int GetLives() { return lives; }

        public void CheckInput(ConsoleKeyInfo cki)
        {
            if (cki.Key == ConsoleKey.UpArrow) {MoveUp();}
            else if(cki.Key == ConsoleKey.DownArrow) { MoveDown(); }
            else if (cki.Key == ConsoleKey.LeftArrow) { MoveLeft(); }
            else if (cki.Key == ConsoleKey.RightArrow) { MoveRight(); }
        }
        public void MoveUp() {  y--; if (y <= 0) y = 0; }
        public void MoveDown() { y++; if (y >= Console.WindowHeight) y = 0; }
        public void MoveLeft() { x--; if (x <= 0) x = 0; }
        public void MoveRight() { x++; if (x >= Console.WindowWidth) y = 0; }

        public void GetRandomMove()
        {
            Random generadorRandoms = new Random();
            int rnd = generadorRandoms.Next(0, 5);

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

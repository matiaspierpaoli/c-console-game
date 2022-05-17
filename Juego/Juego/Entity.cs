using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pierpaoli_Console_Game
{
    class Entity
    {
        public Position position = new Position();
        public ConsoleColor color { get; set; }
       
        public Entity(int x, int y, ConsoleColor color)
        {
            this.position.x = x;
            this.position.y = y;
                      
            this.color = color;
        }

        public void Draw(char letter)
        {
            Console.Write(letter);
        }
    }
}

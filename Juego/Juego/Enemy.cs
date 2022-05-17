using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pierpaoli_Console_Game
{
    class Enemy : Entity
    {       
        Movement movement;

        public Enemy(int x, int y, ConsoleColor color, Movement movement) : base(x, y, color)
        {
            this.movement = movement;
        }

        public void Move()
        {
            movement.Move(ref position);
            
            position.SetLimits();
        } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego
{
    class UI
    {
        public static int points { get; set; }
        public void DrawPoints() { Console.WriteLine("Points: " + points); }
        public void DrawAttack() { Console.WriteLine("ATACK!");}
        


    }
}

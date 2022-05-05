using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego
{
    class UI
    {
        static int points;

        public void SetPoints(int value){ points = value; }
        public int GetPoints() { return points; }
        public void DrawPoints() { Console.WriteLine(points); }
        public void DrawFrame() {; }


    }
}

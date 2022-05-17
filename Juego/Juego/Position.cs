using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pierpaoli_Console_Game
{
    class Position
    {
        public int x { get; set; }
        public int y { get; set; }

        public void RandomizePosition()
        {
            x = GameManager.generadorRandoms.Next(UI.gameFrameXBasePos + 1, UI.gameFrameWidth - 1);
            y = GameManager.generadorRandoms.Next(UI.gameFrameYBasePos + 1, UI.gameFrameHeight - 1);
        }

        public void SetLimits()
        {
            if (y <= UI.gameFrameYBasePos) y = UI.gameFrameYBasePos + 1;

            if (y >= UI.gameFrameHeight + UI.gameFrameYBasePos) y = UI.gameFrameHeight + UI.gameFrameYBasePos;

            if (x <= UI.gameFrameXBasePos) x = UI.gameFrameXBasePos + 1;

            if (x >= UI.gameFrameWidth) x = UI.gameFrameWidth;
        }
    }
}

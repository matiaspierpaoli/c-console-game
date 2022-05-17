﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pierpaoli_Console_Game
{
    class LinearMovement : Movement
    {
        public override void Move(ref Position position)
        {
            position.y--;

            if (position.y <= UI.gameFrameYBasePos) position.y = UI.gameFrameHeight - 1 + UI.gameFrameHeight;
        }

    }
}

﻿using EVE.ISXEVE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daedalus.Functions
{
    static class f_EVECommands
    {
        static f_EVECommands()
        {
            // Init
        }

        public static void ExitStation()
        {
            Daedalus.Eve.Execute(ExecuteCommand.CmdExitStation);
        }

        public static void StopShip()
        {
            Daedalus.Eve.Execute(ExecuteCommand.CmdStopShip);
        }
    }
}

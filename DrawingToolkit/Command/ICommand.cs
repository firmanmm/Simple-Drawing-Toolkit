﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Command
{
    public interface ICommand
    {
        void Execute();
        void Unexecute();
    }
}

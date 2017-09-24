﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelloMario
{
    interface IBlockState
    {
        void changeToSilent();
        void changeToDestroy();
        void changeToHidden();
        void changeToUsed();
    }
}

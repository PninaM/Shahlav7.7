﻿using System;
using BL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDB
{
    class Program
    {
        static void Main(string[] args)
        {
            BL.BaseLogic baseLogic = new BaseLogic();
            baseLogic.Test();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Serin.MarsRover
{
    public class Plateau
    {
        public int X { get; internal set; }
        public int Y { get; internal set; }

        public Plateau(int _X, int _Y)
        {
            X = _X;
            Y = _Y; 
        }
         
    }
}

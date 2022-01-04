using System;
using System.Collections.Generic;
using System.Text;

namespace Serin.MarsRover
{
    public class Rover
    {
        public int X { get; internal set; }
        public int Y { get; internal set; }
        public Direction Direction { get; internal set; }

        public Rover(int _X, int _Y, Direction _Direction)
        {
            X = _X;
            Y = _Y;
            Direction = _Direction;
        }
        public Rover Explore(Path path)
        {
            Rover rover = new Rover(X, Y, Direction);
            switch (Direction)
            {
                case Direction.N:
                    if (path == Path.L)
                    {
                        rover = new Rover(X, Y, Direction.W);
                    }
                    else if (path == Path.R)
                    {
                        rover = new Rover(X, Y, Direction.E);
                    }
                    else if (path == Path.M)
                    {
                        rover = new Rover(X, Y + 1, Direction);
                    }
                    break;
                case Direction.S:
                    if (path == Path.L)
                    {
                        rover = new Rover(X, Y, Direction.E);
                    }
                    else if (path == Path.R)
                    {
                        rover = new Rover(X, Y, Direction.W);
                    }
                    else if (path == Path.M)
                    {
                        rover = new Rover(X, Y - 1, Direction);
                    }
                    break;
                case Direction.W:
                    if (path == Path.L)
                    {
                        rover = new Rover(X, Y, Direction.S);
                    }
                    else if (path == Path.R)
                    {
                        rover = new Rover(X, Y, Direction.N);
                    }
                    else if (path == Path.M)
                    {
                        rover = new Rover(X - 1, Y, Direction);
                    }
                    break;
                case Direction.E:
                    if (path == Path.L)
                    {
                        rover = new Rover(X, Y, Direction.N);
                    }
                    else if (path == Path.R)
                    {
                        rover = new Rover(X, Y, Direction.S);
                    }
                    else if (path == Path.M)
                    {
                        rover = new Rover(X +1, Y, Direction);
                    }
                    break;
                default:
                    break;
            } 
            return rover;
        } 

        public override string ToString()
        {
            return string.Format("{0} {1} {2}{3}", X, Y, Direction, Environment.NewLine);
        }
    }
}

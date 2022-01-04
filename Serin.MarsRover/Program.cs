using System;
using System.Collections.Generic;
using System.IO;

namespace Serin.MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {  
            string inputText = String.Format("5 5{0}1 2 N{0}LMLMLMLMM{0}3 3 E{0}MMRMMRMRRM", Environment.NewLine);
            Console.WriteLine(String.Format("Test Input:{0}{1}", Environment.NewLine, inputText));
            string outputText = GetRoverCoordinates(inputText);
            Console.WriteLine(String.Format("Output:{0}{1}",Environment.NewLine ,outputText));
            Console.ReadLine();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputText">
        /// 5 5 
        /// 1 2 N
        /// LMLMLMLMM
        /// 3 3 E
        /// MMRMMRMRRM
        /// </param>
        /// <returns></returns>
        private static string GetRoverCoordinates(string inputText)
        {
            string outputText = string.Empty;
            List<string> inputList = new List<string>(inputText.Split(Environment.NewLine));

            string[] plateauInput = inputList[0].Split(" ");  

            if (Int32.TryParse(plateauInput[0], out int plateauX) && Int32.TryParse(plateauInput[1], out int plateauY))
            {
                Plateau plateu = new Plateau(plateauX, plateauY); 

                for (int i = 1; i < inputList.Count - 1; i += 2)
                {
                    Rover rover;
                    string[] roverInitialPosition = inputList[i].Split(" ");
                    string roverRoutes = inputList[i + 1]; 

                    if (Enum.TryParse<Direction>(roverInitialPosition[2], out Direction direction) && Int32.TryParse(roverInitialPosition[0], out int x) && Int32.TryParse(roverInitialPosition[1], out int y))
                    {
                        rover = new Rover(Convert.ToInt32(roverInitialPosition[0]), Convert.ToInt32(roverInitialPosition[1]), direction);
                    }
                    else
                    {
                        outputText += "Invalid input direction operation!";
                        break;
                    }

                    for (int j = 0; j < roverRoutes.Length; j++)
                    { 
                        if (Enum.TryParse<Path>(roverRoutes[j].ToString(), out Path path))
                        {
                            rover = rover.Explore(path);
                            if (rover.X > plateu.X || rover.Y > plateu.Y)
                            {
                                outputText += "Rover is out of the map!";
                                break;
                            }
                        }
                        else
                        {
                            outputText += "Invalid input path operation!";
                            break;
                        }
                    }
                    outputText += rover.ToString();
                } 
            }
            else
            {
                outputText = "Invalid input plateau operation!";
            }
            return outputText;
        }
    }
}

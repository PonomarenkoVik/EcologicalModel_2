﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcologicalModel
{
    class UI
    {

        static byte initX = 3;
        static byte initY = 3;
        private static void DisplayBorder(Ocean ocean)
        {
            for (int i = 0; i < ocean.NumCols; i++)
            {
                Console.SetCursorPosition(initX + i, initY - 1);
                Console.Write("*");
                Console.SetCursorPosition(initX + i, initY + ocean.NumRows);
                Console.Write("*");
            } 
        }

        public static void Display(Ocean ocean, int iterNum)
        {
            Console.SetWindowSize(100, 40);
            Console.CursorVisible = false;
            DisplayStats(iterNum, ocean);
            DisplayBorder(ocean);
            DisplayCells(ocean);
        }
        private static void DisplayCells(Ocean ocean)
        { 
            for (byte y = 0; y < ocean.NumRows; y++)
            {
                for (byte x = 0; x < ocean.NumCols; x++)
                {
                    if (ocean[new Coordinate(x, y)] != null)
                    {
                        
                        Console.SetCursorPosition(initX + x, initY + y);
                        Console.Write(ocean[new Coordinate(x, y)].Image); 
                    }
                    else
                    {
                        Console.SetCursorPosition(initX + x, initY + y);
                        Console.Write("-");
                    }
                }
            }
        }

        private static void DisplayStats(int iterNum, Ocean ocean)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Iteration: {0}  Obstacles: {1}  Megalodons: {2}  Shark: {3}  Stingray: {4} Tuna: {5} ", iterNum, ocean.NumObstacles, ocean.NumMegalodon, ocean.NumShark, ocean.NumStingray, ocean.NumTuna);
            Console.WriteLine("   Number born prey: {0}  Number born predators: {1}  Number of eaten prey: {2} ", ocean.NumBornPrey, ocean.NumBornPredators, ocean.NumEaten);

        }

        public static int GetNumberIteration(string message)
        {
            Console.WriteLine(message);
            int number;
            do
            {
                int.TryParse(Console.ReadLine(), out number);
                if (number == 0)
                {
                    Console.WriteLine("Inputted value is incorrect\n");  
                }
            } while (number == 0);
            Console.Clear();
            return number;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


public class Game
    {
        public int CarSpawnInterval { get; set; }
        public Track Track { get; set; }
        public bool IsGameOver { get; set; }
        public int Score { get; set; }
        private Random r;

        public Game()
        {
            r = new Random();
            CarSpawnInterval = r.Next(1, 5);
            IsGameOver = false;
        }

        public void AddScore(int extraScore)
        {
            Score += extraScore;
        }

        public void buildMap()
        {
            string path = Path.Combine(Path.GetFullPath(@"..\..\"), @"Resources\Map\Map.txt");
            string[] sArray = File.ReadAllLines(path);

            char[,] array = new char[13, 10];

            int row = 0;
            foreach (string s in sArray)
            {
                int column = 0;
                foreach (char c in s.ToCharArray())
                {
                    array[column, row] = c;
                    column++;
                }
                row++;
            }
            Track = new Track(array);
        }
    }
   

